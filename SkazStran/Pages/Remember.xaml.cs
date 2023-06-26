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
    public partial class Remember : Window
    {
        SkazStranEntities context;
        public Remember(SkazStranEntities cont)
        {
            InitializeComponent();
            context = cont;
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowPassClick(object sender, RoutedEventArgs e)
        {
            int tab1 =Convert.ToInt32(tab.Text);
            string fio1 = fio.Text;
            DateTime dat1 =Convert.ToDateTime(dat.Text);
            string pos1 = pos.Text;
            User user= context.User.Find(fio1);
            if (user != null)
            {
                if (user.tabNum.Equals(tab1))
                {
                    if (user.position.Equals(pos1))
                    {
                        if (user.dateStartWork.Equals(dat1))
                        {
                            MessageBox.Show("Ваш Пароль: " + user.Password);
                        }

                    }
                }
            }
        }
    }
}
