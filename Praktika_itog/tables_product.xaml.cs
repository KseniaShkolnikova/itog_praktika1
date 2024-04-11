using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Praktika_itog
{
    /// <summary>
    /// Логика взаимодействия для tables_product.xaml
    /// </summary>
    public partial class tables_product : Page
    {
        private SUSHIK_STOREEntities4 context = new SUSHIK_STOREEntities4();
        public tables_product()
        {
            InitializeComponent();
            gridik.ItemsSource = context.Products.ToList();
        }
        public static bool proverk(TextBox textBox)
        {
            Regex regex = new Regex("[^а-яА-Я]");

            if (regex.IsMatch(textBox.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool proverkcifr(TextBox textBox)
        {
            Regex regex = new Regex("[^0-9]");
            if (regex.IsMatch(textBox.Text))
            {
                return true; 
            }
            else
            {
                return false; 
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (gridik.SelectedItem != null)
            {
                bool result = false;
                var gg = gridik.SelectedItem as Products;
                foreach (var item in context.Goods_Products)
                {
                    if (item.Good_ID == gg.ID_Product)
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
                    context.Products.Remove(gridik.SelectedItem as Products);
                    context.SaveChanges();
                    gridik.ItemsSource = context.Products.ToList();
                }
            }
            else
            {
                MessageBox.Show("Для удаления выберите элемент", "Ошибка удаления");

            }
        }

        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            if (text1.Text!= ""&& text2.Text != "")
            {
                Products c = new Products();
                if (text1.Text.Length <= 50)
                {
                    bool result = false;
                    foreach (var item in context.Products)
                    {
                        if (item.Name_Of_Product == text1.Text)
                        {
                            result = true;
                        }
                    }
                    if (result == true)
                    {
                        MessageBox.Show("Наименование названия продукта должно быть уникальным", "Ошибка добавления");
                    }
                    else
                    {
                        if (proverk(text1) == true)
                        {
                            MessageBox.Show("Данное поле может содержать только русские буквы", "Ошибка добавления");
                        }
                        else
                        {
                            if (proverkcifr(text2) == true)
                            {
                                MessageBox.Show("Данное поле может содержать только цифры", "Ошибка ввода");
                            }
                            else
                            {
                                c.Name_Of_Product = text1.Text;
                                if (Convert.ToInt32(text2.Text) > 0)
                                {
                                    if (proverkcifr(text2) == true)
                                    {
                                        MessageBox.Show("Данное поле может содержать только цифры", "Ошибка добавления");
                                    }
                                    else
                                    {
                                        if (proverkcifr(text2) == true)
                                        {
                                            MessageBox.Show("Данное поле может содержать только цифры", "Ошибка ввода");
                                        }
                                        else
                                        {
                                            c.Colvo = Convert.ToInt32(text2.Text);
                                            context.Products.Add(c);
                                            context.SaveChanges();
                                            gridik.ItemsSource = context.Products.ToList();
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Количество продуктов не может быть меньше или равно 0", "Ошибка добавления");
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Наименование продукта не должно привышать 50 символов", "Ошибка добавления");
                }
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
                bool result = false;
                var gg = gridik.SelectedItem as Goods;
                foreach (var item in context.Goods_Products)
                {
                    if (item.Good_ID == gg.ID_Good)
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
                    var selected = gridik.SelectedItem as Products;
                    if (text1.Text.Length <= 50)
                    {
                        result = false;
                        foreach (var item in context.Goods_Types)
                        {
                            if (item.Name_Of_Good_Type == text1.Text)
                            {
                                result = true;
                            }
                        }
                        if (result == true)
                        {
                            MessageBox.Show("Наименование названия продукта должно быть уникальным", "Ошибка добавления");
                        }
                        else
                        {
                            if (proverk(text1) == true)
                            {
                                MessageBox.Show("Данное поле может содержать только русские буквы", "Ошибка добавления");
                            }
                            else
                            {
                                if (proverkcifr(text2) == true)
                                {
                                    MessageBox.Show("Данное поле может содержать только цифры", "Ошибка добавления");
                                }
                                else
                                {

                                    selected.Name_Of_Product = text1.Text;
                                    if (Convert.ToInt32(text2.Text) > 0)
                                    {
                                        if (!proverkcifr(text2) == true)
                                        {
                                            MessageBox.Show("Данное поле может содержать только цифры", "Ошибка добавления");
                                        }
                                        else
                                        {
                                            selected.Colvo = Convert.ToInt32(text2.Text);
                                            context.SaveChanges();
                                            gridik.ItemsSource = context.Products.ToList();
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("Количество продуктов не может быть меньше или равно 0", "Ошибка изменения");
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Наименование продукта не должно привышать 50 символов", "Ошибка изменения");
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
                var selected = gridik.SelectedItem as Products;
                text1.Text = selected.Name_Of_Product;
                text2.Text = Convert.ToString(selected.Colvo);
            }
        }

        private void json_Click(object sender, RoutedEventArgs e)
        {
            SerDesir serDesir = new SerDesir();
            var listproduct = serDesir.Jsonviser<List<Products>>("product.json");
            foreach ( var item in listproduct )
            {
                var povtor = context.Products.FirstOrDefault(x=>x.Name_Of_Product == item.Name_Of_Product);
                if (povtor == null) 
                {
                    context.Products.Add(item);
                    context.SaveChanges();
                }
            }
            json.IsEnabled = false;
            gridik.ItemsSource = context.Products.ToList();
        }
    }
}
