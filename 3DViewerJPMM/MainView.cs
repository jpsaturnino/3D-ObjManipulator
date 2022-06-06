
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
        private Vertex light, eye;
        private int x1, y1, x2, y2, tx, ty;
        private bool showHiddenFaces;
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
            if (e.Button == MouseButtons.Left) // if the mouseleft has been pressed
            {
                obj.RotationX(DegreesToRadians(-(y2 - y1)), showHiddenFaces);
                obj.RotationY(DegreesToRadians(x2 - x1), showHiddenFaces);
                RefreshObject();
            }
            else if (e.Button == MouseButtons.Right) // if the mouseright has been pressed
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

            switch(projection)
            {
                case "Parallel":
                    draw.ParallelProjection(frontalBitmap, obj2, cx, cy, ObjectBtnColor.BackColor, showHiddenFaces, "XY");
                    draw.ParallelProjection(sideBitmap, obj2, cx, cy, ObjectBtnColor.BackColor, showHiddenFaces, "ZY");
                    draw.ParallelProjection(plantBitmap, obj2, cx, cy, ObjectBtnColor.BackColor, showHiddenFaces, "ZX");
                    break;
                case "Perspective":
                    draw.PerspectiveProjection(frontalBitmap, obj2, cx, cy, ObjectBtnColor.BackColor, showHiddenFaces, "XY", -200);
                    draw.PerspectiveProjection(sideBitmap, obj2, cx, cy, ObjectBtnColor.BackColor, showHiddenFaces, "ZY", -200);
                    draw.PerspectiveProjection(plantBitmap, obj2, cx, cy, ObjectBtnColor.BackColor, showHiddenFaces, "ZX", -200);
                    break;
            }
            
        }

        private void RefreshObject()
        {
            if(obj != null)
            {
                draw.Paint(mainBitmap, AmbientBtnColor.BackColor);
                switch (selectedPerspective)
                {
                    case "Cabinet":
                        HideCheckBox();
                        draw.ObliqueProjection(mainBitmap, obj, tx, ty, ObjectBtnColor.BackColor, showHiddenFaces, 0.5);
                        break;
                    case "Cavalier":
                        HideCheckBox();
                        draw.ObliqueProjection(mainBitmap, obj, tx, ty, ObjectBtnColor.BackColor, showHiddenFaces, 1);
                        break;
                    case "Perspective":
                        HideCheckBox();
                        draw.PerspectiveProjection(mainBitmap, obj, tx, ty, ObjectBtnColor.BackColor, showHiddenFaces, "XY", -200);
                        break;
                    default:
                        ShowCheckBox();
                        switch(cbLighting.Text)
                        {
                            case "Gouraund":
                                //draw.Gouraund();
                                break;
                            case "Flat":
                               //draw.Flat(mainBitmap, obj, tx, ty, light, new Vertex(1, 1, 0), 10, ObjectBtnColor.BackColor.R, ObjectBtnColor.BackColor.G, ObjectBtnColor.BackColor.B, ka, kd, ke);
                               break;
                            case "Phong":
                                //draw.Phong();
                                break;
                            default:
                                draw.ParallelProjection(mainBitmap, obj, tx, ty, ObjectBtnColor.BackColor, showHiddenFaces, "XY");
                                break;
                        }
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