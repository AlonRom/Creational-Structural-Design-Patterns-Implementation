namespace FacebookVip.UI
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label birthdayLabel;
            System.Windows.Forms.Label emailLabel;
            this.headerTitleLabel = new System.Windows.Forms.Label();
            this.headerFacebookLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.friendsDataBindingContentPanel = new System.Windows.Forms.Panel();
            this.friendDetailsPanel = new System.Windows.Forms.Panel();
            this.membersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.friendListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.friendsListBox = new System.Windows.Forms.ListBox();
            this.contentSpinner = new System.Windows.Forms.PictureBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.statsButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.likesButton = new System.Windows.Forms.Button();
            this.checkinsButton = new System.Windows.Forms.Button();
            this.eventsButton = new System.Windows.Forms.Button();
            this.postsButton = new System.Windows.Forms.Button();
            this.friendsButton = new System.Windows.Forms.Button();
            this.profileButton = new System.Windows.Forms.Button();
            this.logoInsideOutImage = new System.Windows.Forms.PictureBox();
            this.customHeaderPictureBox = new System.Windows.Forms.PictureBox();
            this.userImage = new System.Windows.Forms.PictureBox();
            this.loginSpinner = new System.Windows.Forms.PictureBox();
            this.StayLoggedInLabel = new System.Windows.Forms.CheckBox();
            this.dataBindinFriendsButton = new System.Windows.Forms.Button();
            this.idLabel1 = new System.Windows.Forms.Label();
            this.nameLabel1 = new System.Windows.Forms.Label();
            this.birthdayLabel1 = new System.Windows.Forms.Label();
            this.emailLabel1 = new System.Windows.Forms.Label();
            this.imageSquarePictureBox = new System.Windows.Forms.PictureBox();
            idLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            birthdayLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            this.contentPanel.SuspendLayout();
            this.friendsDataBindingContentPanel.SuspendLayout();
            this.friendDetailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.membersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoInsideOutImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customHeaderPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSquarePictureBox)).BeginInit();
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
            this.contentPanel.Controls.Add(this.friendsDataBindingContentPanel);
            this.contentPanel.Controls.Add(this.contentSpinner);
            this.contentPanel.Location = new System.Drawing.Point(210, 66);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(800, 680);
            this.contentPanel.TabIndex = 5;
            this.contentPanel.Visible = false;
            // 
            // friendsDataBindingContentPanel
            // 
            this.friendsDataBindingContentPanel.BackColor = System.Drawing.Color.White;
            this.friendsDataBindingContentPanel.Controls.Add(this.friendDetailsPanel);
            this.friendsDataBindingContentPanel.Controls.Add(this.label2);
            this.friendsDataBindingContentPanel.Controls.Add(this.label1);
            this.friendsDataBindingContentPanel.Controls.Add(this.friendsListBox);
            this.friendsDataBindingContentPanel.Location = new System.Drawing.Point(-1, 1);
            this.friendsDataBindingContentPanel.Name = "friendsDataBindingContentPanel";
            this.friendsDataBindingContentPanel.Size = new System.Drawing.Size(729, 609);
            this.friendsDataBindingContentPanel.TabIndex = 1;
            this.friendsDataBindingContentPanel.Visible = false;
            // 
            // friendDetailsPanel
            // 
            this.friendDetailsPanel.Controls.Add(this.imageSquarePictureBox);
            this.friendDetailsPanel.Controls.Add(emailLabel);
            this.friendDetailsPanel.Controls.Add(this.emailLabel1);
            this.friendDetailsPanel.Controls.Add(birthdayLabel);
            this.friendDetailsPanel.Controls.Add(this.birthdayLabel1);
            this.friendDetailsPanel.Controls.Add(idLabel);
            this.friendDetailsPanel.Controls.Add(this.idLabel1);
            this.friendDetailsPanel.Controls.Add(nameLabel);
            this.friendDetailsPanel.Controls.Add(this.nameLabel1);
            this.friendDetailsPanel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.friendDetailsPanel.Location = new System.Drawing.Point(311, 54);
            this.friendDetailsPanel.Name = "friendDetailsPanel";
            this.friendDetailsPanel.Size = new System.Drawing.Size(319, 336);
            this.friendDetailsPanel.TabIndex = 4;
            // 
            // membersBindingSource
            // 
            this.membersBindingSource.DataMember = "Members";
            this.membersBindingSource.DataSource = this.friendListBindingSource;
            // 
            // friendListBindingSource
            // 
            this.friendListBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.FriendList);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(304, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Friend Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "My Friends";
            // 
            // friendsListBox
            // 
            this.friendsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.friendsListBox.DataSource = this.friendListBindingSource;
            this.friendsListBox.DisplayMember = "Name";
            this.friendsListBox.Font = new System.Drawing.Font("Arial", 9.75F);
            this.friendsListBox.FormattingEnabled = true;
            this.friendsListBox.ItemHeight = 16;
            this.friendsListBox.Location = new System.Drawing.Point(21, 54);
            this.friendsListBox.Name = "friendsListBox";
            this.friendsListBox.Size = new System.Drawing.Size(249, 320);
            this.friendsListBox.TabIndex = 0;
            // 
            // contentSpinner
            // 
            this.contentSpinner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.contentSpinner.BackColor = System.Drawing.Color.White;
            this.contentSpinner.Image = global::FacebookVip.UI.Properties.Resources.Spinner;
            this.contentSpinner.Location = new System.Drawing.Point(199, 210);
            this.contentSpinner.Name = "contentSpinner";
            this.contentSpinner.Size = new System.Drawing.Size(148, 148);
            this.contentSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.contentSpinner.TabIndex = 0;
            this.contentSpinner.TabStop = false;
            // 
            // loginLabel
            // 
            this.loginLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loginLabel.AutoSize = true;
            this.loginLabel.BackColor = System.Drawing.Color.Transparent;
            this.loginLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.loginLabel.Location = new System.Drawing.Point(910, 14);
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
            this.friendsButton.Click += new System.EventHandler(this.friendsButtonClickAsync);
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
            this.profileButton.Click += new System.EventHandler(this.profileButtonClickAsync);
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
            this.userImage.Location = new System.Drawing.Point(869, 3);
            this.userImage.Name = "userImage";
            this.userImage.Size = new System.Drawing.Size(24, 24);
            this.userImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.userImage.TabIndex = 39;
            this.userImage.TabStop = false;
            this.userImage.Visible = false;
            // 
            // loginSpinner
            // 
            this.loginSpinner.BackColor = System.Drawing.Color.Transparent;
            this.loginSpinner.Image = global::FacebookVip.UI.Properties.Resources.Spinner;
            this.loginSpinner.Location = new System.Drawing.Point(366, -27);
            this.loginSpinner.Name = "loginSpinner";
            this.loginSpinner.Size = new System.Drawing.Size(113, 114);
            this.loginSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loginSpinner.TabIndex = 40;
            this.loginSpinner.TabStop = false;
            // 
            // StayLoggedInLabel
            // 
            this.StayLoggedInLabel.AutoSize = true;
            this.StayLoggedInLabel.BackColor = System.Drawing.Color.Transparent;
            this.StayLoggedInLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.StayLoggedInLabel.Location = new System.Drawing.Point(520, 14);
            this.StayLoggedInLabel.Name = "StayLoggedInLabel";
            this.StayLoggedInLabel.Size = new System.Drawing.Size(143, 23);
            this.StayLoggedInLabel.TabIndex = 41;
            this.StayLoggedInLabel.Text = "Stay Logged In";
            this.StayLoggedInLabel.UseVisualStyleBackColor = false;
            this.StayLoggedInLabel.CheckedChanged += new System.EventHandler(this.stayLogedInCheckedChanged);
            // 
            // dataBindinFriendsButton
            // 
            this.dataBindinFriendsButton.BackColor = System.Drawing.Color.Transparent;
            this.dataBindinFriendsButton.BackgroundImage = global::FacebookVip.UI.Properties.Resources.friends;
            this.dataBindinFriendsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dataBindinFriendsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataBindinFriendsButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.dataBindinFriendsButton.FlatAppearance.BorderSize = 0;
            this.dataBindinFriendsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataBindinFriendsButton.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.dataBindinFriendsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dataBindinFriendsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dataBindinFriendsButton.Location = new System.Drawing.Point(12, 414);
            this.dataBindinFriendsButton.Name = "dataBindinFriendsButton";
            this.dataBindinFriendsButton.Size = new System.Drawing.Size(190, 40);
            this.dataBindinFriendsButton.TabIndex = 42;
            this.dataBindinFriendsButton.Text = "Friends with\r\nData Binding";
            this.dataBindinFriendsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dataBindinFriendsButton.UseVisualStyleBackColor = false;
            this.dataBindinFriendsButton.Visible = false;
            this.dataBindinFriendsButton.Click += new System.EventHandler(this.dataBindinFriendsButtonClick);
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(17, 19);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(22, 16);
            idLabel.TabIndex = 0;
            idLabel.Text = "Id:";
            // 
            // idLabel1
            // 
            this.idLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.friendListBindingSource, "Id", true));
            this.idLabel1.Location = new System.Drawing.Point(69, 19);
            this.idLabel1.Name = "idLabel1";
            this.idLabel1.Size = new System.Drawing.Size(100, 23);
            this.idLabel1.TabIndex = 1;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(17, 43);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(46, 16);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Name:";
            // 
            // nameLabel1
            // 
            this.nameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.friendListBindingSource, "Name", true));
            this.nameLabel1.Location = new System.Drawing.Point(69, 42);
            this.nameLabel1.Name = "nameLabel1";
            this.nameLabel1.Size = new System.Drawing.Size(100, 23);
            this.nameLabel1.TabIndex = 3;
            // 
            // birthdayLabel
            // 
            birthdayLabel.AutoSize = true;
            birthdayLabel.Location = new System.Drawing.Point(16, 68);
            birthdayLabel.Name = "birthdayLabel";
            birthdayLabel.Size = new System.Drawing.Size(60, 16);
            birthdayLabel.TabIndex = 4;
            birthdayLabel.Text = "Birthday:";
            // 
            // birthdayLabel1
            // 
            this.birthdayLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.membersBindingSource, "Birthday", true));
            this.birthdayLabel1.Location = new System.Drawing.Point(82, 69);
            this.birthdayLabel1.Name = "birthdayLabel1";
            this.birthdayLabel1.Size = new System.Drawing.Size(100, 23);
            this.birthdayLabel1.TabIndex = 5;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(17, 94);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(45, 16);
            emailLabel.TabIndex = 6;
            emailLabel.Text = "Email:";
            // 
            // emailLabel1
            // 
            this.emailLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.membersBindingSource, "Email", true));
            this.emailLabel1.Location = new System.Drawing.Point(73, 95);
            this.emailLabel1.Name = "emailLabel1";
            this.emailLabel1.Size = new System.Drawing.Size(100, 23);
            this.emailLabel1.TabIndex = 7;
            // 
            // imageSquarePictureBox
            // 
            this.imageSquarePictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.membersBindingSource, "ImageSquare", true));
            this.imageSquarePictureBox.Location = new System.Drawing.Point(204, 15);
            this.imageSquarePictureBox.Name = "imageSquarePictureBox";
            this.imageSquarePictureBox.Size = new System.Drawing.Size(100, 50);
            this.imageSquarePictureBox.TabIndex = 9;
            this.imageSquarePictureBox.TabStop = false;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1010, 746);
            this.Controls.Add(this.dataBindinFriendsButton);
            this.Controls.Add(this.StayLoggedInLabel);
            this.Controls.Add(this.loginSpinner);
            this.Controls.Add(this.userImage);
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
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.friendsDataBindingContentPanel.ResumeLayout(false);
            this.friendsDataBindingContentPanel.PerformLayout();
            this.friendDetailsPanel.ResumeLayout(false);
            this.friendDetailsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.membersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoInsideOutImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customHeaderPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSquarePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox customHeaderPictureBox;
        private System.Windows.Forms.Label headerTitleLabel;
        private System.Windows.Forms.Label headerFacebookLabel;
        private System.Windows.Forms.PictureBox logoInsideOutImage;
        private System.Windows.Forms.Panel contentPanel;
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
        private System.Windows.Forms.PictureBox contentSpinner;
        private System.Windows.Forms.PictureBox loginSpinner;
        private System.Windows.Forms.CheckBox StayLoggedInLabel;
        private System.Windows.Forms.Button dataBindinFriendsButton;
        private System.Windows.Forms.Panel friendsDataBindingContentPanel;
        private System.Windows.Forms.ListBox friendsListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel friendDetailsPanel;
        private System.Windows.Forms.BindingSource friendListBindingSource;
        private System.Windows.Forms.BindingSource membersBindingSource;
        private System.Windows.Forms.PictureBox imageSquarePictureBox;
        private System.Windows.Forms.Label emailLabel1;
        private System.Windows.Forms.Label birthdayLabel1;
        private System.Windows.Forms.Label idLabel1;
        private System.Windows.Forms.Label nameLabel1;
    }
}

