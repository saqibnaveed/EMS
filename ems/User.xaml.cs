using System;
using emsModels;
using emsDALEF;
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
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Window
    {
        static String myName = "";
        static String myPassword = "";
        String fabMain = "#ff0091ea";
        String fabFocus = "#ff005e98";
        enum fabTasks
        {
            nul, unregister, register
        }
        fabTasks currentFabTask = fabTasks.nul;
        
        public User()
        {
            InitializeComponent();
            checkIn();
            fnSetFabVisible(Visibility.Hidden);
            statusbarTime.Content = (DateTime.Now.TimeOfDay.Hours > 13 ? (DateTime.Now.TimeOfDay.Hours - 12) : DateTime.Now.TimeOfDay.Hours) + ":" + (DateTime.Now.TimeOfDay.Minutes < 10 ? "0" : "") + (DateTime.Now.TimeOfDay.Hours > 12 ? DateTime.Now.TimeOfDay.Minutes + " PM" : DateTime.Now.TimeOfDay.Minutes + " AM");


            applyColor(fabMain);

            actionPanelLabel.Content = "User";
            border.Visibility = Visibility.Visible;
        }
        public void checkIn()
        {
            UserDAFactory me = new UserDAFactory();
            me.updateCurrentLogin(me.findMyObj(myName, myPassword));
        }
        public static void WhoAmI(String a, String b)
        {
            myName = a;
            myPassword = b;
        }
        public void checkOut()
        {
            UserDAFactory me = new UserDAFactory();
            me.updateLastLogin(me.findMyObj(myName, myPassword));
        }
        private void applyColor(String accentColor)
        {
            SolidColorBrush color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(accentColor));
            actionPanel.Background = color;
            fabBg.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(accentColor));
            border.Stroke = color;
            currentEventScreen.Background = color;
            eventDetailScreen.Background = color;
            LastLoginScreen.Background = color;
            userMainScreen.Background = color;
            viewEventsScreen.Background = color;
        }
        private void fnSetFabTask(fabTasks val)
        {
            currentFabTask = val;
            if (val.Equals(fabTasks.unregister)) {
                fabTask.Source = new BitmapImage(new Uri(@"E:\Desktop\res\ic_cancel_white_48dp.png"));
            }
            else if (val.Equals(fabTasks.register)) {
             //set image for register
                fabTask.Source = new BitmapImage(new Uri(@"E:\Desktop\res\ic_assignment_ind_white_48dp.png"));
            }

        }

        private void fab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (currentFabTask.Equals(fabTasks.unregister))
            {

                //unregister
                fnSetFabTask(fabTasks.register);
            }
            else if (currentFabTask.Equals(fabTasks.register)) {
                
                //register
                fnSetFabTask(fabTasks.unregister);
            }
        } 
        private void btnMainClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            checkOut();
            Application.Current.Shutdown();
            MainWindow.mainClose();

        }

        //maximize or restore window
        private void btnMainMaximize_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!this.WindowState.Equals(WindowState.Maximized))

            {
                Window window = new User();
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.SourceInitialized += (s, a) => window.WindowState = WindowState.Maximized;
                window.Show();
                this.Close();
            }

            else
            {
                Window window = new User();
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.SourceInitialized += (s, a) => window.WindowState = WindowState.Normal;
                window.Show();
                this.Close();
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

        //minimize window
        private void btnMainMinimze_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void btnBack_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //for lastLoginScreen
            if (LastLoginScreen.Visibility == Visibility.Visible)
            {
                LastLoginScreen.Visibility = Visibility.Hidden;
                LastLoginScreenShadow.Visibility = Visibility.Hidden;

                fnSetFabTask(fabTasks.nul);
                fnSetFabVisible(Visibility.Hidden);

                userMainScreen.Visibility = Visibility.Visible;
                userMainScreenShadow.Visibility = Visibility.Visible;
                actionPanelLabel.Content = "User";

                btnBack.Visibility = Visibility.Hidden;
            }

            //for CurrentEventScreen
            else if (currentEventScreen.Visibility == Visibility.Visible)
            {
                currentEventScreen.Visibility = Visibility.Hidden;
                currentEventScreenShadow.Visibility = Visibility.Hidden;

                fnSetFabTask(fabTasks.nul);
                fnSetFabVisible(Visibility.Hidden);

                userMainScreen.Visibility = Visibility.Visible;
                userMainScreenShadow.Visibility = Visibility.Visible;
                actionPanelLabel.Content = "User";

                btnBack.Visibility = Visibility.Hidden;
            }

            //for ViewEventsScreen
            else if (viewEventsScreen.Visibility == Visibility.Visible){
                viewEventsScreen.Visibility = Visibility.Hidden;
                viewEventsScreenShadow.Visibility = Visibility.Hidden;

                fnSetFabTask(fabTasks.nul);
                fnSetFabVisible(Visibility.Hidden);

                userMainScreen.Visibility = Visibility.Visible;
                userMainScreenShadow.Visibility = Visibility.Visible;
                actionPanelLabel.Content = "User";
                
                btnBack.Visibility = Visibility.Hidden;
            }

            else if(eventDetailScreen.Visibility == Visibility.Visible) {
                eventDetailScreen.Visibility = Visibility.Hidden;
                eventDetailScreenShadow.Visibility = Visibility.Hidden;

                fnSetFabTask(fabTasks.nul);
                fnSetFabVisible(Visibility.Visible);

                userMainScreen.Visibility = Visibility.Visible;
                userMainScreenShadow.Visibility = Visibility.Visible;
                actionPanelLabel.Content = "User";
            }
        }
        #region fab animator
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
        #endregion

        private void btnMainMove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }


        private void signOffUser_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window window = new MainWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.SourceInitialized += (s, a) => window.WindowState = WindowState.Normal;
            window.Show();
            checkOut();
            this.Close();

        }

        private void viewEventsBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //show available events in a list form, when clicked on an event show its details and a button to register

            //also display its cost

            userMainScreen.Visibility = Visibility.Hidden;
            userMainScreenShadow.Visibility = Visibility.Hidden;

            actionPanelLabel.Content = "View Events";
            viewEventsScreen.Visibility = Visibility.Visible;
            viewEventsScreenShadow.Visibility = Visibility.Visible;

            btnBack.Visibility = Visibility.Visible;

            //update dataGrid, only display names and event duration

            UserDAFactory user = new UserDAFactory();
            // dataGrid.ItemsSource = user.viewEvents();
            eventList.ItemsSource = user.viewEvents();
        }

        private void checkLastLoginBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //show new screen with Last login Datetime as a line

            userMainScreen.Visibility = Visibility.Hidden;
            userMainScreenShadow.Visibility = Visibility.Hidden;

            actionPanelLabel.Content = "Last Login";
            LastLoginScreen.Visibility = Visibility.Visible;
            LastLoginScreenShadow.Visibility = Visibility.Visible;

            btnBack.Visibility = Visibility.Visible;
            
            UserDAFactory me = new UserDAFactory();
            lastLogin.Content = DateTime.Now;
            //lastLogin.Content = me.findMe(myName, myPassword);
        }
        public static void WhoAmI(table_User who)
        {
            table_User me = who;
         }
        private void currentEventsBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Show new screen with current registered event, its details(cost, description, etc.) and a button to unregister

            userMainScreen.Visibility = Visibility.Hidden;
            userMainScreenShadow.Visibility = Visibility.Hidden;

            actionPanelLabel.Content = "Current Registered Event";
            currentEventScreen.Visibility = Visibility.Visible;
            currentEventScreenShadow.Visibility = Visibility.Visible;

            btnBack.Visibility = Visibility.Visible;

            fnSetFabTask(fabTasks.unregister);
            fnSetFabVisible(Visibility.Visible);
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //dataGrid.SelectedValue
            //Take value from DB and populate its info in eventDetailScreen

            viewEventsScreen.Visibility = Visibility.Hidden;
            viewEventsScreenShadow.Visibility = Visibility.Hidden;

            actionPanelLabel.Content = "Event Details";
            eventDetailScreen.Visibility = Visibility.Visible;
            eventDetailScreenShadow.Visibility = Visibility.Visible;

            btnBack.Visibility = Visibility.Visible;

            fnSetFabTask(fabTasks.register);
            fnSetFabVisible(Visibility.Visible);
        }

        
    }
}
