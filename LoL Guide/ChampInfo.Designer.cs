namespace LoL_Guide
{
    partial class ChampInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SampiyonFoto = new System.Windows.Forms.PictureBox();
            this.SampiyonRune = new System.Windows.Forms.PictureBox();
            this.SampiyonKostum = new System.Windows.Forms.PictureBox();
            this.SkillSet = new System.Windows.Forms.PictureBox();
            this.Build = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SampiyonFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampiyonRune)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampiyonKostum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkillSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Build)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Akali";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SampiyonFoto
            // 
            this.SampiyonFoto.Location = new System.Drawing.Point(15, 44);
            this.SampiyonFoto.Name = "SampiyonFoto";
            this.SampiyonFoto.Size = new System.Drawing.Size(149, 243);
            this.SampiyonFoto.TabIndex = 1;
            this.SampiyonFoto.TabStop = false;
            // 
            // SampiyonRune
            // 
            this.SampiyonRune.Location = new System.Drawing.Point(375, 44);
            this.SampiyonRune.Name = "SampiyonRune";
            this.SampiyonRune.Size = new System.Drawing.Size(390, 243);
            this.SampiyonRune.TabIndex = 3;
            this.SampiyonRune.TabStop = false;
            // 
            // SampiyonKostum
            // 
            this.SampiyonKostum.Location = new System.Drawing.Point(196, 44);
            this.SampiyonKostum.Name = "SampiyonKostum";
            this.SampiyonKostum.Size = new System.Drawing.Size(149, 243);
            this.SampiyonKostum.TabIndex = 4;
            this.SampiyonKostum.TabStop = false;
            // 
            // SkillSet
            // 
            this.SkillSet.Location = new System.Drawing.Point(17, 309);
            this.SkillSet.Name = "SkillSet";
            this.SkillSet.Size = new System.Drawing.Size(336, 135);
            this.SkillSet.TabIndex = 5;
            this.SkillSet.TabStop = false;
            // 
            // Build
            // 
            this.Build.Location = new System.Drawing.Point(375, 309);
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(390, 135);
            this.Build.TabIndex = 6;
            this.Build.TabStop = false;
            // 
            // ChampInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Build);
            this.Controls.Add(this.SkillSet);
            this.Controls.Add(this.SampiyonKostum);
            this.Controls.Add(this.SampiyonRune);
            this.Controls.Add(this.SampiyonFoto);
            this.Controls.Add(this.label1);
            this.Name = "ChampInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChampInfo";
            this.Load += new System.EventHandler(this.ChampInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SampiyonFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampiyonRune)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampiyonKostum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkillSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Build)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox SampiyonFoto;
        private System.Windows.Forms.PictureBox SampiyonRune;
        private System.Windows.Forms.PictureBox SampiyonKostum;
        private System.Windows.Forms.PictureBox SkillSet;
        private System.Windows.Forms.PictureBox Build;
    }
}