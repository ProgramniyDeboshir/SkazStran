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
    /// Логика взаимодействия для MastersPage.xaml
    /// </summary>
    public partial class MastersPage : Page
    {
        SkazStranEntities context;
        public MastersPage(SkazStranEntities _cont)
        {
            InitializeComponent();
            context = _cont;
            MastersDATA.ItemsSource = context.Master.ToList();
            var statList = context.State.ToList();
            statList.Insert(0, new State() { title = "Все категории" });
            filtrBox.ItemsSource = statList;
            filtrBox.SelectedIndex = 0  ;
        }

        void FiltrData()
        {
            var list = context.Master.ToList();
            if (filtrBox.SelectedIndex != 0)
            {
                State state = filtrBox.SelectedItem as State;
                list = list.Where(x=>Convert.ToInt32(x.State)==state.id).ToList();
            }
            if (!string.IsNullOrWhiteSpace(searchBox.Text))
            {
                list = list.Where(x => x.FIO.Contains(searchBox.Text)).ToList();
            }
            MastersDATA.ItemsSource = list;
        }
        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            FiltrData();
        }

        private void ChangeCategory(object sender, SelectionChangedEventArgs e)
        {
            FiltrData();
        }
    }
}
