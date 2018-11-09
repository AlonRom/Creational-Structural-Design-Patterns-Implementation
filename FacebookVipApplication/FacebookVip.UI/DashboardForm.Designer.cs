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
            this.headerTitleLabel = new System.Windows.Forms.Label();
            this.headerFacebookLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.loginLabel = new System.Windows.Forms.Label();
            this.statsButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.likesButton = new System.Windows.Forms.Button();
            this.checkinsButton = new System.Windows.Forms.Button();
            this.eventsButton = new System.Windows.Forms.Button();
            this.postsButton = new System.Windows.Forms.Button();
            this.friendsButton = new System.Windows.Forms.Button();
            this.profileButton = new System.Windows.Forms.Button();
            this.spinner = new System.Windows.Forms.PictureBox();
            this.logoInsideOutImage = new System.Windows.Forms.PictureBox();
            this.customHeaderPictureBox = new System.Windows.Forms.PictureBox();
            this.userImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.spinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoInsideOutImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customHeaderPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).BeginInit();
            this.SuspendLayout();
            // 
            // headerTitleLabel
            // 
            this.headerTitleLabel.AutoSize = true;
            this.headerTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerTitleLabel.Font = new System.Drawing.Font("Segoe Print", 20F);
            this.headerTitleLabel.Location = new System.Drawing.Point(158, 3);
            this.headerTitleLabel.Name = "headerTitleLabel";
            this.headerTitleLabel.Size = new System.Drawing.Size(212, 47);
            this.headerTitleLabel.TabIndex = 1;
            this.headerTitleLabel.Text = "vip dashboard";
            // 
            // headerFacebookLabel
            // 
            this.headerFacebookLabel.AutoSize = true;
            this.headerFacebookLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerFacebookLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.headerFacebookLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.headerFacebookLabel.Location = new System.Drawing.Point(48, 14);
            this.headerFacebookLabel.Name = "headerFacebookLabel";
            this.headerFacebookLabel.Size = new System.Drawing.Size(118, 29);
            this.headerFacebookLabel.TabIndex = 2;
            this.headerFacebookLabel.Text = "facebook";
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Location = new System.Drawing.Point(210, 60);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(800, 600);
            this.contentPanel.TabIndex = 5;
            this.contentPanel.Visible = false;
            // 
            // loginLabel
            // 
            this.loginLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loginLabel.AutoSize = true;
            this.loginLabel.BackColor = System.Drawing.Color.Transparent;
            this.loginLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.loginLabel.Location = new System.Drawing.Point(735, 16);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(53, 19);
            this.loginLabel.TabIndex = 38;
            this.loginLabel.Text = "Login";
            this.loginLabel.Click += new System.EventHandler(this.loginButtonClick);
            // 
            // statsButton
            // 
            this.statsButton.BackColor = System.Drawing.Color.Transparent;
            this.statsButton.BackgroundImage = global::FacebookVip.UI.Properties.Resources.statistics;
            this.statsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.statsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.statsButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.statsButton.FlatAppearance.BorderSize = 0;
            this.statsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.statsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.statsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statsButton.Location = new System.Drawing.Point(12, 322);
            this.statsButton.Name = "statsButton";
            this.statsButton.Size = new System.Drawing.Size(190, 40);
            this.statsButton.TabIndex = 13;
            this.statsButton.Text = "Stats";
            this.statsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.statsButton.UseVisualStyleBackColor = false;
            this.statsButton.Visible = false;
            this.statsButton.Click += new System.EventHandler(this.statsButtonClick);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.Transparent;
            this.settingsButton.BackgroundImage = global::FacebookVip.UI.Properties.Resources.settings;
            this.settingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.settingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.settingsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.Location = new System.Drawing.Point(12, 368);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(190, 40);
            this.settingsButton.TabIndex = 12;
            this.settingsButton.Text = "Settings";
            this.settingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Visible = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButtonClick);
            // 
            // likesButton
            // 
            this.likesButton.BackColor = System.Drawing.Color.Transparent;
            this.likesButton.BackgroundImage = global::FacebookVip.UI.Properties.Resources.like;
            this.likesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.likesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.likesButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.likesButton.FlatAppearance.BorderSize = 0;
            this.likesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.likesButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.likesButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.likesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.likesButton.Location = new System.Drawing.Point(12, 233);
            this.likesButton.Name = "likesButton";
            this.likesButton.Size = new System.Drawing.Size(190, 40);
            this.likesButton.TabIndex = 11;
            this.likesButton.Text = "Likes";
            this.likesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.likesButton.UseVisualStyleBackColor = false;
            this.likesButton.Visible = false;
            this.likesButton.Click += new System.EventHandler(this.likesButtonClick);
            // 
            // checkinsButton
            // 
            this.checkinsButton.BackColor = System.Drawing.Color.Transparent;
            this.checkinsButton.BackgroundImage = global::FacebookVip.UI.Properties.Resources.checkin;
            this.checkinsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.checkinsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkinsButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.checkinsButton.FlatAppearance.BorderSize = 0;
            this.checkinsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkinsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkinsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkinsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkinsButton.Location = new System.Drawing.Point(12, 276);
            this.checkinsButton.Name = "checkinsButton";
            this.checkinsButton.Size = new System.Drawing.Size(190, 40);
            this.checkinsButton.TabIndex = 10;
            this.checkinsButton.Text = "Checkins";
            this.checkinsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkinsButton.UseVisualStyleBackColor = false;
            this.checkinsButton.Visible = false;
            this.checkinsButton.Click += new System.EventHandler(this.checkinsButtonClick);
            // 
            // eventsButton
            // 
            this.eventsButton.BackColor = System.Drawing.Color.Transparent;
            this.eventsButton.BackgroundImage = global::FacebookVip.UI.Properties.Resources.events;
            this.eventsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.eventsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eventsButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.eventsButton.FlatAppearance.BorderSize = 0;
            this.eventsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eventsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.eventsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.eventsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.eventsButton.Location = new System.Drawing.Point(12, 190);
            this.eventsButton.Name = "eventsButton";
            this.eventsButton.Size = new System.Drawing.Size(190, 40);
            this.eventsButton.TabIndex = 9;
            this.eventsButton.Text = "Events";
            this.eventsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.eventsButton.UseVisualStyleBackColor = false;
            this.eventsButton.Visible = false;
            this.eventsButton.Click += new System.EventHandler(this.eventsButtonClick);
            // 
            // postsButton
            // 
            this.postsButton.BackColor = System.Drawing.Color.Transparent;
            this.postsButton.BackgroundImage = global::FacebookVip.UI.Properties.Resources.pencil;
            this.postsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.postsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.postsButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.postsButton.FlatAppearance.BorderSize = 0;
            this.postsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.postsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.postsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.postsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.postsButton.Location = new System.Drawing.Point(12, 147);
            this.postsButton.Name = "postsButton";
            this.postsButton.Size = new System.Drawing.Size(190, 40);
            this.postsButton.TabIndex = 8;
            this.postsButton.Text = "Posts";
            this.postsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.postsButton.UseVisualStyleBackColor = false;
            this.postsButton.Visible = false;
            this.postsButton.Click += new System.EventHandler(this.postsButtonClick);
            // 
            // friendsButton
            // 
            this.friendsButton.BackColor = System.Drawing.Color.Transparent;
            this.friendsButton.BackgroundImage = global::FacebookVip.UI.Properties.Resources.friends;
            this.friendsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.friendsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.friendsButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.friendsButton.FlatAppearance.BorderSize = 0;
            this.friendsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.friendsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.friendsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.friendsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.friendsButton.Location = new System.Drawing.Point(12, 104);
            this.friendsButton.Name = "friendsButton";
            this.friendsButton.Size = new System.Drawing.Size(190, 40);
            this.friendsButton.TabIndex = 7;
            this.friendsButton.Text = "Friends";
            this.friendsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.friendsButton.UseVisualStyleBackColor = false;
            this.friendsButton.Visible = false;
            this.friendsButton.Click += new System.EventHandler(this.friendsButtonClick);
            // 
            // profileButton
            // 
            this.profileButton.BackColor = System.Drawing.Color.Transparent;
            this.profileButton.BackgroundImage = global::FacebookVip.UI.Properties.Resources.profile;
            this.profileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.profileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.profileButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.profileButton.FlatAppearance.BorderSize = 0;
            this.profileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profileButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.profileButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.profileButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.profileButton.Location = new System.Drawing.Point(12, 61);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(190, 40);
            this.profileButton.TabIndex = 6;
            this.profileButton.Text = "Profile";
            this.profileButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.profileButton.UseVisualStyleBackColor = false;
            this.profileButton.Visible = false;
            this.profileButton.Click += new System.EventHandler(this.profileButtonClick);
            // 
            // spinner
            // 
            this.spinner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.spinner.Image = global::FacebookVip.UI.Properties.Resources.Spinner;
            this.spinner.Location = new System.Drawing.Point(53, 414);
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(148, 148);
            this.spinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.spinner.TabIndex = 0;
            this.spinner.TabStop = false;
            // 
            // logoInsideOutImage
            // 
            this.logoInsideOutImage.BackColor = System.Drawing.Color.Transparent;
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
            this.customHeaderPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.customHeaderPictureBox.BackgroundImage = global::FacebookVip.UI.Properties.Resources.gold;
            this.customHeaderPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.customHeaderPictureBox.Location = new System.Drawing.Point(-1, 0);
            this.customHeaderPictureBox.Name = "customHeaderPictureBox";
            this.customHeaderPictureBox.Size = new System.Drawing.Size(801, 60);
            this.customHeaderPictureBox.TabIndex = 0;
            this.customHeaderPictureBox.TabStop = false;
            // 
            // userImage
            // 
            this.userImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userImage.BackColor = System.Drawing.Color.Transparent;
            this.userImage.Location = new System.Drawing.Point(694, 5);
            this.userImage.Name = "userImage";
            this.userImage.Size = new System.Drawing.Size(24, 24);
            this.userImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.userImage.TabIndex = 39;
            this.userImage.TabStop = false;
            this.userImage.Visible = false;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 537);
            this.Controls.Add(this.userImage);
            this.Controls.Add(this.spinner);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.statsButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.likesButton);
            this.Controls.Add(this.checkinsButton);
            this.Controls.Add(this.eventsButton);
            this.Controls.Add(this.postsButton);
            this.Controls.Add(this.friendsButton);
            this.Controls.Add(this.profileButton);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.logoInsideOutImage);
            this.Controls.Add(this.headerFacebookLabel);
            this.Controls.Add(this.headerTitleLabel);
            this.Controls.Add(this.customHeaderPictureBox);
            this.Name = "DashboardForm";
            this.Click += new System.EventHandler(this.loginButtonClick);
            ((System.ComponentModel.ISupportInitialize)(this.spinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoInsideOutImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customHeaderPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox customHeaderPictureBox;
        private System.Windows.Forms.Label headerTitleLabel;
        private System.Windows.Forms.Label headerFacebookLabel;
        private System.Windows.Forms.PictureBox logoInsideOutImage;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.PictureBox spinner;
        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.Button friendsButton;
        private System.Windows.Forms.Button postsButton;
        private System.Windows.Forms.Button eventsButton;
        private System.Windows.Forms.Button checkinsButton;
        private System.Windows.Forms.Button likesButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button statsButton;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.PictureBox userImage;
    }
}

