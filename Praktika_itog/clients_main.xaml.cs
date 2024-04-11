using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Praktika_itog
{
    /// <summary>
    /// Логика взаимодействия для clients_main.xaml
    /// </summary>
    public partial class clients_main : Window
    {
        private SUSHIK_STOREEntities4 context = new SUSHIK_STOREEntities4();
        List<class_pokupka_clien> list = new List<class_pokupka_clien>();
        Praktika_itog.Goods gg;
        Praktika_itog.Goods gg2;
        int idclient;
        int idorders;
        decimal summ;

        public clients_main(string porol, string logini)
        {
            InitializeComponent();
            gridik.ItemsSource = context.Goods.ToList();
            gridik2.ItemsSource = list;
            combobox.ItemsSource = context.Payment_Types.ToList();
            Orders c = new Orders();
            c.Statuss = context.Statuss.ToList()[2];
            foreach (var item in context.Autorization_Clients)
            {
                if (item.Porol == porol && item.Logini == logini)
                {
                    foreach (var item2 in context.Clients)
                    {
                        if (item2.ID_Clients == item.ID_Autorization)
                        {
                            c.Clients = item2;
                            idclient = item.ID_Autorization;
                        }
                    }
                }
            }
            string date = DateTime.Now.ToString("dd.MM.yyyy");
            c.Date_Of_Payment = date;
            c.Payment_Types = context.Payment_Types.ToList()[0];
            context.Orders.Add(c);
            context.SaveChanges();
            idorders = c.ID_Order;
            textblock.Text = "К оплате 0";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (gridik.SelectedItem != null)
            {
                list.Add(new class_pokupka_clien { Name_of_product = gg.Name_Of_Good, Price = gg.Good_Price, idgoods = gg.ID_Good, idorder = idorders});
                gridik2.ItemsSource = list;
                gridik2.Items.Refresh();
                summ += gg.Good_Price;
                textblock.Text = "К оплате " + summ;
            }
        }

        private void gridik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gg = gridik.SelectedItem as Goods;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (gridik2.SelectedItem != null)
            {
                list.Remove((class_pokupka_clien)gridik2.SelectedItem);
                gridik2.ItemsSource = list;
                gridik2.Items.Refresh();
                summ -= gg.Good_Price;
                textblock.Text = "К оплате " + summ;
            }

        }

        private void gridik2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gg2 = gridik.SelectedItem as Goods;
        }
        private bool proverk(string input)
        {
            decimal result;
            bool isValid = decimal.TryParse(input, out result);
            if (isValid)
            {
                int commaCount = input.Count(c => c == ',');
                if (commaCount > 1)
                {
                    isValid = false;
                }
            }
            return isValid;


        }

        private void zakaz_Click(object sender, RoutedEventArgs e)
        {
            if (combobox.SelectedItem!=null && textbox.Text != null && list.Count !=0)
            {
                if (proverk(textbox.Text) == false)
                {
                    MessageBox.Show("Пожалуйста, удалите старонние символы", "Неккоректный ввод");
                }
                else
                {
                    decimal polz = Convert.ToDecimal(textbox.Text);
                    if (polz < summ)
                    {
                        MessageBox.Show("Пожалуйста, введите сумму необходимую для возможности оплаты заказа", "Недостаточно средств");
                    }
                    else
                    {
                        decimal itog = polz - summ;
                        foreach (var item in context.Orders)
                        {
                            if (item.ID_Order == idorders)
                            {
                                var selected = item;
                                selected.Statuss = context.Statuss.ToList()[0];
                                selected.Clients = context.Clients.ToList()[idclient];
                                selected.Payment_Types = combobox.SelectedItem as Payment_Types;
                            }
                        }
                        decimal suma = 0;
                        foreach (var item in list)
                        {
                            Checks chek = new Checks();
                            chek.Good_ID = item.idgoods;
                            chek.Order_ID = item.idorder;
                            chek.Employees = context.Employees.ToList()[1];
                            string date = DateTime.Now.ToString("dd.MM.yyyy");
                            chek.Date_Of_Payment = date;
                            suma += item.Price;
                            chek.Summ = suma;
                            context.Checks.Add(chek);

                        }
                        context.SaveChanges();
                        File.WriteAllText("C:\\Users\\user1\\Desktop\\check.txt", "\n             SUSHIK_STORE: ");
                        File.AppendAllText("C:\\Users\\user1\\Desktop\\check.txt", "\n          Кассовы чек номер" + idorders);
                        foreach (var item in list)
                        {
                            File.AppendAllText("C:\\Users\\user1\\Desktop\\check.txt", "\n       " + item.Name_of_product + "------------" + item.Price);
                        }
                        File.AppendAllText("C:\\Users\\user1\\Desktop\\check.txt", "\n  Итого к оплате: " + summ);
                        File.AppendAllText("C:\\Users\\user1\\Desktop\\check.txt", "\n  Внесено: " + polz);
                        File.AppendAllText("C:\\Users\\user1\\Desktop\\check.txt", "\n  Способ оплаты: " + combobox.Text);
                        File.AppendAllText("C:\\Users\\user1\\Desktop\\check.txt", "\n  Сдача: " + itog + "\n\n\n");
                        MessageBox.Show("Еда скоро будет готова!!!", "Спасибо за заказ");
                        list.Clear();
                        gridik2.ItemsSource = list;
                        gridik2.Items.Refresh();
                        textbox.Text = null;
                        textblock.Text = null;
                        combobox.ItemsSource = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля","Пустые поля");
            }
        }

        private void vixod_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
    }
}
