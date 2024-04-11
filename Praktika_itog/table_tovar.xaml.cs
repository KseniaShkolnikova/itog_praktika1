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
    /// Логика взаимодействия для table_tovar.xaml
    /// </summary>
    public partial class table_tovar : Page
    {
        private SUSHIK_STOREEntities4 context = new SUSHIK_STOREEntities4();
        public table_tovar()
        {
            InitializeComponent();
            gridik.ItemsSource = context.Goods.ToList();
            combobox.ItemsSource = context.Goods_Types.ToList();
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
        private bool provrkcifr(string input)
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


            private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (gridik.SelectedItem != null)
            {
                bool result = false;
                foreach (var item in context.Checks)
                {
                    if (item.Good_ID == (gridik.SelectedItem as Goods).ID_Good)
                    {
                        result = true; break;
                    }
                }
                if (result == true)
                {
                    MessageBox.Show("Данную запись нельзя удалить, так как она используется БД", "Ошибка удаления");
                }
                else
                {
                    context.Goods.Remove(gridik.SelectedItem as Goods);
                    context.SaveChanges();
                    gridik.ItemsSource = context.Goods.ToList();
                }
            }
            else
            {
                MessageBox.Show("Для удаления выберите элемент", "Ошибка удаления");
            }
        }

        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            if (text1.Text!="" && text2.Text !="" && combobox.SelectedItem != null)
            {
                Goods c = new Goods();
                if (text1.Text.Length <= 100)
                {
                    bool result = false;
                    foreach (var item in context.Goods)
                    {
                        if (item.Name_Of_Good == text1.Text)
                        {
                            result = true;
                        }
                    }
                    if (result == true)
                    {
                        MessageBox.Show("Наименование названия товара должно быть уникальным", "Ошибка добавления");
                    }
                    else
                    {
                        if (proverk(text1) == true)
                        {
                            MessageBox.Show("Данное поле может содержать только русские буквы", "Ошибка добавления");
                        }
                        else
                        {
                            c.Name_Of_Good = text1.Text;
                            if (proverkcifr(text2) == true)
                            {
                                MessageBox.Show("В данное поле нельзя вводить буквы", "Ошибка ввода");
                            }
                            else
                            {
                                if (Convert.ToDecimal(text2.Text) < 999999999999)
                                {
                                    if (provrkcifr(text2.Text) == false)
                                    {
                                        MessageBox.Show("Данное поле может содержать только цифры", "Ошибка добавления");
                                    }
                                    else
                                    {
                                        c.Good_Price = Convert.ToDecimal(text2.Text);
                                        c.Goods_Types = combobox.SelectedItem as Goods_Types;
                                        context.Goods.Add(c);
                                        context.SaveChanges();
                                        gridik.ItemsSource = context.Goods.ToList();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Вы ввели слишком большое число", "Ошибка добавления");
                                }
                            }
                            }
                        }
                }
                else
                {
                    MessageBox.Show("Название товара не должно привышать 100 символов", "Ошибка добавления");
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
                foreach (var item in context.Checks)
                {
                    if (item.Good_ID == (gridik.SelectedItem as Goods).ID_Good)
                    {
                        result = true; break;
                    }
                }
                if (result == true)
                {
                    MessageBox.Show("Данную запись нельзя изменить, так как она используется БД", "Ошибка изменения");
                }
                else
                {
                    var selected = gridik.SelectedItem as Goods;
                    if (text1.Text != "" && text1.Text.Length <= 100)
                    {
                         result = false;
                        foreach (var item in context.Goods)
                        {
                            if (item.Name_Of_Good == text1.Text)
                            {
                                result = true;
                            }
                        }
                        if (result == true)
                        {
                            MessageBox.Show("Наименование названия товара должно быть уникальным", "Ошибка добавления");
                        }
                        else
                        {
                            if (proverk(text1) == true)
                            {
                                MessageBox.Show("Данное поле может содержать только русские буквы", "Ошибка добавления");
                            }
                            else
                            {
                                selected.Name_Of_Good = text1.Text;
                                if (proverkcifr(text2))
                                {
                                    MessageBox.Show("В данное поле нельзя вводить буквы", "Ошибка ввода");
                                }
                                else
                                {
                                    if (text2.Text != "" && Convert.ToDecimal(text2.Text) < 999999999999)
                                    {
                                        if (proverk(text2) == false)
                                        {
                                            MessageBox.Show("Данное поле может содержать только цифры", "Ошибка добавления");
                                        }
                                        else
                                        {
                                            selected.Good_Price = Convert.ToDecimal(text2.Text);
                                            selected.Goods_Types = combobox.SelectedItem as Goods_Types;
                                            context.SaveChanges();
                                            gridik.ItemsSource = context.Goods.ToList();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Вы ввели слишком большое число", "Ошибка изменения");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Название товара не должно привышать 100 символов", "Ошибка изменения");

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
                var selected = gridik.SelectedItem as Goods;
                text1.Text = selected.Name_Of_Good;
                text2.Text = Convert.ToString(selected.Good_Price);
                combobox.SelectedItem = selected.Goods_Types;
            }
        }

    }
}
