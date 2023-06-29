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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SkazStran.Pages
{
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    
    public partial class Clients : Page
    {
        SkazStranEntities context;
        public Clients(SkazStranEntities _cont)
        {
            InitializeComponent();
            context = _cont;
            ClientsDATA.ItemsSource = context.Client.ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddClient(context));
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            Client clie = ClientsDATA.SelectedItem as Client;
            NavigationService.Navigate(new AddClient(context, clie));
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result= MessageBox.Show("Вы точно хотите удалить клиета?","Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Client clie = ClientsDATA.SelectedItem as Client;
                    context.Client.Remove(clie);
                    context.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                }
            }
        }
    }
}
