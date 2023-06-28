using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SkazStran.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        SkazStranEntities context;
        Window window;
        public Authorization(SkazStranEntities cont, Window w)
        {
            InitializeComponent();
            context = cont;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 30);
            timer.Tick += Timer_Tick;
            window = w;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Enter.IsEnabled = true;
            timer.Stop();
        }

        DispatcherTimer timer;
        int countClick = 0;
        private void EnterClick(object sender, RoutedEventArgs e)
        {
            countClick++;
            string log = LoginBox.Text;
            string pass = PasswordBox.Password;
            User user = context.User.Find(log);
            if (user != null)
            {
                if (user.Password.Equals(pass))
                {
                    MessageBox.Show("Вы успешно авторизованы!");
                    countClick = 0;
                    NavigationService.Navigate(new MainMenu(context, window));
                }
                else
                {
                    MessageBox.Show("Ввведен неверный пароль!");
                    if (countClick >= 3)
                    {
                        RemPass.Visibility = Visibility.Visible;
                        timer.Start();
                    }
                }
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует!");
                if (countClick >= 3)
                {
                    Enter.IsEnabled = false;
                    timer.Start();
                }
            }
        }

        private void ResPassClick(object sender, RoutedEventArgs e)
        {
            User us = context.User.Find(LoginBox.Text);
            NavigationService.Navigate(new Remember(us));
        }
    }
}
