using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FacebookVip.Logic.Extensions;
using FacebookVip.Logic.Interfaces;
using FacebookVip.Logic.Services;
using FacebookVip.Model.Enums;
using FacebookVip.Model.Models;
using FacebookVip.UI.FormControls;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.UI
{

    public partial class DashboardForm : Form
    {
        private readonly ILoginService r_LoginService;

        TableLayoutPanel m_Panel;

        public DashboardForm()
        {
            InitializeComponent();
            setFormStyle();
            registerEvents();

            r_LoginService = LoginService.GetInstance();
        }

        private void registerEvents()
        {
            Resize += resizeFormEvent;
        }

        private void setFormStyle()
        {
            setFormSize(); 
            CenterToScreen();
            customHeaderLayout();
            loginSpinner.Visible = false;
            contentSpinner.Visible = false;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void setFormSize()
        {
            Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.6);
            Height = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.7);
            customHeaderPictureBox.Width = Screen.GetWorkingArea(this).Width; // make it the same width as the form
        }

        private void resizeFormEvent(object i_Sender, EventArgs i_EventArgs)
        {
            loginLabel.Location = new Point(userImage.Location.X + 50, loginLabel.Location.Y);
        }

        private void centerControlInParent(Control i_Control)
        {
            i_Control.Location = new Point(
                                   i_Control.Parent.ClientSize.Width/2 - i_Control.Width/2,
                                   i_Control.Parent.ClientSize.Height/2 - i_Control.Height/2);

            i_Control.BringToFront();
            i_Control.Refresh();
        }

        private void customHeaderLayout()
        {
            Icon = Properties.Resources.app_logo;

            Point headerFacebookLabelPosition = PointToScreen(headerFacebookLabel.Location);
            headerFacebookLabelPosition = customHeaderPictureBox.PointToClient(headerFacebookLabelPosition);
            headerFacebookLabel.Parent = customHeaderPictureBox;
            headerFacebookLabel.Location = headerFacebookLabelPosition;

            Point headerTitleLabelPosition = PointToScreen(headerTitleLabel.Location);
            headerTitleLabelPosition = customHeaderPictureBox.PointToClient(headerTitleLabelPosition);
            headerTitleLabel.Parent = customHeaderPictureBox;
            headerTitleLabel.Location = headerTitleLabelPosition;

            Point logoInsideOutImagePosition = PointToScreen(logoInsideOutImage.Location);
            logoInsideOutImagePosition = customHeaderPictureBox.PointToClient(logoInsideOutImagePosition);
            logoInsideOutImage.Parent = customHeaderPictureBox;
            logoInsideOutImage.Location = logoInsideOutImagePosition;

            Point loginLabelPosition = PointToScreen(loginLabel.Location);
            loginLabelPosition = customHeaderPictureBox.PointToClient(loginLabelPosition);
            loginLabel.Parent = customHeaderPictureBox;
            loginLabel.Location = loginLabelPosition;

            Point stayLoggedInLabelPosition = PointToScreen(StayLoggedInLabel.Location);
            stayLoggedInLabelPosition = customHeaderPictureBox.PointToClient(stayLoggedInLabelPosition);
            StayLoggedInLabel.Parent = customHeaderPictureBox;
            StayLoggedInLabel.Location = stayLoggedInLabelPosition;

            Point loginSpinnerPosition = PointToScreen(loginSpinner.Location);
            loginSpinnerPosition = customHeaderPictureBox.PointToClient(loginSpinnerPosition);
            loginSpinner.Parent = customHeaderPictureBox;
            loginSpinner.Location = loginSpinnerPosition;
        }

        private void resetContentPanel()
        {
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(contentSpinner);
            centerControlInParent(contentSpinner);
        }

        private void logoutButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                loginLabel.Enabled = false;
                loginSpinner.Visible = true;

                r_LoginService.Logout();
                loginLabel.Click -= logoutButtonClick;
                loginLabel.Click += loginButtonClick;
                loginLabel.Text = @"Login";
                setLayoutVisible(false);
                r_LoginService.LoggedInUser = null;

                AppAppConfigService appAppConfig = AppAppConfigService.GetInstance();
                appAppConfig.LastAccessTocken = "";
            }
            finally
            {
                loginLabel.Enabled = true;
                loginSpinner.Visible = false;
            }
        }

        private void loginButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                loginLabel.Enabled = false;
                loginSpinner.Visible = true;

                LoginResult loginResult = r_LoginService.Login();
  
                //Tocken: EAAUm6cZC4eUEBAFvYpV07wRmWXbUUfCw5clPTu7ZBqnuUVFLpezLBEczeelSSaClNkqGDdIgSsnCSMrFJBBnbrQYfdQJDrZBd59c2VZCCUPdyYplFu06cgX0JqIUBr05ElY5zU3FLNZCmsyfbxZByPtMpOIqUJSWv4ZBytRBlQURgZDZD
                if (!string.IsNullOrEmpty(loginResult.AccessToken))
                {
                    r_LoginService.LoggedInUser = loginResult.LoggedInUser;

                    postLogin();
                }
                else
                {
                    MessageBox.Show(loginResult.ErrorMessage);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Failed to login, please try again.", @"Login Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                loginLabel.Enabled = true;
                loginSpinner.Visible = false;
            }
        }

        private void postLogin()
        {
            setLayoutVisible(true);
            userImage.Visible = true;
            userImage.Image = r_LoginService?.LoggedInUser?.ImageSmall;
            loginLabel.Text = @"Logout";
            loginLabel.Click -= loginButtonClick;
            loginLabel.Click += logoutButtonClick;
        }

        private void setLayoutVisible(bool i_Visible)
        {
            contentPanel.Visible = i_Visible;
            foreach (Button button in Controls.OfType<Button>())
            {
                button.Visible = i_Visible;
            }
            userImage.Visible = i_Visible;
        }

        private async void profileButtonClickAsync(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                contentSpinner.Visible = true;
                resetContentPanel();

                IProfileService profileService = new ProfileService(r_LoginService);
                ProfileModel userPorfile = await profileService.GetUserProfileAsync();

                m_Panel = new TableLayoutPanel { ColumnCount = 2 };
                m_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
                m_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
                m_Panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

                int tempRowIndex = 0;
                const int k_PropertyColumnIndex = 0;
                const int k_DetailsColumnIndex = 1;

                foreach (KeyValuePair<string, string> propertyForDisplay in userPorfile.GetPropertiesForDisplay())
                {
                    m_Panel.Controls.Add(new Label { Font = new Font("Arial", 12, FontStyle.Bold), Text = propertyForDisplay.Key }, k_PropertyColumnIndex, tempRowIndex);
                    m_Panel.Controls.Add(new Label { Font = new Font("Arial", 12), Text = propertyForDisplay.Value }, k_DetailsColumnIndex, tempRowIndex);
                    tempRowIndex++;
                }

                m_Panel.Padding = new Padding(10);
                m_Panel.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(m_Panel);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Failed to retrive data, please try again.", @"Fetch Data Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                contentSpinner.Visible = false;
            }
        }

        private async void friendsButtonClickAsync(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                contentSpinner.Visible = true;
                resetContentPanel();

                IFriendService friendService = new FriendService(r_LoginService);
                List<FriendModel> userFriends = await friendService.GetUserFriendsAsync(); 

                m_Panel = new TableLayoutPanel { ColumnCount = 2, AutoScroll = true};
                m_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 40F));
                m_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 20F));
                m_Panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

                int tempRowIndex = 0;
                const int k_ImageColumnIndex = 0;
                const int k_DetailsColumnIndex = 1;

                foreach(FriendModel friend in userFriends)
                {
                    foreach (KeyValuePair<string, string> propertyForDisplay in friend.GetPropertiesForDisplay())
                    {
                        Uri uriResult;
                        bool isImageUrl = Uri.TryCreate(propertyForDisplay.Value, UriKind.Absolute, out uriResult)
                            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                        if(isImageUrl)
                        {
                            m_Panel.Controls.Add(new PictureBox { ImageLocation = propertyForDisplay.Value }, k_ImageColumnIndex, tempRowIndex);
                        }
                        else
                        {
                            m_Panel.Controls.Add(new Label { Font = new Font("Arial", 12), Text = propertyForDisplay.Value }, k_DetailsColumnIndex, tempRowIndex);
                        }             
                    }
                    tempRowIndex++;
                }

                m_Panel.Padding = new Padding(10);
                m_Panel.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(m_Panel);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Failed to retrive data, please try again.", @"Fetch Data Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                contentSpinner.Visible = false;
            }
        }

        
        private async void postsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                contentSpinner.Visible = true;
                resetContentPanel();
                m_Panel = new TableLayoutPanel { ColumnCount = 1, AutoScroll = true, AutoSize = true };

                IPostService postService = new PostService();
                List<PostModel> userPosts = await postService.GetUserPostsAsync(r_LoginService.LoggedInUser);
                
                int tempRowIndex = 0;

                #region test list
                listBox1.SelectionMode = SelectionMode.MultiExtended;
                listBox1.Width = 150;
                listBox1.Margin = new Padding(50, 20, 20, 20);

                foreach (var user in r_LoginService.LoggedInUser.Friends) {
                    //var posts = user.Posts;
                    listBox1.Items.Add(user);
                }
                m_Panel.Controls.Add(listBox1);
                listBox1.SelectedIndexChanged += personSelectedAsync;
                #endregion 

                #region UserPosts
                m_Panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                m_Panel.Padding = new Padding(20, 0, 20, 0);
                foreach (PostModel post in userPosts)
                {
                    m_Panel.Controls.Add(new PostControl(post, 0 , tempRowIndex));
                    
                    tempRowIndex++;
                }
                #endregion 

                m_Panel.Padding = new Padding(10);
                m_Panel.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(m_Panel);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Failed to retrive data, please try again.", @"Fetch Data Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                contentSpinner.Visible = false;
            }
        }
        
        private async void personSelectedAsync(object i_Sender, EventArgs i_EventArgs)
        {

            PostService postService = new PostService();
            foreach (User user in listBox1.SelectedItems) {
                List<PostModel> userPosts = await postService.GetUserPostsAsync(user);

                foreach (PostModel post in userPosts)
                {
                    m_Panel.Controls.Add(new PostControl(post));
                }    
            }
        }
        

        private async void eventsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                contentSpinner.Visible = true;
                await Task.Delay(5000);

            }
            catch (Exception)
            {
                MessageBox.Show(@"Failed to retrive data, please try again.", @"Fetch Data Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                contentSpinner.Visible = false;
            }
        }

        private async void likesButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                contentSpinner.Visible = true;
                resetContentPanel();

                ILikeService likeService = new LikesService(r_LoginService);
                ObservableCollection<PostedItem> items = new ObservableCollection<PostedItem>(r_LoginService.LoggedInUser.PhotosTaggedIn);
                Dictionary<string, int> userLikesPhotos = await likeService.GetLikesHistogram(items);

                items = new ObservableCollection<PostedItem>(r_LoginService.LoggedInUser.Posts);
                Dictionary<string, int> userLikesPosts = await likeService.GetLikesHistogram(items);

                items = new ObservableCollection<PostedItem>(r_LoginService.LoggedInUser.Albums);
                Dictionary<string, int> userLikesAlbums = await likeService.GetLikesHistogram(items);

                m_Panel = new TableLayoutPanel { ColumnCount = 3, AutoScroll = true };
                m_Panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 40F));

                Font labelFont = new Font("Arial", 12);
                Font titleFont = new Font("Arial", 20);

                fillLikeToTable("Photos", userLikesPhotos, m_Panel, labelFont, titleFont, 0, 0);
                fillLikeToTable("Posts", userLikesPosts, m_Panel, labelFont, titleFont, 0, 1);
                fillLikeToTable("Albums", userLikesAlbums, m_Panel, labelFont, titleFont, 0, 2);

                m_Panel.Padding = new Padding(10);
                m_Panel.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(m_Panel);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Failed to retrive data, please try again.", @"Fetch Data Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                contentSpinner.Visible = false;
            }
        }

        private void fillLikeToTable(string i_LableName, Dictionary<string, int> i_UserLikesPhotos, TableLayoutPanel i_Panel, Font i_LabelFont, Font i_TitleFont,  int i_RowIndex, int i_ColumnIndex)
        {
            i_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 50F));
            i_Panel.Controls.Add(new Label { Font = i_TitleFont, Text = i_LableName, AutoSize = true }, i_ColumnIndex, i_RowIndex);
            foreach (KeyValuePair<string, int> propertyForDisplay in i_UserLikesPhotos)
            {
                i_RowIndex++;
                i_Panel.Controls.Add(new Label { Font = i_LabelFont, Text = propertyForDisplay.Key + @" " + propertyForDisplay.Value, AutoSize = true }, i_ColumnIndex, i_RowIndex);
            }
        }

        private async void checkinsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                contentSpinner.Visible = true;
                await Task.Delay(5000);

            }
            catch (Exception)
            {
                MessageBox.Show(@"Failed to retrive data, please try again.", @"Fetch Data Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                contentSpinner.Visible = false;
            }
        }

        private async void statsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                contentSpinner.Visible = true;
                resetContentPanel();

                m_Panel = new TableLayoutPanel { ColumnCount = 2, AutoScroll = true };

                ILikeService likeService = new LikesService(r_LoginService);

                // get data as defined in settings
                List<Task> getDataTasks = new List<Task>();
                Dictionary<string, int> allPostemItemsLikes = new Dictionary<string, int>();
                foreach(KeyValuePair<eLikedItem, bool> keyValuePair in AppAppConfigService.GetInstance().StateSettings.LikedItems.Where(i_Item => i_Item.Value))
                {
                    Task getDataTask = Task.Run(async () =>
                    {
                        PropertyInfo propertyInfo = r_LoginService.LoggedInUser.GetType().GetProperty(keyValuePair.Key.ToString());
                        if (propertyInfo != null)
                        {
                            try
                            {
                                object prop = propertyInfo.GetValue(r_LoginService.LoggedInUser, null);
                                IEnumerable collectionOfUnknownType = (IEnumerable)prop;
                                ObservableCollection<PostedItem> currentPostedItems = new ObservableCollection<PostedItem>();
                                foreach (PostedItem o in collectionOfUnknownType)
                                {
                                    currentPostedItems.Add(o);
                                }

                                Dictionary<string, int> currenLikes = await likeService.GetLikesHistogram(currentPostedItems).ConfigureAwait(false);
                                allPostemItemsLikes.AddRange<string, int>(currenLikes);

                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    });
                    getDataTasks.Add(getDataTask);
                }

                await Task.WhenAll(getDataTasks);

                Chart likeMeTheMostChart = new Chart();
                Chart likeMeTheLeastChart = new Chart();
                ((ISupportInitialize)likeMeTheMostChart).BeginInit();
                ((ISupportInitialize)likeMeTheLeastChart).BeginInit();

                SuspendLayout();

                ChartArea chartsArea = new ChartArea();
                likeMeTheMostChart.ChartAreas.Add(chartsArea);
                likeMeTheMostChart.Dock = DockStyle.Top;

                AutoScaleDimensions = new SizeF(6F, 13F);
                AutoScaleMode = AutoScaleMode.Font;

                Title title = likeMeTheMostChart.Titles.Add("Who Likes me the most!");
                title.Font = new Font("Arial", 16, FontStyle.Bold);

                likeMeTheMostChart.Series.Clear();
                likeMeTheMostChart.Palette = ChartColorPalette.Fire;
                likeMeTheMostChart.ChartAreas[0].BackColor = Color.Transparent;
                likeMeTheMostChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                likeMeTheMostChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                Series series = new Series
                {
                    IsVisibleInLegend = false,
                    ChartType = AppAppConfigService.GetInstance().StateSettings.SelectedChartType
                };
                likeMeTheMostChart.Series.Add(series);

                int i = 0;
                Random rnd = new Random();
                foreach (KeyValuePair<string, int> userLikesPhoto in allPostemItemsLikes.OrderByDescending(i_L => i_L.Value).Take(AppAppConfigService.GetInstance().StateSettings.NumberOfFriend))
                {
                    series.Points.Add(userLikesPhoto.Value);
                    DataPoint dataPoint = series.Points[i];
                    Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    dataPoint.Color = randomColor;
                    dataPoint.AxisLabel = userLikesPhoto.Key;
                    dataPoint.LegendText = userLikesPhoto.Key;
                    dataPoint.Label = userLikesPhoto.Value.ToString();
                    i++;
                }
                likeMeTheMostChart.Invalidate();

                ChartArea chartsArea2 = new ChartArea();
                likeMeTheLeastChart.ChartAreas.Add(chartsArea2);
                likeMeTheLeastChart.Dock = DockStyle.Bottom;

                AutoScaleDimensions = new SizeF(6F, 13F);
                AutoScaleMode = AutoScaleMode.Font;

                Title likeMeTheLeastChartTitle = likeMeTheLeastChart.Titles.Add("Who Likes me the least!");
                likeMeTheLeastChartTitle.Font = new Font("Arial", 16, FontStyle.Bold);

                likeMeTheLeastChart.Series.Clear();
                likeMeTheLeastChart.Palette = ChartColorPalette.Fire;
                likeMeTheLeastChart.ChartAreas[0].BackColor = Color.Transparent;
                likeMeTheLeastChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                likeMeTheLeastChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                Series series2 = new Series
                {
                    IsVisibleInLegend = false,
                    ChartType = AppAppConfigService.GetInstance().StateSettings.SelectedChartType
                };
                likeMeTheLeastChart.Series.Add(series2);

                i = 0;
                foreach (KeyValuePair<string, int> userLikesPhoto in allPostemItemsLikes.OrderBy(i_L => i_L.Value).Take(AppAppConfigService.GetInstance().StateSettings.NumberOfFriend))
                {
                    series2.Points.Add(userLikesPhoto.Value);
                    DataPoint dataPoint = series2.Points[i];
                    Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    dataPoint.Color = randomColor;
                    dataPoint.AxisLabel = userLikesPhoto.Key;
                    dataPoint.LegendText = userLikesPhoto.Key;
                    dataPoint.Label = userLikesPhoto.Value.ToString();
                    i++;
                }
                likeMeTheLeastChart.Invalidate();

                ((ISupportInitialize)likeMeTheMostChart).EndInit();
                ((ISupportInitialize)likeMeTheLeastChart).EndInit();

                contentPanel.Controls.Add(likeMeTheMostChart);
                contentPanel.Controls.Add(likeMeTheLeastChart);
                this.ResumeLayout(false);

            }
            catch (Exception)
            {
                MessageBox.Show(@"Failed to retrive data, please try again.", @"Fetch Data Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                contentSpinner.Visible = false;
            }
        }

        private void settingsButtonClick(object i_Sender, EventArgs i_EventArgs)
        {
            try
            {
                contentSpinner.Visible = true;
                resetContentPanel();

                m_Panel = new TableLayoutPanel { ColumnCount = 2, AutoSize = true, AutoScroll = true };
                m_Panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 50F));

                int currentRow = 0;
  
                m_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 30F));
                m_Panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 60F));
                m_Panel.Controls.Add(new Label { Font = new Font("Arial", 20, FontStyle.Bold), Text = @"Stats", AutoSize = true, Padding = new Padding(0, 7, 7, 7) }, 0, currentRow);
                m_Panel.Controls.Add(new Label { Font = new Font("Arial", 12), Text = @"Chart Type:", AutoSize = true, Padding = new Padding(5) }, 0, ++currentRow);

                FlowLayoutPanel chartTypePanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true};
                RadioButton columnChartRadioButton = new RadioButton
                {
                    Text = SeriesChartType.Column.ToString(),
                    Checked = AppAppConfigService.GetInstance().StateSettings.SelectedChartType == SeriesChartType.Column
                };
                columnChartRadioButton.CheckedChanged += delegate
                {
                    AppAppConfigService.GetInstance().StateSettings.SelectedChartType = SeriesChartType.Column;
                };
                
                RadioButton pieChartRadioButton = new RadioButton
                {
                    Text = SeriesChartType.Pie.ToString(),
                    Checked = AppAppConfigService.GetInstance().StateSettings.SelectedChartType == SeriesChartType.Pie
                };

                pieChartRadioButton.CheckedChanged += delegate
                {
                    AppAppConfigService.GetInstance().StateSettings.SelectedChartType = SeriesChartType.Pie;
                };

                chartTypePanel.Controls.Add(columnChartRadioButton);
                chartTypePanel.Controls.Add(pieChartRadioButton);
                m_Panel.Controls.Add(chartTypePanel, 1, currentRow);

                m_Panel.Controls.Add(new Label { Font = new Font("Arial", 12), Text = @"Number Of Friends To Consider:", AutoSize = true, Padding = new Padding(5, 5, 5, 15) }, 0, ++currentRow);

                TextBox numberOfFriendsTextBox = new TextBox{Text = AppAppConfigService.GetInstance().StateSettings.NumberOfFriend.ToString()};
                numberOfFriendsTextBox.TextChanged += delegate
                {
                    int value;
                    if(int.TryParse(numberOfFriendsTextBox.Text, out value))
                    {
                        AppAppConfigService.GetInstance().StateSettings.NumberOfFriend = value;
                    }                      
                };
                numberOfFriendsTextBox.KeyPress += delegate (object i_S, KeyPressEventArgs i_E)
                {
                    char ch = i_E.KeyChar;
                    if(!ch.IsDigid())
                    {
                        i_E.Handled = true;
                    }
                };
                m_Panel.Controls.Add(numberOfFriendsTextBox, 1, currentRow);

                m_Panel.Controls.Add(new Label { Font = new Font("Arial", 12), Text = @"Collect Data From:", AutoSize = true, Padding = new Padding(5) }, 0, ++currentRow);
                FlowLayoutPanel likedItemsPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true };
                foreach (eLikedItem likedItem in Enum.GetValues(typeof(eLikedItem)))
                {
                    CheckBox checkBox = new CheckBox { Text = likedItem.GetPropertyForDisplay(), Checked = AppAppConfigService.GetInstance().StateSettings.LikedItems[likedItem] };
                    checkBox.CheckedChanged += delegate (object i_S, EventArgs i_E)
                    {
                        AppAppConfigService.GetInstance().StateSettings.LikedItems[likedItem] = ((CheckBox)i_S).Checked;
                    };
                    likedItemsPanel.Controls.Add(checkBox);
                }
                m_Panel.Controls.Add(likedItemsPanel, 1, currentRow);

                m_Panel.Padding = new Padding(10);
                m_Panel.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(m_Panel);

            }
            catch (Exception)
            {
                MessageBox.Show(@"Failed to retrive data, please try again.", @"Fetch Data Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                contentSpinner.Visible = false;
            }
        }

        protected override void OnShown(EventArgs i_EventArgs)
        {
            base.OnShown(i_EventArgs);

            AppAppConfigService appAppConfig = AppAppConfigService.GetInstance();
            Top = appAppConfig.WindowPosition.X;
            Left = appAppConfig.WindowPosition.Y;
  
            try
            {
                if(!string.IsNullOrEmpty(appAppConfig.LastAccessTocken))
                {
                    LoginResult loginParams = FacebookService.Connect(appAppConfig.LastAccessTocken);
                    if(loginParams != null)
                    {
                        r_LoginService.LoggedInUser = loginParams.LoggedInUser;
                        postLogin();
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show(@"Failed to connect with currnt Token, please try again.", @"Facebook Connect Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void stayLogedInCheckedChanged(object i_Sender, EventArgs i_EventArgs)
        {
            AppAppConfigService appAppConfig = AppAppConfigService.GetInstance();
            appAppConfig.StayLogedIn = StayLoggedInLabel.Checked;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs i_EventArgs)
        {
            base.OnClosing(i_EventArgs);
            AppAppConfigService appAppConfig = AppAppConfigService.GetInstance();
            appAppConfig.WindowPosition = new Point(this.Top, this.Left);

            AppAppConfigService.SaveToFile();
        }

        protected override void Dispose(bool i_Disposing)
        {
            if (i_Disposing)
            {
                components?.Dispose();
                Resize -= resizeFormEvent;
            }

            base.Dispose(i_Disposing);
        }
    }
}
