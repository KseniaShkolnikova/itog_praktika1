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
    /// Логика взаимодействия для tables_employ.xaml
    /// </summary>
    public partial class tables_employ : Page
    {
        private SUSHIK_STOREEntities4 context = new SUSHIK_STOREEntities4();
        public tables_employ()
        {
            InitializeComponent();
            gridik.ItemsSource = context.Employees.ToList();
            combobox2.ItemsSource = context.Job_Title.ToList();
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
            if (gridik.SelectedItem != null)
            {
                var gg = gridik.SelectedItem as Employees;
                bool result = false;
                foreach (var item in context.Autorization_Employees)
                {
                    if (item.Employee_ID == gg.ID_Employee)
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
                    context.Employees.Remove(gridik.SelectedItem as Employees);
                    context.SaveChanges();
                    gridik.ItemsSource = context.Employees.ToList();
                }
            }
            else
            {
                MessageBox.Show("Для удаления выберите элемент", "Ошибка удаления");
            }
        }

        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            if(text1.Text!="" && text2.Text!=""  && text4.Text!="" && combobox2.SelectedItem != null)
            {
                Employees c = new Employees();
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
                                        if (text4.Text.Length != 12 || text4.Text.Substring(0, 3) != "+79")
                                        {
                                            MessageBox.Show("Вы ввели неправильный номер", "Ошибка добавления");
                                            text4.Text = null;
                                        }
                                        else
                                        {
                                            bool result = false;
                                            foreach (var item in context.Employees)
                                            {
                                                if (item.Phone_Number == text4.Text)
                                                {
                                                    result = true;
                                                }
                                            }
                                            if (result != true)
                                            {
                                                c.Phone_Number = text4.Text;
                                                c.Job_Title = combobox2.SelectedItem as Job_Title;
                                                context.Employees.Add(c);
                                                context.SaveChanges();
                                                gridik.ItemsSource = context.Employees.ToList();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Номер телефона на уникален. Попробуйте еще раз", "Ошибка добавления");
                                            }
                                        }
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
                var gg = gridik.SelectedItem as Employees;
                bool result = false;
                foreach (var item in context.Autorization_Employees)
                {
                    if (item.Employee_ID == gg.ID_Employee)
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
                    var selected = gridik.SelectedItem as Employees;
                    if (text1.Text.Length <= 50)
                    {
                        if (proverk(text1) == true)
                        {
                            MessageBox.Show("Данное поле может содержать только русские буквы", "Ошибка добавления");
                        }
                        else
                        {
                            selected.Names = text1.Text;
                            if (text2.Text.Length <= 50)
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
                                            selected.Job_Title = combobox2.SelectedItem as Job_Title;
                                            if (text4.Text.Length != 12 || text4.Text.Substring(0, 3) != "+79")
                                            {
                                                MessageBox.Show("Вы ввели неправильный номер");
                                                text4.Text = selected.Phone_Number;
                                            }
                                            else
                                            {
                                                selected.Phone_Number = text4.Text;
                                                context.SaveChanges();
                                                gridik.ItemsSource = context.Employees.ToList();
                                            }
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
                var selected = gridik.SelectedItem as Employees;
                text1.Text = selected.Names;
                text2.Text = selected.Surname;
                text3.Text = selected.Middle_Name;
                text4.Text = selected.Phone_Number;
                combobox2.SelectedItem = selected.Job_Title;
            }
        }
    }
}
