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
    /// Логика взаимодействия для tables_tovar_product.xaml
    /// </summary>
    public partial class tables_tovar_product : Page
    {
        private SUSHIK_STOREEntities4 context = new SUSHIK_STOREEntities4();
        public tables_tovar_product()
        {
            InitializeComponent();
            gridik.ItemsSource = context.Goods_Products.ToList();
            combobox.ItemsSource = context.Products.ToList();
            combobox2.ItemsSource = context.Goods.ToList();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            
            if (gridik.SelectedItem != null)
            {
                bool result = false;
                var gg = gridik.SelectedItem as Goods_Products;
                foreach (var item in context.Goods)
                {
                    if (item.ID_Good == gg.Good_ID)
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
                    context.Goods_Products.Remove(gridik.SelectedItem as Goods_Products);
                    context.SaveChanges();
                    gridik.ItemsSource = context.Goods_Products.ToList();
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления", "Ошибка удаления");
            }
        }

        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            if (combobox.SelectedItem!=null && combobox2.SelectedItem!= null)
            {
                Goods_Products c = new Goods_Products();
                c.Products = combobox.SelectedItem as Products;
                c.Goods = combobox2.SelectedItem as Goods;
                context.Goods_Products.Add(c);
                context.SaveChanges();
                gridik.ItemsSource = context.Goods_Products.ToList();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите товар и его состовляющее","Ошибка добавления информации ");
            }
        }

        private void izmen_Click(object sender, RoutedEventArgs e)
        {
            if (gridik.SelectedItem != null)
            {
                bool result = false;
                var gg = gridik.SelectedItem as Goods_Products;
                foreach (var item in context.Goods)
                {
                    if (item.ID_Good == gg.Good_ID)
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
                    var selected = gridik.SelectedItem as Goods_Products;
                    selected.Products = combobox.SelectedItem as Products;
                    selected.Goods = combobox2.SelectedItem as Goods;
                    context.SaveChanges();
                    gridik.ItemsSource = context.Goods_Products.ToList();
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения", "Ошибка изменения");
            }
        }

        private void gridik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridik.SelectedItem != null)
            {
                var selected = gridik.SelectedItem as Goods_Products;
                combobox.SelectedItem = selected.Products;
                combobox2.SelectedItem = selected.Goods;
            }
        }
    }
}
