using emsModels;
using emsDALEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace ems
{

    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        String hiddenPassword = "";
        String fabMain = "#ff7b1fa2";
        String fabFocus = "#ff501469";
        adminViewModel _adminWindowViewModel;
        enum fabTasks { nul, addAdmin, addManager, addBus, addGuard, addDestination, addRoute, makeUserAdmin }
        fabTasks currentFabTask = fabTasks.nul;
        
        static String myName = "";
        static String myPassword ="";

        public Admin()
        {
            InitializeComponent();
            checkIn();
            statusbarTime.Content = (DateTime.Now.TimeOfDay.Hours > 13 ? (DateTime.Now.TimeOfDay.Hours - 12) : DateTime.Now.TimeOfDay.Hours) + ":" + (DateTime.Now.TimeOfDay.Minutes < 10 ? "0" : "") + (DateTime.Now.TimeOfDay.Hours > 12 ? DateTime.Now.TimeOfDay.Minutes + " PM" : DateTime.Now.TimeOfDay.Minutes + " AM");

            _adminWindowViewModel = new adminViewModel();
            this.DataContext = _adminWindowViewModel;

            applyColor(fabMain);

            actionPanelLabel.Content = "Admin";
            border.Visibility = Visibility.Visible;
            fnSetFabVisible(Visibility.Hidden);

        }

        public void checkIn()
        {
            AdminDAFactory me = new AdminDAFactory();
            me.updateCurrentLogin(me.findMyObj(myName, myPassword));
        }
        private void applyColor(String accentColor)
        {
            SolidColorBrush color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(accentColor));
            actionPanel.Background = color;
            fabBg.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(accentColor));
            border.Stroke = color;
            mainScreen.Background = color;
            addScreen.Background = color;
            addAdminScreen.Background = color;
            addManagerScreen.Background = color;
            addBusScreen.Background = color;
            addGuardScreen.Background = color;
            changeViewScreen.Background = color;
            statusScreen.Background= color;
            addRouteScreen.Background= color;
            removeUserScreen.Background = color;
        }

        public static void WhoAmI(String a, String b)
        {
            myName = a;
            myPassword = b;
        }
        
        private void adminTextChanged(object sender, TextChangedEventArgs e)
        {
            if (addAdminName.Text != "Enter Name" && addAdminPassword.Text != "Enter Password" && addAdminPassword.Text == "Password Hidden" && addAdminCell.Text != "Enter Cell" && addAdminEmail.Text != "Enter Email" && addAdminName.Text.Trim() != "" && addAdminCell.Text.Trim() != "" && addAdminPassword.Text.Trim() != "" && addAdminEmail.Text.Trim() != "")
            {
                fnSetFabVisible(Visibility.Visible);
            }
            else
            fnSetFabVisible(Visibility.Hidden);
        }
        private void managerTextChanged(object sender, TextChangedEventArgs e)
        {
            if (addManagerName.Text != "Enter Name" && addManagerPassword.Text != "Enter Password" && addManagerPassword.Text == "Password Hidden" && addManagerCell.Text != "Enter Cell" && addManagerEmail.Text != "Enter Email" && addManagerName.Text.Trim() != "" && addManagerCell.Text.Trim() != "" && addManagerPassword.Text.Trim() != "" && addManagerEmail.Text.Trim() != "")
            {
                fnSetFabVisible(Visibility.Visible);
            }
            else
                fnSetFabVisible(Visibility.Hidden);
        }

        private void driverGuardTextChanged(object sender, TextChangedEventArgs e)
        {
            if (addDriverName.Text != "Enter Name" && addDriverCell.Text != "Enter Cell" && addManagerName.Text.Trim() != "" && addManagerCell.Text.Trim() != "")
            {
                fnSetFabVisible(Visibility.Visible);
            }
            else
                fnSetFabVisible(Visibility.Hidden);

        }
        #region fab
        private void fnSetFabTask(fabTasks val)
        {
            currentFabTask = val;
            if (val.Equals(fabTasks.addAdmin) || val.Equals(fabTasks.addManager) || val.Equals(fabTasks.addBus) || val.Equals(fabTasks.addGuard) || val.Equals(fabTasks.addDestination) || val.Equals(fabTasks.addRoute) || val.Equals(fabTasks.makeUserAdmin))
            {
                fabTask.Source = new BitmapImage(new Uri(@"E:\Desktop\res\ic_check_white_48dp.png"));
            }


        }
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
        private void fab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (currentFabTask == fabTasks.addAdmin)
            {
                
                    AdminDAFactory admin = new AdminDAFactory();
                    
                bool check = admin.addAdmin(addAdminName.Text,hiddenPassword, long.Parse(addAdminCell.Text), addAdminEmail.Text);
                if (check)
                {
                    currentFabTask = fabTasks.nul;
                    addAdminScreen.Visibility = Visibility.Hidden;
                    addAdminScreenShadow.Visibility = Visibility.Hidden;

                    actionPanelLabel.Content = "Admin";
                    mainScreen.Visibility = Visibility.Visible;
                    mainScreenShadow.Visibility = Visibility.Visible;
                    fnSetFabVisible(Visibility.Hidden);
                    btnBack.Visibility = Visibility.Hidden;
                }
                else currentFabTask = fabTasks.nul;

            }
            else if (currentFabTask == fabTasks.addGuard)
            {

                AdminDAFactory admin = new AdminDAFactory();

                bool check = admin.addGuard(addGuardName.Text, long.Parse(addGuardCell.Text));
                if (check)
                {
                    currentFabTask = fabTasks.nul;
                    addAdminScreen.Visibility = Visibility.Hidden;
                    addAdminScreenShadow.Visibility = Visibility.Hidden;

                    actionPanelLabel.Content = "Admin";
                    mainScreen.Visibility = Visibility.Visible;
                    mainScreenShadow.Visibility = Visibility.Visible;
                    fnSetFabVisible(Visibility.Hidden);
                    btnBack.Visibility = Visibility.Hidden;
                }
                else currentFabTask = fabTasks.addAdmin;

            }
            else if (currentFabTask == fabTasks.addRoute)
            {

                AdminDAFactory admin = new AdminDAFactory();

                bool check = admin.addRoute(addRouteName.Text);
                if (check)
                {
                    currentFabTask = fabTasks.nul;
                    addAdminScreen.Visibility = Visibility.Hidden;
                    addAdminScreenShadow.Visibility = Visibility.Hidden;

                    actionPanelLabel.Content = "Admin";
                    mainScreen.Visibility = Visibility.Visible;
                    mainScreenShadow.Visibility = Visibility.Visible;
                    fnSetFabVisible(Visibility.Hidden);
                    btnBack.Visibility = Visibility.Hidden;
                }
                else currentFabTask = fabTasks.addAdmin;

            }
            else if (currentFabTask == fabTasks.addBus)
            {

                AdminDAFactory admin = new AdminDAFactory();

                bool check = admin.addDriver(addDriverName.Text, long.Parse(addDriverCell.Text));
                if (check)
                {
                    currentFabTask = fabTasks.nul;
                    addAdminScreen.Visibility = Visibility.Hidden;
                    addAdminScreenShadow.Visibility = Visibility.Hidden;
                    
                    actionPanelLabel.Content = "Admin";
                    mainScreen.Visibility = Visibility.Visible;
                    mainScreenShadow.Visibility = Visibility.Visible;
                    fnSetFabVisible(Visibility.Hidden);
                    btnBack.Visibility = Visibility.Hidden;
                }
                else currentFabTask = fabTasks.addAdmin;

            }
            else if (currentFabTask == fabTasks.addManager)
            {
                
                    ManagerDAFactory admin = new ManagerDAFactory();
                    bool check = admin.addManager(addManagerName.Text, hiddenPassword, long.Parse(addManagerCell.Text), addManagerEmail.Text);
                if (check)
                {

                    currentFabTask = fabTasks.nul;
                    addManagerScreen.Visibility = Visibility.Hidden;
                    addManagerScreenShadow.Visibility = Visibility.Hidden;

                    actionPanelLabel.Content = "Admin";
                    mainScreen.Visibility = Visibility.Visible;
                    mainScreenShadow.Visibility = Visibility.Visible;
                    fnSetFabVisible(Visibility.Hidden);
                    btnBack.Visibility = Visibility.Hidden;
                }
                else currentFabTask = fabTasks.addManager;
            }
            else if (currentFabTask== fabTasks.makeUserAdmin)
            {

            }

        }
        #endregion

        #region Navigations
        private void btnMainMove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void btnMainClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            checkOut();
            Application.Current.Shutdown();
            MainWindow.mainClose();
        }

        public void checkOut()
        {
            AdminDAFactory me = new AdminDAFactory();
            me.updateLastLogin(me.findMyObj(myName, myPassword));
        }

        //maximize or restore window
        private void btnMainMaximize_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!this.WindowState.Equals(WindowState.Maximized))

            {
                Window window = new Admin();
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.SourceInitialized += (s, a) => window.WindowState = WindowState.Maximized;
                window.Show();
                this.Close();
            }

            else
            {
                Window window = new Admin();
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
            if (addScreen.Visibility == Visibility.Visible)
            {
                addScreen.Visibility = Visibility.Hidden;
                addScreenShadow.Visibility = Visibility.Hidden;

                actionPanelLabel.Content = "Admin";
                mainScreen.Visibility = Visibility.Visible;
                mainScreenShadow.Visibility = Visibility.Visible;
                btnBack.Visibility = Visibility.Hidden;
                destroy();
            }
            if (addScreen.Visibility == Visibility.Visible)
            {
                addScreen.Visibility = Visibility.Hidden;
                addScreenShadow.Visibility = Visibility.Hidden;

                actionPanelLabel.Content = "Admin";
                mainScreen.Visibility = Visibility.Visible;
                mainScreenShadow.Visibility = Visibility.Visible;
                btnBack.Visibility = Visibility.Hidden;
                destroy();
            }
            if (addAdminScreen.Visibility == Visibility.Visible)
            {
                addAdminScreen.Visibility = Visibility.Hidden;
                addAdminScreenShadow.Visibility = Visibility.Hidden;

                fnSetFabVisible(Visibility.Hidden);
                actionPanelLabel.Content = "Add";
                addScreen.Visibility = Visibility.Visible;
                addScreenShadow.Visibility = Visibility.Visible;
                destroy();

            }
            if (addManagerScreen.Visibility == Visibility.Visible)
            {
                addManagerScreen.Visibility = Visibility.Hidden;
                addManagerScreenShadow.Visibility = Visibility.Hidden;
                
                fnSetFabVisible(Visibility.Hidden);
                actionPanelLabel.Content = "Add";
                addScreen.Visibility = Visibility.Visible;
                addScreenShadow.Visibility = Visibility.Visible;
                destroy();

            }
            if (addBusScreen.Visibility == Visibility.Visible)
            {
                addBusScreen.Visibility = Visibility.Hidden;
                addBusScreenShadow.Visibility = Visibility.Hidden;

                fnSetFabVisible(Visibility.Hidden);
                actionPanelLabel.Content = "Add";
                addScreen.Visibility = Visibility.Visible;
                addScreenShadow.Visibility = Visibility.Visible;
                destroy();

            }
            if (addGuardScreen.Visibility == Visibility.Visible)
            {
                addGuardScreen.Visibility = Visibility.Hidden;
                addGuardScreenShadow.Visibility = Visibility.Hidden;

                fnSetFabVisible(Visibility.Hidden);
                actionPanelLabel.Content = "Add";
                addScreen.Visibility = Visibility.Visible;
                addScreenShadow.Visibility = Visibility.Visible;
                destroy();

            }
            if (addRouteScreen.Visibility == Visibility.Visible)
            {
                addRouteScreen.Visibility = Visibility.Hidden;
                addRouteScreenShadow.Visibility = Visibility.Hidden;

                fnSetFabVisible(Visibility.Hidden);
                actionPanelLabel.Content = "Add";
                addScreen.Visibility = Visibility.Visible;
                addScreenShadow.Visibility = Visibility.Visible;
                destroy();

            }
            if (changeViewScreen.Visibility == Visibility.Visible)
            {
                changeViewScreen.Visibility = Visibility.Hidden;
                changeViewScreenShadow.Visibility = Visibility.Hidden;

                actionPanelLabel.Content = "Admin";
                mainScreen.Visibility = Visibility.Visible;
                mainScreenShadow.Visibility = Visibility.Visible;
                btnBack.Visibility = Visibility.Hidden;
                destroy();
            }

            if(statusScreen.Visibility==Visibility.Visible)
            {
                statusScreen.Visibility = Visibility.Hidden;
                statusScreenShadow.Visibility = Visibility.Hidden;

                actionPanelLabel.Content = "Admin";
                btnBack.Visibility = Visibility.Hidden;
                mainScreen.Visibility = Visibility.Visible;
                mainScreenShadow.Visibility = Visibility.Visible;
                destroy();
            }

            if (removeUserScreen.Visibility == Visibility.Visible)
            {
                removeUserScreen.Visibility = Visibility.Hidden;
                removeUserScreenShadow.Visibility = Visibility.Hidden;

                actionPanelLabel.Content = "Admin";
                btnBack.Visibility = Visibility.Hidden;
                mainScreen.Visibility = Visibility.Visible;
                mainScreenShadow.Visibility = Visibility.Visible;
                destroy();
            }
        }
        public void destroy()
        {
            addAdminName.Text = addManagerName.Text = addDriverName.Text = addGuardName.Text = "Enter Name";
            addAdminPassword.Text = addManagerPassword.Text = "Enter Password";
            addAdminCell.Text = addManagerCell.Text = addDriverCell.Text = addGuardCell.Text = "Enter Cell";
            addAdminEmail.Text = addManagerEmail.Text = "Enter Email";
            addRouteName.Text = "Enter Path";
        }
        #endregion

        #region Admin Main Screen
        private void add_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            actionPanelLabel.Content = "Add";
            mainScreen.Visibility = Visibility.Hidden;
            mainScreenShadow.Visibility = Visibility.Hidden;

            addScreen.Visibility = Visibility.Visible;
            addScreenShadow.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Visible;
            fnSetFabVisible(Visibility.Hidden);
        }
        private void remove_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            actionPanelLabel.Content = "Remove";
          
            mainScreen.Visibility = Visibility.Hidden;
            mainScreenShadow.Visibility = Visibility.Hidden;

            removeUserScreen.Visibility = Visibility.Visible;
            removeUserScreenShadow.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Visible;
            AdminDAFactory admin = new AdminDAFactory();
            //dataGrid.ItemsSource = admin.viewUsers();
            userListRemove.ItemsSource = admin.viewUsers();
        

    }

    private void viewChange_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            actionPanelLabel.Content = "View / Change";
            mainScreen.Visibility = Visibility.Hidden;
            mainScreenShadow.Visibility = Visibility.Hidden;

            changeViewScreen.Visibility = Visibility.Visible;
            changeViewScreenShadow.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Visible;
            AdminDAFactory admin = new AdminDAFactory();
            //dataGrid.ItemsSource = admin.viewUsers();
            userList.ItemsSource = admin.viewUsers();
        }


        private void status_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            actionPanelLabel.Content = "Last Login";
            mainScreen.Visibility = Visibility.Hidden;
            mainScreenShadow.Visibility = Visibility.Hidden;

            statusScreen.Visibility = Visibility.Visible;
            statusScreenShadow.Visibility = Visibility.Visible;

            btnBack.Visibility = Visibility.Visible;

            AdminDAFactory me = new AdminDAFactory();
            statusBtn.Content = me.findMe(myName, myPassword);
        }


        private void signOffAdmin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window window = new MainWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.SourceInitialized += (s, a) => window.WindowState = WindowState.Normal;
            window.Show();
            checkOut();
            this.Close();
        }

        #endregion

        #region Add Screen
        private void addAdmin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            actionPanelLabel.Content = "Add Admin";
            addScreen.Visibility = Visibility.Hidden;
            addScreenShadow.Visibility = Visibility.Hidden;

            fnSetFabTask(fabTasks.addAdmin);
            fnSetFabVisible(Visibility.Hidden);
            addAdminScreen.Visibility = Visibility.Visible;
            addAdminScreenShadow.Visibility = Visibility.Visible;
        }

        private void addManager_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            actionPanelLabel.Content = "Add Manager";
            addScreen.Visibility = Visibility.Hidden;
            addScreenShadow.Visibility = Visibility.Hidden;

            fnSetFabTask(fabTasks.addManager);
            fnSetFabVisible(Visibility.Hidden);
            addManagerScreen.Visibility = Visibility.Visible;
            addManagerScreenShadow.Visibility = Visibility.Visible;
        }

        private void addGuard_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            actionPanelLabel.Content = "Add Guard";
            addScreen.Visibility = Visibility.Hidden;
            addScreenShadow.Visibility = Visibility.Hidden;

            fnSetFabTask(fabTasks.addManager);
            fnSetFabVisible(Visibility.Hidden);
            addGuardScreen.Visibility = Visibility.Visible;
            addGuardScreenShadow.Visibility = Visibility.Visible;
        }

        private void addBus_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            actionPanelLabel.Content = "Add Bus";
            addScreen.Visibility = Visibility.Hidden;
            addScreenShadow.Visibility = Visibility.Hidden;

            fnSetFabTask(fabTasks.addBus);
            fnSetFabVisible(Visibility.Hidden);
            addBusScreen.Visibility = Visibility.Visible;
            addBusScreenShadow.Visibility = Visibility.Visible;
        }

        private void addDestination_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            actionPanelLabel.Content = "Add Destination";
        }

        private void addRoute_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            actionPanelLabel.Content = "Add Route";

            addScreen.Visibility = Visibility.Hidden;
            addScreenShadow.Visibility = Visibility.Hidden;

            fnSetFabTask(fabTasks.addRoute);
            fnSetFabVisible(Visibility.Hidden);
            addRouteScreen.Visibility = Visibility.Visible;
            addRouteScreenShadow.Visibility = Visibility.Visible;
        }

        #region Check Values

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

        private void addRouteName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (addRouteName.Text != "Enter Path" && addRouteName.Text.Trim() != "")
            {
                fnSetFabVisible(Visibility.Visible);
            }
            else
                fnSetFabVisible(Visibility.Hidden);
        }

        private void path_GotFocus(object sender, RoutedEventArgs e)
        {

            TextBox tb = (TextBox)sender;
            if (tb.Text == "Enter Path") tb.Text = string.Empty;
        }

        private void path_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Enter Path";
                fnSetFabVisible(Visibility.Hidden);
            }

        }


        #endregion

        #endregion

        private void userListRemove_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            table_User user = (table_User)userListRemove.SelectedItem;
            AdminDAFactory remover = new AdminDAFactory();
            if (remover.removeUser(user.user_name))
                MessageBox.Show("User Deleted");
            else MessageBox.Show("Error occured while deleting user");
        }
    }
}
