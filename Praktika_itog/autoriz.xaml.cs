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

namespace Praktika_itog
{
    /// <summary>
    /// Логика взаимодействия для autoriz.xaml
    /// </summary>
    public partial class autoriz : Page
    {
        private SUSHIK_STOREEntities4 context = new SUSHIK_STOREEntities4();
        public autoriz()
        {
            InitializeComponent();
        }


        private void vxod_Click(object sender, RoutedEventArgs e)
        {
            bool result = false;
            foreach (var item in context.Autorization_Employees)
            {
                if (item.Logini == login.Text)
                {
                    if (item.Porol == parol.Password)
                    {
                       admin_main admin_Main = new admin_main();
                       admin_Main.Show();
                       result = true;
                    }
                }
            }
            foreach (var item1 in context.Autorization_Clients)
            {
                if (item1.Logini == login.Text)
                {
                    if (item1.Porol == parol.Password)
                    {
                        var porol = item1.Porol;
                        var logini = item1.Logini;
                        clients_main clients_main = new clients_main(porol,logini);
                        clients_main.Show(); 
                        result = true;
                    }
                }
            }
            if (result==false) 
            {
                MessageBox.Show("Ваш логин или пороль был введен неправильно. Попробуйте еще раз");
            }
            else
            {
                Application.Current.Windows.OfType<MainWindow>().First().Close();
            }
            
        }

    }
}
