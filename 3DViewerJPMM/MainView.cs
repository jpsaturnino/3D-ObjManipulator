
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
        private bool ctrlIsPressed, showHiddenFaces;

        public MainView() {
            InitializeComponent();
            showHiddenFaces = false;
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
                double s = (PBMain.Width >> 2) / Math.Abs(obj.MAX_X - obj.MIN_X);
                obj.Scaling(s, s, s);
                RefreshObject();
                PBMain.Enabled = true;
            }
        }

        private void SelectColorBtn_Click(object sender, EventArgs e)
        {
            SetColor(ObjectBtnColor);
        }

        private void AmbientBtnColor_Click(object sender, EventArgs e)
        {
            SetColor(AmbientBtnColor);
        }

        private void SetColor(Button btn)
        {
            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                btn.BackColor = ColorDialog.Color;
                if(btn.Text == "Cor Ambiente")
                {
                    draw.Paint(mainBitmap, AmbientBtnColor.BackColor);
                    PBMain.Refresh();
                }
                RefreshObject();
            }
        }

        private void _KeyPress(object sender, KeyPressEventArgs e)
        {
            Debug.WriteLine
        }

        private void CheckBoxFaces_CheckedChanged(object sender, EventArgs e)
        {
            showHiddenFaces = CheckBoxFaces.Checked;
            RefreshObject();
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
                if (ctrlIsPressed)
                {
                    Debug.WriteLine("Movimentando em Z");
                    double angle = (Math.Abs(y2 - y1) > Math.Abs(x2 - x1)) ? -(y2 - y1) : x2 - x1;
                    obj.RotationZ(GrausToRadians(angle), showHiddenFaces);
                }
                else
                {
                    obj.RotationX(GrausToRadians(-(y2 - y1)), showHiddenFaces);
                    obj.RotationY(GrausToRadians(x2 - x1), showHiddenFaces);
                }
                RefreshObject();
            }
            else if (e.Button == MouseButtons.Right)
            {
                tx += x2 - x1;
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
                draw.Paint(mainBitmap, AmbientBtnColor.BackColor);
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
                draw.Paint(mainBitmap, AmbientBtnColor.BackColor);
                draw.ParallelProjectionXY(mainBitmap, obj, tx, ty, ObjectBtnColor.BackColor, showHiddenFaces);
                PBMain.Refresh();
            }
        }

    }
}