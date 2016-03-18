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
using emsDALEF;
using emsModels;
using System.Windows.Media.Animation;

namespace ems
{
    /// <summary>
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        static String myName = "";
        static String myPassword = "";
        String fabMain = "#ffff6f00";
        String fabFocus = "#ffa64800";

        enum fabTasks
        {
            nul, remove, add
        }
        fabTasks currentFabTask = fabTasks.nul;
        
        int result;
        public Manager()
        {
            InitializeComponent();
            checkIn();
            statusbarTime.Content = (DateTime.Now.TimeOfDay.Hours > 13 ? (DateTime.Now.TimeOfDay.Hours - 12) : DateTime.Now.TimeOfDay.Hours) + ":" + (DateTime.Now.TimeOfDay.Minutes < 10 ? "0" : "") + (DateTime.Now.TimeOfDay.Hours > 12 ? DateTime.Now.TimeOfDay.Minutes + " PM" : DateTime.Now.TimeOfDay.Minutes + " AM");

            applyColor(fabMain);

            actionPanelLabel.Content = "Manager";
            border.Visibility = Visibility.Visible;

            fnSetFabVisible(Visibility.Hidden);
        }
        private void applyColor(String accentColor)
        {
            SolidColorBrush color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(accentColor));
            actionPanel.Background = color;
            
