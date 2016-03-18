using emsDALEF;
using emsModels;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Globalization;
using System.Windows.Media.Animation;

namespace ems
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        mainWindowViewModel _mainWindowViewModel;
        public String hiddenPassword = "";
        String fabMain = "#ff8bc34a";
        String fabFocus = "#ff5a7f30";
        enum fabTasks { nul, typeSelection, signUp, logInChooseUser, logInCredentials }
        fabTasks currentFabTask = fabTasks.nul;
        public MainWindow()
        {

            InitializeComponent();

            statusbarTime.Content = (DateTime.Now.TimeOfDay.Hours > 13 ? (DateTime.Now.TimeOfDay.Hours - 12) : DateTime.Now.TimeOfDay.Hours) + ":" + (DateTime.Now.TimeOfDay.Minutes < 10 ? "0" : "") + (DateTime.Now.TimeOfDay.Hours > 12 ? DateTime.Now.TimeOfDay.Minutes + " PM" : DateTime.Now.TimeOfDay.Minutes + " AM");
            
            _mainWindowViewModel = new mainWindowViewModel();
            this.DataContext = _mainWindowViewModel;

            applyColor(fabMain);

            border.Visibility = Visibility.Visible;
            actionPanelLabel.Content = "Welcome";
            fnSetFabVisible(Visibility.Hidden);
            fnSetFabTask(fabTasks.nul);

        }
        private void applyColor(String accentColor)
        {
            SolidColorBrush color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(accentColor));
            actionPanel.Background = color;
            fabBg.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(accentColor));
            border.Stroke = color;
            welcomeScreen.Background = color;
            typeSelectionScreen.Background = color;
            credentialScreen.Background = color;
            signUpScreen.Background = color;
        }
        public static void mainClose()
        {
            Application.Current.Shutdown();
        }

        #region fab
        //fab icons
        private void fnSetFabTask(fabTasks val)
        {
            currentFabTask = val;
            if (val.Equals(fabTasks.signUp) || val.Equals(fabTasks.typeSelection))
            {
                fabTask.Source = new BitmapImage(new Uri(@"E:\Desktop\res\ic_check_white_48dp.png"));
            }

        }

        //fab actions
        private void fab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (currentFabTask.Equals(fabTasks.typeSelection))
            {
                if (loginAdminRb.IsChecked == true || loginManagerRb.IsChecked == true || loginUserRb.IsChecked == true)
                {
                    typeSelectionScreen.Visibility = Visibility.Hidden;
                    typeSelectionScreenShadow.Visibility = Visibility.Hidden;

                    credentialScreen.Visibility = Visibility.Visible;
                    credentialScreenShadow.Visibility = Visibility.Visible;
                    actionPanelLabel.Content = "Enter Credentials";

                    fnSetFabVisible(Visibility.Hidden);
                    fnSetFabTask(fabTasks.logInCredentials);
                }
            }
            else if (currentFabTask.Equals(fabTasks.logInCredentials))
            {

                if (loginName.Text != "Enter Name")
                    if (loginPassword.Text != "Enter Password")
                    {
                        fnSetFabVisible(Visibility.Visible);
                        logInValidation();
                    }
            }
            else if (currentFabTask.Equals(fabTasks.signUp))
            {
                table_User user = new table_User();
                user.user_name = name.Text;
                user.user_phone = long.Parse(cell.Text);
                user.user_email = email.Text;
                user.user_password = hiddenPassword;
                user.user_current_login = user.user_last_login = DateTime.Now;

                user.user_current_login = DateTime.Now;
                //user.f_event_id = null;

                UserDAFactory userFac = new UserDAFactory();
                if (userFac.signUp(user))
                {
                    MessageBox.Show("Saved");
                    signUpScreen.Visibility = Visibility.Hidden;
                    signUpScreenShadow.Visibility = Visibility.Hidden;
                    name.Text = "Enter Name";
                    cell.Text = "Enter Cell";
                    password.Text = "Enter Password";
                    email.Text = "Enter Email";

                    welcomeScreen.Visibility = Visibility.Visible;
                    welcomeScreenShadow.Visibility = Visibility.Visible;
                    actionPanelLabel.Content = "Welcome";

                    btnMainBack.Visibility = Visibility.Hidden;
                    fnSetFabVisible(Visibility.Hidden);
                }
                else MessageBox.Show("Not Saved");
                fnSetFabTask(fabTasks.signUp);

            }
        }

        //change fab visibilty
        private void fnSetFabVisible(Visibility val)
        {
            fabBg.Visibility = val;
            fab.Visibility = val;
            fabShadow.Visibility = val;
            fabTask.Visibility = val;
        }

        private void fab_MouseEnter(object sender, MouseEventArgs e)
        {
            ColorAnimation animation;
            animation = new ColorAnimation();
            animation.To = (Color)ColorConverter.ConvertFromString(fabFocus);
            animation.From = (Color)ColorConverter.ConvertFromString(fabMain);
            animation.Duration = new Duration(TimeSpan.FromSeconds(0.25));
            fabBg.Fill.BeginAnimation(SolidColorBrush.ColorProperty, animation);

            animation = new ColorAnimation();
            animation.To = (Color)ColorConverter.ConvertFromString("#65000000");
            animation.From = (Color)ColorConverter.ConvertFromString("#45000000");
            animation.Duration = new Duration(TimeSpan.FromSeconds(0.25));
            fabShadow.Fill.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        }

        private void fab_MouseLeave(object sender, MouseEventArgs e)
        {
            ColorAnimation animation;
            animation = new ColorAnimation();
            animation.From = (Color)ColorConverter.ConvertFromString(fabFocus);
            animation.To = (Color)ColorConverter.ConvertFromString(fabMain);
            animation.Duration = new Duration(TimeSpan.FromSeconds(0.25));
            fabBg.Fill.BeginAnimation(SolidColorBrush.ColorProperty, animation);

            animation = new ColorAnimation();
            animation.From = (Color)ColorConverter.ConvertFromString("#65000000");
            animation.To = (Color)ColorConverter.ConvertFromString("#45000000");
            animation.Duration = new Duration(TimeSpan.FromSeconds(0.25));
            fabShadow.Fill.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        }

        private void signUpValidation()
        {
            //check user and pass
            if (name.Text != "Enter Name")
                if (cell.Text != "Enter Phone")
                    if (password.Text != "Enter Password" && password.Text == "Hidden Password")
                        if (email.Text != "Enter Email")
                            if (hiddenPassword != "")
                                fnSetFabVisible(Visibility.Visible);

        }

        #endregion
        private void logInValidation()
        {
            //check login
            if ((bool)loginAdminRb.IsChecked)
            {

                AdminDAFactory adminFac = new AdminDAFactory();
                if (loginPassword.Text != "Enter Password" && loginPassword.Text != "Password Hidden")
                    hiddenPassword = loginPassword.Text;
                if (adminFac.logIn(loginName.Text, hiddenPassword))
                {
                    Window loggedIn = new Admin();
                    loggedIn.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    loggedIn.SourceInitialized += (s, a) => loggedIn.WindowState = WindowState.Normal;
                    Admin.WhoAmI(loginName.Text, loginPassword.Text);
                    loggedIn.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Admin does not exist with this name or password");
                    fnSetFabTask(fabTasks.logInCredentials);
                }
            }
            else if ((bool)loginManagerRb.IsChecked)
            {
                ManagerDAFactory managerFac = new ManagerDAFactory();
                if (loginPassword.Text != "Enter Password" && loginPassword.Text != "Password Hidden")
                    hiddenPassword = loginPassword.Text;
                if (managerFac.logIn(loginName.Text, hiddenPassword))
                {
                    Window loggedIn = new Manager();
                    loggedIn.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    loggedIn.SourceInitialized += (s, a) => loggedIn.WindowState = WindowState.Normal;
                    loggedIn.Show();
                    Manager.WhoAmI(loginName.Text, loginPassword.Text);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Manager does not exist with this name or password");
                    fnSetFabTask(fabTasks.logInCredentials);
                }
            }
            else if ((bool)loginUserRb.IsChecked)
            {
                UserDAFactory userFac = new UserDAFactory();
                if (loginPassword.Text != "Enter Password" && loginPassword.Text != "Password Hidden")
                    hiddenPassword = loginPassword.Text;
                if (userFac.logIn(loginName.Text, hiddenPassword))
                {
                    Window loggedIn = new User();
                    loggedIn.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    loggedIn.SourceInitialized += (s, a) => loggedIn.WindowState = WindowState.Normal;
                    loggedIn.Show();
                    User.WhoAmI(userFac.findMe(loginName.Text, loginPassword.Text));
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User does not exist with this name or password");
                    fnSetFabTask(fabTasks.logInCredentials);
                }
            }

        }

        #region navigations
        //close window
        private void btnMainClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //maximize or restore window

        private void btnMainMaximize_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!this.WindowState.Equals(WindowState.Maximized))

            {
                Window window = new MainWindow();
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.SourceInitialized += (s, a) => window.WindowState = WindowState.Maximized;
                window.Show();
                this.Close();
            }

            else
            {
                Window window = new MainWindow();
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.SourceInitialized += (s, a) => window.WindowState = WindowState.Normal;
                window.Show();
                this.Close();
            }

        }

        //minimize window
        private void btnMainMinimze_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnBack_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (typeSelectionScreen.Visibility == Visibility.Visible)
            {
                typeSelectionScreen.Visibility = Visibility.Hidden;
                typeSelectionScreenShadow.Visibility = Visibility.Hidden;
                loginAdminRb.IsChecked = false;
                loginManagerRb.IsChecked = false;
                loginUserRb.IsChecked = false;

                welcomeScreen.Visibility = Visibility.Visible;
                welcomeScreenShadow.Visibility = Visibility.Visible;
                actionPanelLabel.Content = "Welcome";

                btnMainBack.Visibility = Visibility.Hidden;
                fnSetFabVisible(Visibility.Hidden);
            }
            else if (signUpScreen.Visibility == Visibility.Visible)
            {
                signUpScreen.Visibility = Visibility.Hidden;
                signUpScreenShadow.Visibility = Visibility.Hidden;
                name.Text = "Enter Name";
                cell.Text = "Enter Cell";
                password.Text = "Enter Password";
                email.Text = "Enter Email";

                welcomeScreen.Visibility = Visibility.Visible;
                welcomeScreenShadow.Visibility = Visibility.Visible;
                actionPanelLabel.Content = "Welcome";

                btnMainBack.Visibility = Visibility.Hidden;
                fnSetFabVisible(Visibility.Hidden);
            }
            else if (credentialScreen.Visibility == Visibility.Visible)
            {
                credentialScreen.Visibility = Visibility.Hidden;
                credentialScreenShadow.Visibility = Visibility.Hidden;
                loginName.Text = "Enter Name";
                loginPassword.Text = "Enter Password";

                typeSelectionScreen.Visibility = Visibility.Visible;
                typeSelectionScreenShadow.Visibility = Visibility.Visible;
                actionPanelLabel.Content = "Choose Account Type";

                btnMainBack.Visibility = Visibility.Visible;
                fnSetFabTask(fabTasks.typeSelection);
                fnSetFabVisible(Visibility.Visible);
            }
        }

        #endregion
        //LogIn Screen
        private void logInBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            actionPanelLabel.Content = "Log In";
            welcomeScreen.Visibility = Visibility.Hidden;
            welcomeScreenShadow.Visibility = Visibility.Hidden;

            btnMainBack.Visibility = Visibility.Visible;
            typeSelectionScreen.Visibility = Visibility.Visible;
            typeSelectionScreenShadow.Visibility = Visibility.Visible;

            fnSetFabTask(fabTasks.typeSelection);
            fnSetFabVisible(Visibility.Hidden);
        }


        //Sign Up Screen
        private void signUpBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            actionPanelLabel.Content = "Sign Up";
            welcomeScreen.Visibility = Visibility.Hidden;
            welcomeScreenShadow.Visibility = Visibility.Hidden;

            btnMainBack.Visibility = Visibility.Visible;
            signUpScreen.Visibility = Visibility.Visible;
            signUpScreenShadow.Visibility = Visibility.Visible;

            fnSetFabTask(fabTasks.signUp);
            fnSetFabVisible(Visibility.Hidden);
        }

        #region Instructions
        private void name_GotFocus(object sender, RoutedEventArgs e)
        {

            TextBox tb = (TextBox)sender;
            if (tb.Text == "Enter Name")

                tb.Text = string.Empty;


        }

        private void password_GotFocus(object sender, RoutedEventArgs e)
        {

            TextBox tb = (TextBox)sender;
            if (tb.Text == "Enter Password")
                tb.Text = string.Empty;
            else if (tb.Text == "Password Hidden")
                tb.Text = hiddenPassword;

            fnSetFabVisible(Visibility.Hidden);

        }

        private void name_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Enter Name";
                fnSetFabVisible(Visibility.Hidden);
            }
        }

        private void password_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Enter Password";
            }
            else if (tb.Text != "Enter Password" && tb.Text.Trim() != "")
            {
                hiddenPassword = tb.Text;
                tb.Text = "Password Hidden";
            }
            fnSetFabVisible(Visibility.Hidden);
        }

        private void cell_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Enter Cell") tb.Text = string.Empty;
        }

        private void cell_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Enter Cell";
                fnSetFabVisible(Visibility.Hidden);
            }
        }

        private void email_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Enter Email") tb.Text = string.Empty;
        }

        private void email_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Enter Email";
                fnSetFabVisible(Visibility.Hidden);
            }
        }
        #endregion
        private void btnMainMove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        #region Image to Radio Links
        private void loginAdminImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            loginAdminRb.IsChecked = true;
            fnSetFabVisible(Visibility.Visible);
            //loginAdminRb.;
        }

        private void loginManagerImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            loginManagerRb.IsChecked = true;
            fnSetFabVisible(Visibility.Visible);
            // loginManagerRb.Content = true;
        }

        private void loginUserImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            loginUserRb.IsChecked = true;
            fnSetFabVisible(Visibility.Visible);
            // loginUserRb.Content = true;
        }
        #endregion

        #region Radio Button Checks
        private void loginAdminRb_Click(object sender, RoutedEventArgs e)
        {
            fnSetFabVisible(Visibility.Visible);
        }

        private void loginManagerRb_Click(object sender, RoutedEventArgs e)
        {
            fnSetFabVisible(Visibility.Visible);
        }

        private void loginUserRb_Click(object sender, RoutedEventArgs e)
        {
            fnSetFabVisible(Visibility.Visible);
        }
        #endregion

        #region Data Error Prevention
        
        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (name.Text != "Enter Name" && password.Text != "Enter Password" && password.Text == "Password Hidden" && cell.Text != "Enter Cell" && email.Text != "Enter Email" && name.Text.Trim() != "" && cell.Text.Trim() != "" && email.Text.Trim() != "")
                fnSetFabVisible(Visibility.Visible);
            else
                fnSetFabVisible(Visibility.Hidden);
        }
        
        private void loginName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (loginName.Text != "Enter Name" && loginName.Text.Trim() != "" && loginPassword.Text != "Enter Password" && loginPassword.Text.Trim() != "")
                fnSetFabVisible(Visibility.Visible);
        }

        private void loginPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (loginName.Text != "Enter Name" && loginName.Text.Trim() != "" && loginPassword.Text != "Enter Password" && loginPassword.Text.Trim() != "")
                fnSetFabVisible(Visibility.Visible);
        }
        #endregion
    }

}
