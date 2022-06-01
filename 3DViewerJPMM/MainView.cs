
using _3DViewerJPMM.Models;
using System.Diagnostics;

namespace _3DViewerJPMM
{
    public partial class MainView : Form
    {
        private _3DObject obj;
        private Bitmap mainBitmap;
        private Draw draw;
        private int x1, y1, x2, y2, tx, ty;
        private bool ctrlIsPressed;

        public MainView() {
            InitializeComponent();
            PBMain.MouseWheel += new MouseEventHandler(PBMain_MouseWheel);
        }

    private void LoadObjectBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "";
            openFileDialog.Filter = "obj files (*.obj)|*.obj|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                obj = new _3DObject(openFileDialog.FileName);
                // Redimensiona o obj de acordo com o tamanho da tela, para que fique proporcinal
                // Isso => { pictureBox1.Width >> 2 ==> "pictureBox1.Width / 2" }
                double s = (PBMain.Width >> 2) / Math.Abs(obj.MAX_X - obj.MIN_X);
                // Realiza a escala a partir do obtido
                obj.Scaling(s, s, s);
                RefreshObject();
                PBMain.Enabled = true;
            }
        }

        private double GrausToRadians(double graus) => graus * Math.PI / 180;

        private void PBMain_MouseWheel(Object sender, MouseEventArgs e)
        {
            double delta;
            if (e.Delta > 0)
                delta = 1.1;
            else
                delta = 0.9;
            obj.Scaling(delta, delta, delta);
            RefreshObject();
        }

        private void PBMain_MouseMove(object sender, MouseEventArgs e)
        {
            x2 = e.X;
            y2 = e.Y;
            if (e.Button == MouseButtons.Left)
            {
                if (false)
                {
                    double angle = (Math.Abs(y2 - y1) > Math.Abs(x2 - x1)) ? -(y2 - y1) : x2 - x1;
                    obj.RotationZ(GrausToRadians(angle), false);
                }
                else
                {
                    obj.RotationX(GrausToRadians(-(y2 - y1)), false);
                    obj.RotationY(GrausToRadians(x2 - x1), false);
                }
                RefreshObject();
            }
            else if (e.Button == MouseButtons.Right) // translada objeto
            {
                tx += x2 - x1;// obj.translacao((x2 - x1), (y2 - y1), 0);
                ty += y2 - y1;
                RefreshObject();
            }
            x1 = x2;
            y1 = y2;
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            PBMain.Enabled = false;
            draw = new Draw();
            new Thread(() =>
            {
                Thread.Sleep(200);
                mainBitmap = new Bitmap(PBMain.Width, PBMain.Height);
                draw.paint(mainBitmap, labelAmbient.BackColor);
                Invoke(new MethodInvoker(delegate ()
                {
                    PBMain.Image = mainBitmap;

                    // centraliza o objeto na tela
                    tx = mainBitmap.Width >> 1;
                    ty = mainBitmap.Height >> 1;
                }));
            }).Start();
        }

        private void RefreshObject()
        {
            if(obj != null)
            {
                draw.paint(mainBitmap, labelAmbient.BackColor);
                draw.ParallelProjectionXY(mainBitmap, obj, tx, ty, labelMaterial.BackColor, false);
                PBMain.Refresh();
            }
        }

    }
}