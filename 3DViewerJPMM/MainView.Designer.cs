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
<<<<<<< HEAD
            this.LoadObjectBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.LoadObjectBtn.Location = new System.Drawing.Point(0, 514);
            this.LoadObjectBtn.Name = "LoadObjectBtn";
            this.LoadObjectBtn.Size = new System.Drawing.Size(200, 29);
            this.LoadObjectBtn.TabIndex = 0;
            this.LoadObjectBtn.Text = "Carregar Objeto";
            this.LoadObjectBtn.UseVisualStyleBackColor = false;
            this.LoadObjectBtn.Click += new System.EventHandler(this.LoadObjectBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.LoadObjectBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(735, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 543);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 92);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(717, 423);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
=======
            this.Object3dPB = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Object3dPB)).BeginInit();
            this.SuspendLayout();
            // 
            // Object3dPB
            // 
            this.Object3dPB.BackColor = System.Drawing.SystemColors.WindowText;
            this.Object3dPB.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Object3dPB.Location = new System.Drawing.Point(43, 131);
            this.Object3dPB.Name = "Object3dPB";
            this.Object3dPB.Size = new System.Drawing.Size(909, 479);
            this.Object3dPB.TabIndex = 0;
            this.Object3dPB.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(841, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open Object";
            this.button1.UseVisualStyleBackColor = true;
>>>>>>> bbf9611bd8ac367d2642a2bb7ae5c41b3fac2b64
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(935, 543);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
=======
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(987, 634);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Object3dPB);
>>>>>>> bbf9611bd8ac367d2642a2bb7ae5c41b3fac2b64
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3D";
            this.Load += new System.EventHandler(this.MainView_Load);
<<<<<<< HEAD
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
=======
            ((System.ComponentModel.ISupportInitialize)(this.Object3dPB)).EndInit();
>>>>>>> bbf9611bd8ac367d2642a2bb7ae5c41b3fac2b64
            this.ResumeLayout(false);

        }

        #endregion

<<<<<<< HEAD
        private Button LoadObjectBtn;
        private Panel panel1;
        private PictureBox pictureBox1;
=======
        private PictureBox Object3dPB;
        private Button button1;
>>>>>>> bbf9611bd8ac367d2642a2bb7ae5c41b3fac2b64
    }
}