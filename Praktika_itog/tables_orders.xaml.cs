using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для tables_orders.xaml
    /// </summary>
    public partial class tables_orders : Page
    {
        private SUSHIK_STOREEntities4 context = new SUSHIK_STOREEntities4();
        public tables_orders()
        {
            InitializeComponent();
            gridik.ItemsSource = context.Orders.ToList();
            combobox2.ItemsSource = context.Statuss.ToList();
            combobox3.ItemsSource = context.Clients.ToList();
            combobox1.ItemsSource = context.Payment_Types.ToList();
            datapick.IsEnabled = false;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (gridik.SelectedItem != null)
            {
                var gg = gridik.SelectedItem as Orders;
                bool result = false;
                foreach (var item in context.Checks)
                {
                    if (item.Order_ID == gg.ID_Order)
                    {
                        result = true;
                        break;
                    }
                }
                if (result == true)
                {

                    MessageBox.Show("Данную запись нельзя удалить, так как она используется БД", "Ошибка удаления");
                }
                else
                {
                    context.Orders.Remove(gridik.SelectedItem as Orders);
                    context.SaveChanges();
                    gridik.ItemsSource = context.Orders.ToList();
                }
            }
            else
            {
                MessageBox.Show("Для удаления выберите элемент", "Ошибка удаления");
            }
        }

        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            if ( combobox2.SelectedItem!= null && combobox3.SelectedItem!=null && datapick.Text!="" && combobox1.SelectedItem!=null)
            {
                Orders c = new Orders();
                c.Statuss = combobox2.SelectedItem as Statuss;
                c.Clients = combobox3.SelectedItem as Clients;
                c.Date_Of_Payment = DateTime.Now.ToString("dd.MM.yyyy");
                c.Payment_Types = combobox1.SelectedItem as Payment_Types;
                context.Orders.Add(c);
                context.SaveChanges();
                gridik.ItemsSource = context.Orders.ToList();
            }
            else
            {
                MessageBox.Show("Для добавления зполните все поля, помеченные *", "Ошибка добавления");
            }
        }

        private void izmen_Click(object sender, RoutedEventArgs e)
        {
            if (gridik.SelectedItem != null)
            {
                var gg = gridik.SelectedItem as Orders;
                bool result = false;
                foreach (var item in context.Checks)
                {
                    if (item.Order_ID == gg.ID_Order)
                    {
                        result = true;
                        break;
                    }
                }
                if (result == true)
                {

                    MessageBox.Show("Данную запись нельзя изменить, так как она используется БД", "Ошибка изменения");
                }
                else
                {
                    var selected = gridik.SelectedItem as Orders;
                    if (combobox2.SelectedItem != null && combobox3.SelectedItem != null && datapick.Text != "" && combobox1.SelectedItem != null)
                    {
                        selected.Statuss = combobox2.SelectedItem as Statuss;
                        selected.Clients = combobox3.SelectedItem as Clients;
                        selected.Date_Of_Payment = datapick.Text;
                        selected.Payment_Types = combobox1.SelectedItem as Payment_Types;
                        context.SaveChanges();
                        gridik.ItemsSource = context.Orders.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Для изменения заполните все поля, помеченные *", "Ошибка изменения");

                    }
                }
                    
            }
            else
            {
                MessageBox.Show("Для изменения выберите элемент", "Ошибка изменения");
            }
        }

        private void gridik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridik.SelectedItem != null)
            {
                datapick.IsEnabled = true;
                var selected = gridik.SelectedItem as Orders;
                combobox2.SelectedItem = selected.Statuss;
                combobox3.SelectedItem = selected.Clients;
                datapick.Text = selected.Date_Of_Payment;
                combobox1 .SelectedItem = selected.Payment_Types;
            }
        }
    }
}
