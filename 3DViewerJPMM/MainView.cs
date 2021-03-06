
using _3DViewerJPMM.Models;
using System.Diagnostics;
using static _3DViewerJPMM.Utils.Helper;

namespace _3DViewerJPMM
{
    public partial class MainView : Form
    {
        private _3DObject obj;
        private Bitmap mainBitmap, frontalBitmap, sideBitmap, plantBitmap;
        private Draw draw;
        private Vertex light;
        private int x1, y1, x2, y2, tx, ty;
        private bool showHiddenFaces, movingLight;
        private string selectedPerspective;

        public MainView() {
            InitializeComponent();
            showHiddenFaces = false;
            rbParallel.Checked = true;
            cbLighting.SelectedIndex = 0;
            CheckBoxFaces.AutoCheck = true;
            light = new Vertex(-1, -1, 1);
            PBMain.Enabled = false;
            draw = new Draw();
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
                double s = (PBMain.Width >> 2) / Math.Abs(obj.MaxX - obj.MinX);
                obj.Scaling(1, 1, 1);
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

        private void EnableLightningOptions(bool enable)
        {
            if(enable)
            {
                cbLighting.Enabled = true;
                labelLightning.ForeColor = Color.FromArgb(237, 237, 237);
            }
            else
            {
                cbLighting.Enabled = false;
                labelLightning.ForeColor = Color.Gray;
                cbLighting.SelectedIndex = 0;
            }
        }

        private void rbParallel_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRadioBtnColor(rbParallel);
            selectedPerspective = "Parallel";
            EnableLightningOptions(true);
            RefreshObject();
        }

        private void rbCabinet_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRadioBtnColor(rbCabinet);
            selectedPerspective = "Cabinet";
            EnableLightningOptions(false);
            RefreshObject();
        }

