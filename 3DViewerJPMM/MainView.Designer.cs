namespace _3DViewerJPMM
{
    partial class MainView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadObjectBtn = new System.Windows.Forms.Button();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.rbPerspective = new System.Windows.Forms.RadioButton();
            this.rbCavalier = new System.Windows.Forms.RadioButton();
            this.rbCabinet = new System.Windows.Forms.RadioButton();
            this.rbParallel = new System.Windows.Forms.RadioButton();
            this.labelProjections = new System.Windows.Forms.Label();
            this.CheckBoxFaces = new System.Windows.Forms.CheckBox();
            this.PBMain = new System.Windows.Forms.PictureBox();
            this.PBFrontalView = new System.Windows.Forms.PictureBox();
            this.PBLateralView = new System.Windows.Forms.PictureBox();
            this.PBPlantView = new System.Windows.Forms.PictureBox();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.ObjectBtnColor = new System.Windows.Forms.Button();
            this.AmbientBtnColor = new System.Windows.Forms.Button();
            this.plantView = new System.Windows.Forms.Label();
            this.sideView = new System.Windows.Forms.Label();
            this.frontView = new System.Windows.Forms.Label();
            this.SidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBFrontalView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBLateralView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBPlantView)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadObjectBtn
            // 
            this.LoadObjectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            this.LoadObjectBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.LoadObjectBtn.FlatAppearance.BorderSize = 0;
            this.LoadObjectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadObjectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LoadObjectBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.LoadObjectBtn.Location = new System.Drawing.Point(0, 556);
            this.LoadObjectBtn.Name = "LoadObjectBtn";
            this.LoadObjectBtn.Size = new System.Drawing.Size(200, 29);
            this.LoadObjectBtn.TabIndex = 0;
            this.LoadObjectBtn.Text = "Carregar Objeto";
            this.LoadObjectBtn.UseVisualStyleBackColor = false;
            this.LoadObjectBtn.Click += new System.EventHandler(this.LoadObjectBtn_Click);
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.SidePanel.Controls.Add(this.rbPerspective);
            this.SidePanel.Controls.Add(this.rbCavalier);
            this.SidePanel.Controls.Add(this.rbCabinet);
            this.SidePanel.Controls.Add(this.rbParallel);
            this.SidePanel.Controls.Add(this.labelProjections);
            this.SidePanel.Controls.Add(this.CheckBoxFaces);
            this.SidePanel.Controls.Add(this.LoadObjectBtn);
            this.SidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SidePanel.Location = new System.Drawing.Point(757, 0);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(200, 585);
            this.SidePanel.TabIndex = 1;
            // 
            // rbPerspective
            // 
            this.rbPerspective.AutoSize = true;
            this.rbPerspective.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbPerspective.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.rbPerspective.Location = new System.Drawing.Point(22, 105);
            this.rbPerspective.Name = "rbPerspective";
            this.rbPerspective.Size = new System.Drawing.Size(97, 20);
            this.rbPerspective.TabIndex = 17;
            this.rbPerspective.TabStop = true;
            this.rbPerspective.Text = "Perspectiva";
            this.rbPerspective.UseVisualStyleBackColor = true;
            this.rbPerspective.CheckedChanged += new System.EventHandler(this.rbPerspective_CheckedChanged);
            // 
            // rbCavalier
            // 
            this.rbCavalier.AutoSize = true;
            this.rbCavalier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbCavalier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.rbCavalier.Location = new System.Drawing.Point(22, 64);
            this.rbCavalier.Name = "rbCavalier";
            this.rbCavalier.Size = new System.Drawing.Size(83, 20);
            this.rbCavalier.TabIndex = 16;
            this.rbCavalier.TabStop = true;
            this.rbCavalier.Text = "Cavaleira";
            this.rbCavalier.UseVisualStyleBackColor = true;
            this.rbCavalier.CheckedChanged += new System.EventHandler(this.rbCavalier_CheckedChanged);
            // 
            // rbCabinet
            // 
            this.rbCabinet.AutoSize = true;
            this.rbCabinet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbCabinet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.rbCabinet.Location = new System.Drawing.Point(22, 44);
            this.rbCabinet.Name = "rbCabinet";
            this.rbCabinet.Size = new System.Drawing.Size(71, 20);
            this.rbCabinet.TabIndex = 15;
            this.rbCabinet.TabStop = true;
            this.rbCabinet.Text = "Cabinet";
            this.rbCabinet.UseVisualStyleBackColor = true;
            this.rbCabinet.CheckedChanged += new System.EventHandler(this.rbCabinet_CheckedChanged);
            // 
            // rbParallel
            // 
            this.rbParallel.AutoSize = true;
            this.rbParallel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbParallel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.rbParallel.Location = new System.Drawing.Point(22, 84);
            this.rbParallel.Name = "rbParallel";
            this.rbParallel.Size = new System.Drawing.Size(76, 20);
            this.rbParallel.TabIndex = 14;
            this.rbParallel.TabStop = true;
            this.rbParallel.Text = "Paralela";
            this.rbParallel.UseVisualStyleBackColor = true;
            this.rbParallel.CheckedChanged += new System.EventHandler(this.rbParallel_CheckedChanged);
            // 
            // labelProjections
            // 
            this.labelProjections.AutoSize = true;
            this.labelProjections.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelProjections.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.labelProjections.Location = new System.Drawing.Point(13, 18);
            this.labelProjections.Name = "labelProjections";
            this.labelProjections.Size = new System.Drawing.Size(88, 20);
            this.labelProjections.TabIndex = 13;
            this.labelProjections.Text = "Projeções";
            // 
            // CheckBoxFaces
            // 
            this.CheckBoxFaces.AutoSize = true;
            this.CheckBoxFaces.FlatAppearance.BorderSize = 0;
            this.CheckBoxFaces.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckBoxFaces.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBoxFaces.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.CheckBoxFaces.Location = new System.Drawing.Point(22, 528);
            this.CheckBoxFaces.Name = "CheckBoxFaces";
            this.CheckBoxFaces.Size = new System.Drawing.Size(150, 20);
            this.CheckBoxFaces.TabIndex = 1;
            this.CheckBoxFaces.Text = "Mostrar faces ocultas";
            this.CheckBoxFaces.UseVisualStyleBackColor = true;
            this.CheckBoxFaces.CheckedChanged += new System.EventHandler(this.CheckBoxFaces_CheckedChanged);
            // 
            // PBMain
            // 
            this.PBMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.PBMain.Location = new System.Drawing.Point(12, 44);
            this.PBMain.Name = "PBMain";
            this.PBMain.Size = new System.Drawing.Size(739, 529);
            this.PBMain.TabIndex = 2;
            this.PBMain.TabStop = false;
            this.PBMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PBMain_MouseMove);
            // 
            // PBFrontalView
            // 
            this.PBFrontalView.Location = new System.Drawing.Point(659, 513);
            this.PBFrontalView.Name = "PBFrontalView";
            this.PBFrontalView.Size = new System.Drawing.Size(82, 50);
            this.PBFrontalView.TabIndex = 3;
            this.PBFrontalView.TabStop = false;
            // 
            // PBLateralView
            // 
            this.PBLateralView.Location = new System.Drawing.Point(659, 434);
            this.PBLateralView.Name = "PBLateralView";
            this.PBLateralView.Size = new System.Drawing.Size(82, 50);
            this.PBLateralView.TabIndex = 4;
            this.PBLateralView.TabStop = false;
            // 
            // PBPlantView
            // 
            this.PBPlantView.Location = new System.Drawing.Point(659, 354);
            this.PBPlantView.Name = "PBPlantView";
            this.PBPlantView.Size = new System.Drawing.Size(82, 50);
            this.PBPlantView.TabIndex = 5;
            this.PBPlantView.TabStop = false;
            // 
            // ObjectBtnColor
            // 
            this.ObjectBtnColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            this.ObjectBtnColor.FlatAppearance.BorderSize = 0;
            this.ObjectBtnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ObjectBtnColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ObjectBtnColor.Location = new System.Drawing.Point(579, 18);
            this.ObjectBtnColor.Name = "ObjectBtnColor";
            this.ObjectBtnColor.Size = new System.Drawing.Size(74, 20);
            this.ObjectBtnColor.TabIndex = 8;
            this.ObjectBtnColor.Text = "Cor Objeto";
            this.ObjectBtnColor.UseVisualStyleBackColor = false;
            this.ObjectBtnColor.Click += new System.EventHandler(this.SelectColorBtn_Click);
            // 
            // AmbientBtnColor
            // 
            this.AmbientBtnColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.AmbientBtnColor.FlatAppearance.BorderSize = 0;
            this.AmbientBtnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AmbientBtnColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AmbientBtnColor.Location = new System.Drawing.Point(659, 18);
            this.AmbientBtnColor.Name = "AmbientBtnColor";
            this.AmbientBtnColor.Size = new System.Drawing.Size(92, 20);
            this.AmbientBtnColor.TabIndex = 9;
            this.AmbientBtnColor.Text = "Cor Ambiente";
            this.AmbientBtnColor.UseVisualStyleBackColor = false;
            this.AmbientBtnColor.Click += new System.EventHandler(this.AmbientBtnColor_Click);
            // 
            // plantView
            // 
            this.plantView.AutoSize = true;
            this.plantView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.plantView.Location = new System.Drawing.Point(659, 340);
            this.plantView.Name = "plantView";
            this.plantView.Size = new System.Drawing.Size(68, 15);
            this.plantView.TabIndex = 10;
            this.plantView.Text = "Vista planta";
            // 
            // sideView
            // 
            this.sideView.AutoSize = true;
            this.sideView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.sideView.Location = new System.Drawing.Point(659, 420);
            this.sideView.Name = "sideView";
            this.sideView.Size = new System.Drawing.Size(67, 15);
            this.sideView.TabIndex = 11;
            this.sideView.Text = "Vista lateral";
            // 
            // frontView
            // 
            this.frontView.AutoSize = true;
            this.frontView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.frontView.Location = new System.Drawing.Point(659, 499);
            this.frontView.Name = "frontView";
            this.frontView.Size = new System.Drawing.Size(70, 15);
            this.frontView.TabIndex = 12;
            this.frontView.Text = "Vista frontal";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(957, 585);
            this.Controls.Add(this.frontView);
            this.Controls.Add(this.sideView);
            this.Controls.Add(this.plantView);
            this.Controls.Add(this.AmbientBtnColor);
            this.Controls.Add(this.ObjectBtnColor);
            this.Controls.Add(this.PBPlantView);
            this.Controls.Add(this.PBLateralView);
            this.Controls.Add(this.PBFrontalView);
            this.Controls.Add(this.PBMain);
            this.Controls.Add(this.SidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3D";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.SidePanel.ResumeLayout(false);
            this.SidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBFrontalView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBLateralView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBPlantView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button LoadObjectBtn;
        private Panel SidePanel;
        private PictureBox PBMain;
        private PictureBox PBFrontalView;
        private PictureBox PBLateralView;
        private PictureBox PBPlantView;
        private ColorDialog ColorDialog;
        private Button ObjectBtnColor;
        private Button AmbientBtnColor;
        private Label plantView;
        private Label sideView;
        private Label frontView;
        private CheckBox CheckBoxFaces;
        private Label labelProjections;
        private RadioButton rbParallel;
        private RadioButton rbPerspective;
        private RadioButton rbCavalier;
        private RadioButton rbCabinet;
    }
}