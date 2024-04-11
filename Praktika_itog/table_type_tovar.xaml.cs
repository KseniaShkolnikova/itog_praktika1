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
    /// Логика взаимодействия для table_type_tovar.xaml
    /// </summary>
    public partial class table_type_tovar : Page
    {
        private SUSHIK_STOREEntities4 context = new SUSHIK_STOREEntities4();
        public table_type_tovar()
        {
            InitializeComponent();
            gridik.ItemsSource = context.Goods_Types.ToList();
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
                var gg = gridik.SelectedItem as Goods_Types;
                foreach (var item in context.Goods)
                {
                    if (item.Good_Type_ID == gg.ID_Good_Type)
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
                    context.Goods_Types.Remove(gridik.SelectedItem as Goods_Types);
                    context.SaveChanges();
                    gridik.ItemsSource = context.Goods_Types.ToList();
                }
            }
            else
            {
                MessageBox.Show("Для удаления выберите элемент", "Ошибка удаления");
            }
        }

        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            if (text1.Text != "")
            {
                Goods_Types c = new Goods_Types();
                if (text1.Text.Length <= 50)
                {
                    bool result = false;
                    foreach (var item in context.Goods_Types)
                    {
                        if (item.Name_Of_Good_Type == text1.Text)
                        {
                            result = true;
                        }
                    }
                    if (result == true)
                    {
                        MessageBox.Show("Наименование типа должно быть уникальным", "Ошибка добавления");
                    }
                    else
                    {
                        if (proverk(text1) == true)
                        {
                            MessageBox.Show("Данное поле может содержать только русские буквы", "Ошибка добавления");
                        }
                        else
                        {
                            c.Name_Of_Good_Type = text1.Text;
                            context.Goods_Types.Add(c);
                            context.SaveChanges();
                            gridik.ItemsSource = context.Goods_Types.ToList();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Наименование статуса не должно привышать 50 символов", "Ошибка добавления");

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
                    var selected = gridik.SelectedItem as Goods_Types;
                    if (text1.Text.Length <= 50 && text1.Text != "")
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
                            MessageBox.Show("Наименование типа должно быть уникальным", "Ошибка добавления");
                        }
                        else
                        {
                            if (proverk(text1) == true)
                            {
                                MessageBox.Show("Данное поле может содержать только русские буквы", "Ошибка добавления");
                            }
                            else
                            {
                                selected.Name_Of_Good_Type = text1.Text;
                                context.SaveChanges();
                                gridik.ItemsSource = context.Goods_Types.ToList();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Наименование статуса не должно привышать 50 символов", "Ошибка изменения");
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
                var selected = gridik.SelectedItem as Goods_Types;
                text1.Text = selected.Name_Of_Good_Type;
            }
        }
    }
}