            fabBg.Fill=new SolidColorBrush((Color)ColorConverter.ConvertFromString(accentColor));
            border.Stroke = color;
            addEventsScreen.Background = color;
            LastLoginScreen.Background = color;
            managerMainScreen.Background = color;
            removeEventsScreen.Background = color;
            viewEventsScreen.Background = color;
        }

        public static void WhoAmI(String a, String b)
        {
            myName = a;
            myPassword = b;
        }

        public void checkIn()
        {
            ManagerDAFactory me = new ManagerDAFactory();
            me.updateCurrentLogin(me.findMyObj(myName, myPassword));
        }
        public void checkOut()
        {
            ManagerDAFactory me = new ManagerDAFactory();
            me.updateLastLogin(me.findMyObj(myName, myPassword));
        }

        //set fab task
        private void fnSetFabTask(fabTasks val)
        {
            currentFabTask = val;
            if (val.Equals(fabTasks.remove))
            {
                fabTask.Source = new BitmapImage(new Uri(@"E:\Desktop\res\ic_cancel_white_48dp.png"));
            }
            else if (val.Equals(fabTasks.add))
            {
                //set image for register
                fabTask.Source = new BitmapImage(new Uri(@"E:\Desktop\res\ic_check_white_48dp.png"));
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
                Window window = new Manager();
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.SourceInitialized += (s, a) => window.WindowState = WindowState.Maximized;
                window.Show();
                this.Close();
            }

            else
            {
                Window window = new Manager();
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
            if (LastLoginScreen.Visibility == Visibility.Visible)
            {
                LastLoginScreen.Visibility = Visibility.Hidden;
                LastLoginScreenShadow.Visibility = Visibility.Hidden;

                fnSetFabTask(fabTasks.nul);
                fnSetFabVisible(Visibility.Hidden);

                managerMainScreen.Visibility = Visibility.Visible;
                managerMainScreenShadow.Visibility = Visibility.Visible;
                actionPanelLabel.Content = "Manager";

                btnBack.Visibility = Visibility.Hidden;
            }

            else if (viewEventsScreen.Visibility == Visibility.Visible)
            {
                viewEventsScreen.Visibility = Visibility.Hidden;
                viewEventsScreenShadow.Visibility = Visibility.Hidden;

                fnSetFabTask(fabTasks.nul);
                fnSetFabVisible(Visibility.Hidden);

                managerMainScreen.Visibility = Visibility.Visible;
                managerMainScreenShadow.Visibility = Visibility.Visible;
                actionPanelLabel.Content = "Manager";

                btnBack.Visibility = Visibility.Hidden;
            }

            else if (removeEventsScreen.Visibility == Visibility.Visible)
            {
                removeEventsScreen.Visibility = Visibility.Hidden;
                removeEventsScreenShadow.Visibility = Visibility.Hidden;

                fnSetFabTask(fabTasks.nul);
                fnSetFabVisible(Visibility.Hidden);

                //removeEventTextBox.Text = "Enter Event ID";


                managerMainScreen.Visibility = Visibility.Visible;
                managerMainScreenShadow.Visibility = Visibility.Visible;
                actionPanelLabel.Content = "Manager";

                btnBack.Visibility = Visibility.Hidden;
            }

            else if (addEventsScreen.Visibility == Visibility.Visible) {
                addEventsScreen.Visibility = Visibility.Hidden;
                addEventsScreenShadow.Visibility = Visibility.Hidden;

                fnSetFabTask(fabTasks.nul);
                fnSetFabVisible(Visibility.Hidden);

                managerMainScreen.Visibility = Visibility.Visible;
                managerMainScreenShadow.Visibility = Visibility.Visible;
                actionPanelLabel.Content = "Manager";

                btnBack.Visibility = Visibility.Hidden;
            }
        }

        private void fab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(removeEventsScreen.Visibility == Visibility.Visible)
            {
                if(currentFabTask == fabTasks.remove)
                {
                    //take value from result (its Event ID) and delete that Event

                    //if deleted show MessageBox
                    MessageBox.Show("Event with ID: " + result + " is deleted");
                }
            }
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
        private void btnMainMove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void signOffManager_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window window = new MainWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.SourceInitialized += (s, a) => window.WindowState = WindowState.Normal;
            window.Show();
            checkOut();
            this.Close();
        }

        #region GotFocus/LostFocus


        private void removeEventTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Enter Event ID")
                tb.Text = string.Empty;
        }

        //this is for TextChanged
        private void TextChangedEventTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (int.TryParse(tb.Text, out result))
            {
                fnSetFabTask(fabTasks.remove);
                fnSetFabVisible(Visibility.Visible);
            }
            else
            {
                fnSetFabTask(fabTasks.nul);
                if(fab != null &&  fab.Visibility == Visibility.Visible)
                    fnSetFabVisible(Visibility.Hidden);
            }
        }

        #endregion


        //mouse button actions

        private void addEventBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Add event and send email also catch exception

            managerMainScreen.Visibility = Visibility.Hidden;
            managerMainScreenShadow.Visibility = Visibility.Hidden;

            actionPanelLabel.Content = "Add events";
            addEventsScreen.Visibility = Visibility.Visible;
            addEventsScreenShadow.Visibility = Visibility.Visible;

            btnBack.Visibility = Visibility.Visible;

            fnSetFabTask(fabTasks.add);
            fnSetFabVisible(Visibility.Visible);

            #region email
            /* email code

                 using System.Net;
                using System.Net.Mail;

                string smtpAddress = "smtp.mail.yahoo.com";
                int portNumber = 587;
                bool enableSSL = true;

                string emailFrom = "easta3000@yahoo.com";
                string password = "";
                string emailTo = "someone@domain.com";
                string subject = "New Events available - EMS";
                string body = "Hello, Please try our new events";

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    // Can set to false, if you are sending pure text.

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                        {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                        }
                }

*/
            #endregion
        }

        private void lastloginBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            managerMainScreen.Visibility = Visibility.Hidden;
            managerMainScreenShadow.Visibility = Visibility.Hidden;

            actionPanelLabel.Content = "Last Login";
            LastLoginScreen.Visibility = Visibility.Visible;
            LastLoginScreenShadow.Visibility = Visibility.Visible;

            ManagerDAFactory me = new ManagerDAFactory();
            lastLoginBGTxt.Content = me.findMe(myName, myPassword);

            btnBack.Visibility = Visibility.Visible;
        }

        private void removeBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Takes event ID and removes that event

            managerMainScreen.Visibility = Visibility.Hidden;
            managerMainScreenShadow.Visibility = Visibility.Hidden;

            actionPanelLabel.Content = "Remove events";
            removeEventsScreen.Visibility = Visibility.Visible;
            removeEventsScreenShadow.Visibility = Visibility.Visible;

            btnBack.Visibility = Visibility.Visible;

            fnSetFabTask(fabTasks.remove);
            fnSetFabVisible(Visibility.Hidden);
        }

        private void viewChangeBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //view all events, only show events in dataGrid

            managerMainScreen.Visibility = Visibility.Hidden;
            managerMainScreenShadow.Visibility = Visibility.Hidden;

            actionPanelLabel.Content = "View Events";
            viewEventsScreen.Visibility = Visibility.Visible;
            viewEventsScreenShadow.Visibility = Visibility.Visible;

            ManagerDAFactory man = new ManagerDAFactory();
            //dataGrid.ItemsSource = man.viewEvents();
            eventList.ItemsSource = man.viewEvents();
            btnBack.Visibility = Visibility.Visible;
        }
        
    }
}
