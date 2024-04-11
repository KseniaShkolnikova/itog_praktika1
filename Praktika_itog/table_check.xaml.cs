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
    /// Логика взаимодействия для table_check.xaml
    /// </summary>
    public partial class table_check : Page
    {
        private SUSHIK_STOREEntities4 context = new SUSHIK_STOREEntities4();
        public table_check()
        {
            InitializeComponent();
            gridik.ItemsSource = context.Checks.ToList();
            combobox3.ItemsSource = context.Orders.ToList();
            combobox4.ItemsSource = context.Employees.ToList();
            combobox5.ItemsSource = context.Goods.ToList();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (gridik.SelectedItem != null)
            {
                context.Checks.Remove(gridik.SelectedItem as Checks);
                context.SaveChanges();
                gridik.ItemsSource = context.Checks.ToList();
            }
            else
            {
                MessageBox.Show("Для удаления выберите элемент", "Ошибка удаления");
            }
        }

        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            if (datapick.Text !="" && combobox3.SelectedItem != null && combobox4.SelectedItem != null && combobox5.SelectedItem != null)
            {
                Checks c = new Checks();
                c.Date_Of_Payment = Convert.ToString(datapick.Text);
                c.Orders = combobox3.SelectedItem as Orders;
                c.Employees = combobox4.SelectedItem as Employees;
                c.Goods = combobox5.SelectedItem as Goods;
                var i = combobox5.SelectedItem as Goods;
                decimal price = 0;
                var gg = context.Checks.ToList();
                bool result = true;
                foreach (var item in gg)
                {
                    if (item.Order_ID == Convert.ToInt32(combobox3.Text))
                    {
                        foreach (var item1 in context.Goods)
                        {
                            if (item1.ID_Good == i.ID_Good)
                            {
                                price = item.Summ + item1.Good_Price;
                                result = false;
                            }
                        }
                    }
                }
                if (result == true)
                {
                    price = i.Good_Price;
                }
                c.Summ = price;
                context.Checks.Add(c);
                context.SaveChanges();
                gridik.ItemsSource = context.Checks.ToList();
            }
            else
            {
                MessageBox.Show("Для добавления зполните все поля, плмеченные *", "Ошибка добавления");
            }
           
        }

        private void izmen_Click(object sender, RoutedEventArgs e)
        {
            if (gridik.SelectedItem != null)
            {
                var selected = gridik.SelectedItem as Checks;
                selected.Date_Of_Payment = Convert.ToString(datapick);
                selected.Orders = combobox3.SelectedItem as Orders;
                selected.Employees = combobox4.SelectedItem as Employees;
                selected.Goods = combobox5.SelectedItem as Goods;
                var i = combobox5.SelectedItem as Goods;
                decimal price = 0;
                var gg = context.Checks.ToList();
                bool result = true;
                foreach (var item in gg)
                {
                    if (item.Order_ID == Convert.ToInt32(combobox3.Text))
                    {
                        foreach (var item1 in context.Goods)
                        {
                            if (item1.ID_Good == item.Good_ID)
                            {
                                price = item.Summ + item1.Good_Price;
                                result = false;
                            }
                        }
                    }
                }
                if (result == true)
                {
                    price = i.Good_Price;
                }
                selected.Summ = price;
                context.SaveChanges();
                gridik.ItemsSource = context.Statuss.ToList();
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
                var selected = gridik.SelectedItem as Checks;
                datapick.Text = Convert.ToString(selected.Date_Of_Payment);
                combobox3.SelectedItem = selected.Orders;
                combobox4.SelectedItem = selected.Employees;
                combobox5.SelectedItem = selected.Goods;
            }
        }
    }
}
