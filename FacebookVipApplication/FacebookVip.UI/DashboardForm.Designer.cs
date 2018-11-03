namespace FacebookVip.UI
{
    partial class DashboardForm
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
            this.customHeaderPictureBox = new System.Windows.Forms.PictureBox();
            this.headerTitleLabel = new System.Windows.Forms.Label();
            this.headerFacebookLabel = new System.Windows.Forms.Label();
            this.logoInsideOutImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.customHeaderPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoInsideOutImage)).BeginInit();
            this.SuspendLayout();
            // 
            // customHeaderPictureBox
            // 
            this.customHeaderPictureBox.BackColor = System.Drawing.Color.Gold;
            this.customHeaderPictureBox.Location = new System.Drawing.Point(-1, 0);
            this.customHeaderPictureBox.Name = "customHeaderPictureBox";
            this.customHeaderPictureBox.Size = new System.Drawing.Size(801, 50);
            this.customHeaderPictureBox.TabIndex = 0;
            this.customHeaderPictureBox.TabStop = false;
            // 
            // headerTitleLabel
            // 
            this.headerTitleLabel.AutoSize = true;
            this.headerTitleLabel.BackColor = System.Drawing.Color.Gold;
            this.headerTitleLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.headerTitleLabel.Location = new System.Drawing.Point(161, 16);
            this.headerTitleLabel.Name = "headerTitleLabel";
            this.headerTitleLabel.Size = new System.Drawing.Size(164, 27);
            this.headerTitleLabel.TabIndex = 1;
            this.headerTitleLabel.Text = "vip dashboard";
            // 
            // headerFacebookLabel
            // 
            this.headerFacebookLabel.AutoSize = true;
            this.headerFacebookLabel.BackColor = System.Drawing.Color.Gold;
            this.headerFacebookLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.headerFacebookLabel.Location = new System.Drawing.Point(48, 14);
            this.headerFacebookLabel.Name = "headerFacebookLabel";
            this.headerFacebookLabel.Size = new System.Drawing.Size(118, 29);
            this.headerFacebookLabel.TabIndex = 2;
            this.headerFacebookLabel.Text = "facebook";
            // 
            // logoInsideOutImage
            // 
            this.logoInsideOutImage.BackColor = System.Drawing.Color.Gold;
            this.logoInsideOutImage.Image = global::FacebookVip.UI.Properties.Resources.logo_inside_out;
            this.logoInsideOutImage.Location = new System.Drawing.Point(12, 10);
            this.logoInsideOutImage.Name = "logoInsideOutImage";
            this.logoInsideOutImage.Size = new System.Drawing.Size(32, 32);
            this.logoInsideOutImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoInsideOutImage.TabIndex = 3;
            this.logoInsideOutImage.TabStop = false;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logoInsideOutImage);
            this.Controls.Add(this.headerFacebookLabel);
            this.Controls.Add(this.headerTitleLabel);
            this.Controls.Add(this.customHeaderPictureBox);
            this.Name = "DashboardForm";
            ((System.ComponentModel.ISupportInitialize)(this.customHeaderPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoInsideOutImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox customHeaderPictureBox;
        private System.Windows.Forms.Label headerTitleLabel;
        private System.Windows.Forms.Label headerFacebookLabel;
        private System.Windows.Forms.PictureBox logoInsideOutImage;
    }
}

