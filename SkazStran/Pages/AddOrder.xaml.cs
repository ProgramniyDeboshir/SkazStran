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
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Page
    {
        SkazStranEntities context;
        public AddOrder(SkazStranEntities c)
        {
            InitializeComponent();
            context = c;    
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {

            ToyInOrder toyOrd = new ToyInOrder()
            {
                idOrder = Convert.ToInt32(id.Text),

            };
        }
    }
}
