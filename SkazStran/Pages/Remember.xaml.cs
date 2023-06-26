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

namespace SkazStran.Pages
{
    /// <summary>
    /// Логика взаимодействия для Remember.xaml
    /// </summary>
    public partial class Remember : Page
    {
        User _user;
        public Remember(User user)
        {
            InitializeComponent();
            fio.Text=user.Login;
            _user = user;
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ShowPassClick(object sender, RoutedEventArgs e)
        {
            if (_user.Login==fio.Text && _user.tabNum==Convert.ToInt32(tab.Text) && _user.position == pos.Text && _user.dateStartWork == Convert.ToDateTime(dat.Text))
            {
                MessageBox.Show($"Ваш пароль: {_user.Password}", "Пароль", MessageBoxButton.OK, MessageBoxImage.Information) ;
            }
        }
    }
}
