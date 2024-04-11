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
    /// Логика взаимодействия для tables_clients.xaml
    /// </summary>
    public partial class tables_clients : Page
    {
        private SUSHIK_STOREEntities4 context = new SUSHIK_STOREEntities4();
        public tables_clients()
        {
            InitializeComponent();
            gridik.ItemsSource = context.Clients.ToList();
        }
        public static bool proverk(TextBox textBox)
        {
            Regex regex = new Regex("[^а-яА-я]");

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
            bool result = false;
            if (gridik.SelectedItem != null)
            {
                var gg = gridik.SelectedItem as Clients;
                foreach (var item in context.Autorization_Clients)
                {
                    if (item.Clients_ID == gg.ID_Clients)
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
                    context.Clients.Remove(gridik.SelectedItem as Clients);
                    context.SaveChanges();
                    gridik.ItemsSource = context.Clients.ToList();
                }


            }
            else
            {
                MessageBox.Show("Для удаления выберите элемент", "Ошибка удаления");
            }
        }

        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            if (text1.Text!="" && text2.Text!="" )
            {
                Clients c = new Clients();
                if (text1.Text.Length <= 50)
                {
                    if (proverk(text1) == true)
                    {
                        MessageBox.Show("Данное поле может содержать только русские буквы", "Ошибка добавления");
                    }
                    else
                    {
                        c.Names = text1.Text;
                        if (text2.Text.Length <= 50)
                        {
                            if (proverk(text2) == true)
                            {
                                MessageBox.Show("Данное поле может содержать только русские буквы", "Ошибка добавления");
                            }
                            else
                            {
                                c.Surname = text2.Text;
                                if (text3.Text.Length <= 50)
                                {
                                    if (proverk(text3) == true)
                                    {
                                        MessageBox.Show("Данное поле может содержать только русские буквы", "Ошибка добавления");
                                    }
                                    else
                                    {
                                        c.Middle_Name = text3.Text;
                                        context.Clients.Add(c);
                                        context.SaveChanges();
                                        gridik.ItemsSource = context.Clients.ToList();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Отчество не должно привышать 50 символов", "Ошибка добавления");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Фамилия не должна привышать 50 символов", "Ошибка добавления");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Имя не должно привышать 50 символов", "Ошибка добавления");
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
                var gg = gridik.SelectedItem as Clients;
                foreach (var item in context.Autorization_Clients)
                {
                    if (item.Clients_ID == gg.ID_Clients)
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
                    var selected = gridik.SelectedItem as Clients;
                    if (text1.Text.Length <= 50 && text1.Text != "")
                    {
                        if (proverk(text1) == true)
                        {
                            MessageBox.Show("Данное поле может содержать только русские буквы", "Ошибка добавления");
                        }
                        else
                        {
                            selected.Names = text1.Text;
                            if (text2.Text.Length <= 50 && text2.Text != "")
                            {
                                if (proverk(text2) == true)
                                {
                                    MessageBox.Show("Данное поле может содержать только русские буквы", "Ошибка добавления");
                                }
                                else
                                {
                                    selected.Surname = text2.Text;
                                    if (text3.Text.Length <= 50)
                                    {
                                        if (proverk(text3) == true)
                                        {
                                            MessageBox.Show("Данное поле может содержать только русские буквы", "Ошибка добавления");
                                        }
                                        else
                                        {
                                            selected.Middle_Name = text3.Text;
                                            context.SaveChanges();
                                            gridik.ItemsSource = context.Clients.ToList();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Отчество должно состоять не более, чем из 50 символов", "Ошибка добавления");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Фамилия должна состоять не более, чем из 50 символов", "Ошибка добавления");

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Имя должно состоять не более, чем из 50 символов", "Ошибка добавления");

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
                var selected = gridik.SelectedItem as Clients;
                text1.Text = selected.Names;
                text2.Text = selected.Surname;
                text3.Text = selected.Middle_Name;
            }
        }
    }

}

