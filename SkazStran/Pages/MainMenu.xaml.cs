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
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        Window Window;
        SkazStranEntities _context;
        public MainMenu(SkazStranEntities context, Window window)
        {
            InitializeComponent();
            Window = window;
            _context = context;
        }

        private void EscapeClick(object sender, RoutedEventArgs e)
        {
            Window.Close();
        }

        private void OrderClick(object sender, RoutedEventArgs e)
        {
            FrameToBase.Navigate(new OrderPage(_context));
        }
    }
}