        private void rbCavalier_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRadioBtnColor(rbCavalier);
            selectedPerspective = "Cavalier";
            EnableLightningOptions(false);
            RefreshObject();
        }

        private void rbPerspective_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRadioBtnColor(rbPerspective);
            selectedPerspective = "Perspective";
            EnableLightningOptions(false);
            RefreshObject();
        }

        private void ChangeRadioBtnColor(RadioButton rb)
        {
            rbParallel.ForeColor = Color.White;
            rbCabinet.ForeColor = Color.White;
            rbCavalier.ForeColor = Color.White;
            rbPerspective.ForeColor = Color.White;
            rb.ForeColor = ObjectBtnColor.BackColor;
            LoadObjectBtn.BackColor = ObjectBtnColor.BackColor;
        }

        private void CheckBoxFaces_CheckedChanged(object sender, EventArgs e)
        {
            showHiddenFaces = CheckBoxFaces.Checked;
            RefreshObject();
        }

        private void PBMain_MouseWheel(object sender, MouseEventArgs e)
        {
            double delta;
            if (e.Delta > 0)
                delta = 1.1;
            else
                delta = 0.9;
            obj.Scaling(delta, delta, delta);
            RefreshObject();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void PBMain_MouseMove(object sender, MouseEventArgs e)
        {
            x2 = e.X;
            y2 = e.Y;
            if (e.Button == MouseButtons.Left)
            {
                obj.RotationX(DegreesToRadians(-(y2 - y1)), showHiddenFaces);
                obj.RotationY(DegreesToRadians(x2 - x1), showHiddenFaces);
                RefreshObject();
            }
            else if (e.Button == MouseButtons.Right)
            {
                tx += x2 - x1;
                ty += y2 - y1;
                RefreshObject();
            }
            else if (e.Button == MouseButtons.Middle){
                double g = (Math.Abs(y2 - y1) > Math.Abs(x2 - x1)) ? -(y2 - y1) : x2 - x1;
                obj.RotationZ(DegreesToRadians(g), showHiddenFaces);
                RefreshObject();

            }

            x1 = x2;
            y1 = y2;
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Thread.Sleep(200);
                mainBitmap = new Bitmap(PBMain.Width, PBMain.Height);
                frontalBitmap = new Bitmap(PBFrontalView.Width, PBFrontalView.Height);
                sideBitmap = new Bitmap(PBLateralView.Width, PBLateralView.Height);
                plantBitmap = new Bitmap(PBPlantView.Width, PBPlantView.Height);

                draw.Paint(mainBitmap, AmbientBtnColor.BackColor);
                draw.Paint(frontalBitmap, Color.FromArgb(23,23,23));
                draw.Paint(sideBitmap, Color.FromArgb(23, 23, 23));
                draw.Paint(plantBitmap, Color.FromArgb(23, 23, 23));
                Invoke(new MethodInvoker(delegate ()
                {
                    PBMain.Image = mainBitmap;
                    PBFrontalView.Image = frontalBitmap;
                    PBLateralView.Image = sideBitmap;
                    PBPlantView.Image = plantBitmap;

                    tx = mainBitmap.Width >> 1;
                    ty = mainBitmap.Height >> 1;
                }));
            }).Start();
        }

        private void HideCheckBox()
        {
            CheckBoxFaces.Checked = true;
            CheckBoxFaces.AutoCheck = false;
            CheckBoxFaces.ForeColor = Color.Gray;
        }

        private void ShowCheckBox()
        {
            CheckBoxFaces.Checked = CheckBoxFaces.Checked;
            CheckBoxFaces.AutoCheck = true;
            CheckBoxFaces.ForeColor = Color.FromArgb(237, 237, 237);
        }

        private void RenderViews(string projection)
        {
            _3DObject obj2 = obj.Copy();
            obj2.Scaling(0.2, 0.2, 0.2);
            int cx = frontalBitmap.Width >> 1, cy = frontalBitmap.Height >> 1; 

            draw.Paint(frontalBitmap, Color.FromArgb(23, 23, 23));
            draw.Paint(sideBitmap, Color.FromArgb(23, 23, 23));
            draw.Paint(plantBitmap, Color.FromArgb(23, 23, 23));
            draw.Projection(projection, frontalBitmap, obj2, cx, cy, ObjectBtnColor.BackColor, showHiddenFaces, "XY", -200);
            draw.Projection(projection, sideBitmap, obj2, cx, cy, ObjectBtnColor.BackColor, showHiddenFaces, "ZY", -200);
            draw.Projection(projection, plantBitmap, obj2, cx, cy, ObjectBtnColor.BackColor, showHiddenFaces, "ZX", -200);
        }

        private void LightBtn_MouseDown(object sender, MouseEventArgs e)
        {
            movingLight = obj != null && e.Button == MouseButtons.Left;
            if (movingLight)
                UpdateLight(MousePosition.X - 4 -(lightBtn.Width >> 1) - SidePanel.Width, MousePosition.Y - lightBtn.Height -60);
        }

        private void LightBtn_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingLight)
            {
                UpdateLight(MousePosition.X - 4 - (lightBtn.Width >> 1) - SidePanel.Width, MousePosition.Y - lightBtn.Height -60);
                RefreshObject();
            }
            
        }

        private void LightBtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (movingLight)
                UpdateLight(MousePosition.X - 4 -  (lightBtn.Width >> 1) - SidePanel.Width, MousePosition.Y - lightBtn.Height-60);
            movingLight = false;
        }

        private void UpdateLight(int x, int y)
        {
            if (x < PBMain.Location.X)
                x = PBMain.Location.X;
            else if (x > (PBMain.Location.X + PBMain.Width) - lightBtn.Width)
                x = (PBMain.Location.X + PBMain.Width) - lightBtn.Width;
            if (y < PBMain.Location.Y)
                y = PBMain.Location.Y;
            else if (y > (PBMain.Location.Y + PBMain.Height) - lightBtn.Height)
                y = (PBMain.Location.Y + PBMain.Height) - lightBtn.Height;
            
            
            lightBtn.Location = new Point(x, y);
            x = x + (lightBtn.Width >> 1) - PBMain.Location.X;
            y = y + (lightBtn.Height >> 1) - PBMain.Location.Y;

            light = new Vertex(x - tx, y - ty, 1);
            light = light.Normalize();
            light.Z = 1;
            lightBtn.Refresh();
        }

        private void RefreshObject()
        {
            if(obj != null)
            {
                UpdateLight(lightBtn.Location.X, lightBtn.Location.Y);
                draw.Paint(mainBitmap, AmbientBtnColor.BackColor);
                Vertex objColor = new Vertex(ObjectBtnColor.BackColor.R / 255.0, ObjectBtnColor.BackColor.G / 255.0, ObjectBtnColor.BackColor.B / 255.0); 
                switch (cbLighting.Text)
                {
                    case not "Wireframe":
                        HideCheckBox();
                        draw.Lightning(cbLighting.Text, mainBitmap, obj, tx, ty, light, new Vertex(0, 0, 1), 50, objColor);
                        break;
                    default:
                        ShowCheckBox();
                        draw.Projection(selectedPerspective, mainBitmap, obj, tx, ty, ObjectBtnColor.BackColor, showHiddenFaces);
                        break;
                }
                RenderViews(selectedPerspective);
                PBMain.Refresh();
                PBFrontalView.Refresh();
                PBLateralView.Refresh();
                PBPlantView.Refresh();
            }
        }

    }
}