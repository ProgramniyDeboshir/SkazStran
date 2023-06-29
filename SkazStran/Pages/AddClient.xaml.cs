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
using System.Xml.Linq;

namespace SkazStran.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    
    public partial class AddClient : Page
    {
       
        SkazStranEntities context;
        Client client;

        public AddClient(SkazStranEntities с)
        {
            InitializeComponent();
            context = с;

        }
        public AddClient(SkazStranEntities с, Client clie)
        {
            InitializeComponent();
            context = с;
            client = clie;
            AddAU.Content = "Редактировать";
            AddAU.Click += AddAU_Click;
            FIOBOX.Text = client.name;
            PASSBOX.Text = client.passport;
        }

        private void AddAU_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client.name = FIOBOX.Text;
                client.passport = PASSBOX.Text;
                context.SaveChanges();
                NavigationService.Navigate(new Clients(context));
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void AddClientClick(object sender, RoutedEventArgs e)
        {
            try {
                Client cli = new Client() 
                { num = context.Client.ToList().Last().num+1,
                    name = FIOBOX.Text,
                    passport = PASSBOX.Text };
                context.Client.Add(cli);
                context.SaveChanges();
                NavigationService.Navigate(new Clients(context));
            }
            catch 
            {
                MessageBox.Show("Ошибка!");
            }
        }
        

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
