using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.IO;
using System.Security.Cryptography.Pkcs;

namespace Praktika_itog
{
    /// <summary>
    /// Логика взаимодействия для admin_main.xaml
    /// </summary>
    public partial class admin_main : Window
    {
        private SUSHIK_STOREEntities4 context = new SUSHIK_STOREEntities4();
        public admin_main()
        {
            InitializeComponent();
            string[] massiv = new string[] { "Авторизация (клиенты)", "Клиенты", "Должности", "Авторизация (сотрудники)", "Сотрудники", "Типы товаров", "Продукты (составляющие товаров)", "Товары", "Товары и их продукты", "Статусы заказов", "Заказы", "Типы оплаты", "Чеки" };
            combobox.ItemsSource = massiv ;
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (combobox.SelectedIndex)
            {
                case 0:
                    frame.Content = new tbles_autor_clients();
                    break;
                case 1:
                    frame.Content = new tables_clients();
                    break;
                case 2:
                    frame.Content = new table_job_title();
                    break;
                case 3:
                    frame.Content = new tables_autoriz_emplo();
                    break;
                case 4:
                    frame.Content = new tables_employ();
                    break;
                case 5:
                    frame.Content = new table_type_tovar();
                    break;
                case 6:
                    frame.Content = new tables_product();
                    break;
                case 7:
                    frame.Content = new table_tovar();
                    break;
                case 8:
                    frame.Content = new tables_tovar_product();
                    break;
                case 9:
                    frame.Content = new table_status();
                    break;
                case 10:
                    frame.Content = new tables_orders();
                    break;
                case 11:
                    frame.Content = new table_type_peyment();
                    break;
                case 12:
                    frame.Content = new table_check();
                    break;
            }
        }

        private void vixod_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void backup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = @"DATA Source= DESKTOP-P4T6AUH\SQLEXPRESS; Initial Catalog = SUSHIK_STORE;" + "Integrated Security = SSPI; Pooling=False";
                sqlConnection.Open();
                string backupzapros = $@"BACKUP DATABASE SUSHIK_STORE TO DISK = 'C:\Users\Public\Documents\YY\\SUSHIK_STORE.bak'";
                using (var cc = new SqlCommand(backupzapros, sqlConnection))
                {
                    cc.ExecuteNonQuery();
                }
                sqlConnection.Close();
                MessageBox.Show("Бэкап сохранене по пути:'C:\\Users\\Public\\Documents\\YY\\\\SUSHIK_STORE.bak' ","Бэкап выполнен");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Бэкап не был создан","Неудача");
            }
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder chek = new StringBuilder();
            var gg = context.Checks.ToList();
            bool result = false;
            foreach (var item in gg)
            {
                int kk;
                if (result == true)
                {
                     kk = item.ID_Check-1;
                }
                else
                {
                    kk = item.ID_Check;
                }
                chek.AppendLine($"Кассовый чек №{kk}");
                foreach (var item2 in context.Goods)
                {
                    if (item.Good_ID == item2.ID_Good)
                    {
                        foreach(var item3 in context.Orders)
                        {
                            if (item3.ID_Order == item.Order_ID)
                            {
                                chek.AppendLine($"{item2.Name_Of_Good} ----- {item2.Good_Price}");
                                result = true;
                            }
                        }
                        
                    }
                }
                chek.AppendLine();
                chek.AppendLine($"Итого к оплате: {item.Summ}");
                chek.AppendLine();
                File.AppendAllText($"C:\\Users\\user1\\Desktop\\чеки.txt", chek.ToString());
                chek.Clear();
            }
            MessageBox.Show("Все чеки были выгружены","Ура!!!");

        }
    }
}
