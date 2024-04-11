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
    /// Логика взаимодействия для table_status.xaml
    /// </summary>
    public partial class table_status : Page
    {
        private SUSHIK_STOREEntities4 context = new SUSHIK_STOREEntities4();
        public table_status()
        {
            InitializeComponent();
            gridik.ItemsSource = context.Statuss.ToList();
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

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (gridik.SelectedItem != null)
            {
                bool result = false;
                foreach (var item in context.Orders)
                {
                    if (item.Statuss_ID == (gridik.SelectedItem as Statuss).ID_Statuss)
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
                    context.Statuss.Remove(gridik.SelectedItem as Statuss);
                    context.SaveChanges();
                    gridik.ItemsSource = context.Statuss.ToList();
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
                Statuss c = new Statuss();
                if (text1.Text.Length <= 50)
                {
                    bool result = false;
                    foreach (var item in context.Statuss)
                    {
                        if (item.Name_Of_Status == text1.Text)
                        {
                            result = true;
                        }
                    }
                    if (result == true)
                    {
                        MessageBox.Show("Наименование статуса должно быть уникальным", "Ошибка добавления");
                    }
                    else
                    {
                        if (proverk(text1) == true)
                        {
                            MessageBox.Show("Данное поле может содержать только русские буквы", "Ошибка добавления");
                        }
                        else
                        {
                            c.Name_Of_Status = text1.Text;
                            context.Statuss.Add(c);
                            context.SaveChanges();
                            gridik.ItemsSource = context.Statuss.ToList();
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
                foreach (var item in context.Orders)
                {
                    if (item.Statuss_ID == (gridik.SelectedItem as Statuss).ID_Statuss)
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
                    var selected = gridik.SelectedItem as Statuss;
                    if (text1.Text != "")
                    {
                        result = false;
                        foreach (var item in context.Statuss)
                        {
                            if (item.Name_Of_Status == text1.Text)
                            {
                                result = true;
                            }
                        }
                        if (result == true)
                        {
                            MessageBox.Show("Наименование статуса должно быть уникальным", "Ошибка добавления");
                        }
                        else
                        {
                            if (proverk(text1) == true)
                            {
                                MessageBox.Show("Данное поле может содержать только русские буквы", "Ошибка добавления");
                            }
                            else
                            {
                                selected.Name_Of_Status = text1.Text;
                                context.SaveChanges();
                                gridik.ItemsSource = context.Statuss.ToList();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Наименование статуса не должно привышать 50 символов", "Ошибка добавления");
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
                var selected = gridik.SelectedItem as Statuss;
                text1.Text = selected.Name_Of_Status;
            }
        }
    }
}
