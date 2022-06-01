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
            this.PBMain = new System.Windows.Forms.PictureBox();
            this.PBFrontalView = new System.Windows.Forms.PictureBox();
            this.PBLateralView = new System.Windows.Forms.PictureBox();
            this.PBPlantView = new System.Windows.Forms.PictureBox();
            this.labelMaterial = new System.Windows.Forms.Label();
            this.labelAmbient = new System.Windows.Forms.Label();
            this.SidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBFrontalView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBLateralView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBPlantView)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadObjectBtn
            // 
            this.LoadObjectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
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
            this.SidePanel.Controls.Add(this.LoadObjectBtn);
            this.SidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SidePanel.Location = new System.Drawing.Point(757, 0);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(200, 585);
            this.SidePanel.TabIndex = 1;
            // 
            // PBMain
            // 
            this.PBMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.PBMain.Location = new System.Drawing.Point(12, 44);
            this.PBMain.Name = "PBMain";
            this.PBMain.Size = new System.Drawing.Size(739, 423);
            this.PBMain.TabIndex = 2;
            this.PBMain.TabStop = false;
            this.PBMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PBMain_MouseMove);
            // 
            // PBFrontalView
            // 
            this.PBFrontalView.Location = new System.Drawing.Point(639, 402);
            this.PBFrontalView.Name = "PBFrontalView";
            this.PBFrontalView.Size = new System.Drawing.Size(100, 50);
            this.PBFrontalView.TabIndex = 3;
            this.PBFrontalView.TabStop = false;
            // 
            // PBLateralView
            // 
            this.PBLateralView.Location = new System.Drawing.Point(639, 335);
            this.PBLateralView.Name = "PBLateralView";
            this.PBLateralView.Size = new System.Drawing.Size(100, 50);
            this.PBLateralView.TabIndex = 4;
            this.PBLateralView.TabStop = false;
            // 
            // PBPlantView
            // 
            this.PBPlantView.Location = new System.Drawing.Point(639, 264);
            this.PBPlantView.Name = "PBPlantView";
            this.PBPlantView.Size = new System.Drawing.Size(100, 50);
            this.PBPlantView.TabIndex = 5;
            this.PBPlantView.TabStop = false;
            // 
            // labelMaterial
            // 
            this.labelMaterial.AutoSize = true;
            this.labelMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            this.labelMaterial.Location = new System.Drawing.Point(713, 9);
            this.labelMaterial.Name = "labelMaterial";
            this.labelMaterial.Size = new System.Drawing.Size(38, 15);
            this.labelMaterial.TabIndex = 6;
            this.labelMaterial.Text = "label1";
            // 
            // labelAmbient
            // 
            this.labelAmbient.AutoSize = true;
            this.labelAmbient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.labelAmbient.Location = new System.Drawing.Point(713, 26);
            this.labelAmbient.Name = "labelAmbient";
            this.labelAmbient.Size = new System.Drawing.Size(38, 15);
            this.labelAmbient.TabIndex = 7;
            this.labelAmbient.Text = "label1";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(957, 585);
            this.Controls.Add(this.labelAmbient);
            this.Controls.Add(this.labelMaterial);
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
        private Label labelMaterial;
        private Label labelAmbient;
    }
}