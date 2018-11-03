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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Operation 1"}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.Control, new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177))));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Operation 2");
            this.headerTitleLabel = new System.Windows.Forms.Label();
            this.headerFacebookLabel = new System.Windows.Forms.Label();
            this.SideMenuColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SideMenuListView = new System.Windows.Forms.ListView();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.Spinner = new System.Windows.Forms.PictureBox();
            this.logoInsideOutImage = new System.Windows.Forms.PictureBox();
            this.customHeaderPictureBox = new System.Windows.Forms.PictureBox();
            this.ContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoInsideOutImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customHeaderPictureBox)).BeginInit();
            this.SuspendLayout();
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
            // SideMenuListView
            // 
            this.SideMenuListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.SideMenuListView.BackColor = System.Drawing.SystemColors.Control;
            this.SideMenuListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SideMenuListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SideMenuColumn});
            this.SideMenuListView.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SideMenuListView.FullRowSelect = true;
            this.SideMenuListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.SideMenuListView.Location = new System.Drawing.Point(10, 60);
            this.SideMenuListView.Name = "SideMenuListView";
            this.SideMenuListView.Scrollable = false;
            this.SideMenuListView.Size = new System.Drawing.Size(189, 391);
            this.SideMenuListView.TabIndex = 4;
            this.SideMenuListView.UseCompatibleStateImageBehavior = false;
            this.SideMenuListView.View = System.Windows.Forms.View.Tile;
            this.SideMenuListView.SelectedIndexChanged += new System.EventHandler(this.sideMenuListViewSelectedIndexChanged);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.Spinner);
            this.ContentPanel.Location = new System.Drawing.Point(193, 57);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(595, 381);
            this.ContentPanel.TabIndex = 5;
            // 
            // Spinner
            // 
            this.Spinner.Image = global::FacebookVip.UI.Properties.Resources.Spinner;
            this.Spinner.Location = new System.Drawing.Point(222, 94);
            this.Spinner.Name = "Spinner";
            this.Spinner.Size = new System.Drawing.Size(148, 155);
            this.Spinner.TabIndex = 0;
            this.Spinner.TabStop = false;
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
            // customHeaderPictureBox
            // 
            this.customHeaderPictureBox.BackColor = System.Drawing.Color.Gold;
            this.customHeaderPictureBox.Location = new System.Drawing.Point(-1, 0);
            this.customHeaderPictureBox.Name = "customHeaderPictureBox";
            this.customHeaderPictureBox.Size = new System.Drawing.Size(801, 50);
            this.customHeaderPictureBox.TabIndex = 0;
            this.customHeaderPictureBox.TabStop = false;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.SideMenuListView);
            this.Controls.Add(this.logoInsideOutImage);
            this.Controls.Add(this.headerFacebookLabel);
            this.Controls.Add(this.headerTitleLabel);
            this.Controls.Add(this.customHeaderPictureBox);
            this.Name = "DashboardForm";
            this.ContentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Spinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoInsideOutImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customHeaderPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox customHeaderPictureBox;
        private System.Windows.Forms.Label headerTitleLabel;
        private System.Windows.Forms.Label headerFacebookLabel;
        private System.Windows.Forms.PictureBox logoInsideOutImage;
        private System.Windows.Forms.ColumnHeader SideMenuColumn;
        private System.Windows.Forms.ListView SideMenuListView;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.PictureBox Spinner;
    }
}

