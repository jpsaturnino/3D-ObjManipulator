
using _3DViewerJPMM.Models;

namespace _3DViewerJPMM
{
    public partial class MainView : Form
    {
        private _3DObject obj;
        
        public MainView()
        {
            InitializeComponent();
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
                this.obj = new _3DObject(openFileDialog.FileName);
                // Redimensiona o obj de acordo com o tamanho da tela, para que fique proporcinal
                // Isso => { pictureBox1.Width >> 2 ==> "pictureBox1.Width / 2" }
                double s = (pictureBox1.Width >> 2) / Math.Abs(this.obj.MAX_X - this.obj.MIN_X);
                // Realiza a escala a partir do obtido
                this.obj.Scaling(s, s, s);

                this.refreshObject();
                //pbPrincipal.Enabled = true;
            }
        }

        private void refreshObject()
        {
            if(this.obj != null)
            {
                // this.updateLightButton
                // Setting vectors
                double d

            }
        }

    }
}