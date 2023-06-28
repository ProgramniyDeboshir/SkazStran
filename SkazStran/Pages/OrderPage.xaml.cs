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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        SkazStranEntities context;
        public OrderPage(SkazStranEntities _cont)
        {
            InitializeComponent();
            context = _cont;
            OrderData.ItemsSource = context.ToyInOrder.ToList(); 

        }

        private void EditClick(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {

        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddOrder(context));
        }
    }
}
