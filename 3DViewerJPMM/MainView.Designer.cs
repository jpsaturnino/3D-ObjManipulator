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
            this.CheckBoxFaces = new System.Windows.Forms.CheckBox();
            this.PBMain = new System.Windows.Forms.PictureBox();
            this.PBFrontalView = new System.Windows.Forms.PictureBox();
            this.PBLateralView = new System.Windows.Forms.PictureBox();
            this.PBPlantView = new System.Windows.Forms.PictureBox();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.ObjectBtnColor = new System.Windows.Forms.Button();
            this.AmbientBtnColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.LoadObjectBtn.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            this.SidePanel.Controls.Add(this.CheckBoxFaces);
            this.SidePanel.Controls.Add(this.LoadObjectBtn);
            this.SidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SidePanel.Location = new System.Drawing.Point(757, 0);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(200, 585);
            this.SidePanel.TabIndex = 1;
            // 
            // CheckBoxFaces
            // 
            this.CheckBoxFaces.AutoSize = true;
            this.CheckBoxFaces.FlatAppearance.BorderSize = 0;
            this.CheckBoxFaces.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckBoxFaces.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBoxFaces.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.CheckBoxFaces.Location = new System.Drawing.Point(22, 528);
            this.CheckBoxFaces.Name = "CheckBoxFaces";
            this.CheckBoxFaces.Size = new System.Drawing.Size(157, 22);
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
            this.ObjectBtnColor.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.AmbientBtnColor.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AmbientBtnColor.Location = new System.Drawing.Point(659, 18);
            this.AmbientBtnColor.Name = "AmbientBtnColor";
            this.AmbientBtnColor.Size = new System.Drawing.Size(92, 20);
            this.AmbientBtnColor.TabIndex = 9;
            this.AmbientBtnColor.Text = "Cor Ambiente";
            this.AmbientBtnColor.UseVisualStyleBackColor = false;
            this.AmbientBtnColor.Click += new System.EventHandler(this.AmbientBtnColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.label1.Location = new System.Drawing.Point(659, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Vista planta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.label2.Location = new System.Drawing.Point(659, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Vista lateral";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.label3.Location = new System.Drawing.Point(659, 499);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Vista frontal";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(957, 585);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._KeyPress);
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
        private Label label1;
        private Label label2;
        private Label label3;
        private CheckBox CheckBoxFaces;
    }
}