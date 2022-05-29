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
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(987, 634);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Object3dPB);
            this.Name = "MainView";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Object3dPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox Object3dPB;
        private Button button1;
    }
}