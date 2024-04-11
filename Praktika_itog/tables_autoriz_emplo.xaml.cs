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
    /// Логика взаимодействия для tables_autoriz_emplo.xaml
    /// </summary>
    public partial class tables_autoriz_emplo : Page
    {
        private SUSHIK_STOREEntities4 context = new SUSHIK_STOREEntities4();    
        public tables_autoriz_emplo()
        {
            InitializeComponent();
            gridik.ItemsSource = context.Autorization_Employees.ToList();
            combobox.ItemsSource = context.Employees.ToList();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (gridik.SelectedItem != null)
            {
                bool result = false;
                var gg = gridik.SelectedItem as Autorization_Employees;
                foreach (var item in context.Employees)
                {
                    if (item.ID_Employee == gg.Employee_ID)
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
                    context.Autorization_Employees.Remove(gridik.SelectedItem as Autorization_Employees);
                    context.SaveChanges();
                    gridik.ItemsSource = context.Autorization_Employees.ToList();
                }
            }
            else
            {
                MessageBox.Show("Для удаления выберите элемент", "Ошибка удаления");
            }
        }

        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            if (text1.Text!="" && text2.Text != "")
            {
                Clients clients = new Clients();
                clients.Names = "d";
                clients.Surname = "d";
                try
                {
                    context.Clients.Remove(clients);
                    context.SaveChanges();
                }
                catch 
                {

                }
                context.Clients.Add(clients);
                context.SaveChanges();
                Autorization_Clients autorization_Clients = new Autorization_Clients();
                if (text1.Text.Any(char.IsWhiteSpace) == true && text2.Text.Any(char.IsWhiteSpace) == true)
                {

                }
                else
                {
                    autorization_Clients.Logini = text1.Text;
                    autorization_Clients.Porol = text2.Text;
                    autorization_Clients.Clients = clients;
                    context.Autorization_Clients.Add(autorization_Clients);
                    try
                    {
                        context.SaveChanges();
                        context.Autorization_Clients.Remove(autorization_Clients);
                        context.Clients.Remove(clients);
                        context.SaveChanges();
                        Autorization_Employees c = new Autorization_Employees();
                        if (text1.Text != "" && text1.Text.Length <= 30)
                        {
                            c.Logini = text1.Text;
                            if (text2.Text != "" && text2.Text.Length <= 10 && text2.Text.Length >= 8)
                            {
                                c.Porol = text2.Text;
                                if (combobox.SelectedItem != null)
                                {
                                    c.Employees = combobox.SelectedItem as Employees;
                                    context.Autorization_Employees.Add(c);
                                    context.SaveChanges();
                                    gridik.ItemsSource = context.Autorization_Employees.ToList();
                                }
                                else
                                {
                                    MessageBox.Show("Для добавления необходимо заполнить все поля, помеченные *", "Ошибка добавления");

                                }
                            }
                            else
                            {
                                MessageBox.Show("Для добавления необходимо заполнить пароль не более, чем 10 и не менее 8 символами", "Ошибка добавления");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Для добавления необходимо заполнить логин не более, чем 30 символами", "Ошибка добавления");
                        }
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        try
                        {
                            context.Autorization_Clients.Remove(autorization_Clients);
                            context.Clients.Remove(clients);
                            MessageBox.Show("Такой пользователь уже существует. Попробуйте еще раз", "Ошибка создания");
                        }
                        catch
                        {
                            MessageBox.Show("Такой пользователь уже существует. Попробуйте еще раз", "Ошибка создания");

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Необходимо заполнить все, поля помеченные *", "Ошибка создания");
            }
            
        }

        private void izmen_Click(object sender, RoutedEventArgs e)
        {
            if (gridik.SelectedItem != null)
            {
                bool result = false;
                var gg = gridik.SelectedItem as Autorization_Employees;
                foreach (var item in context.Employees)
                {
                    if (item.ID_Employee == gg.Employee_ID)
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
                    Clients clients = new Clients();
                    clients.Names = "d";
                    clients.Surname = "d";
                    context.Clients.Add(clients);
                    context.SaveChanges();
                    Autorization_Clients autorization_Clients = new Autorization_Clients();
                    if (text1.Text.Any(char.IsWhiteSpace) == true && text2.Text.Any(char.IsWhiteSpace) == true)
                    {
                        MessageBox.Show("В поле присутсвуют пробелы", "Ошибка ввода");
                    }
                    else
                    {
                        autorization_Clients.Logini = text1.Text;
                        autorization_Clients.Porol = text2.Text;
                        autorization_Clients.Clients = clients;
                        context.Autorization_Clients.Add(autorization_Clients);
                        try
                        {
                            context.SaveChanges();
                            context.Autorization_Clients.Remove(autorization_Clients);
                            context.Clients.Remove(clients);
                            var selectedq = gridik.SelectedItem as Autorization_Employees;
                            if (text1.Text != "" && text1.Text.Length <= 30)
                            {
                                selectedq.Logini = text1.Text;
                                if (text2.Text != "" && text2.Text.Length <= 10 && text2.Text.Length >= 8)
                                {
                                    selectedq.Porol = text2.Text;
                                    if (combobox.SelectedItem != null)
                                    {
                                        selectedq.Employees = combobox.SelectedItem as Employees;
                                        context.SaveChanges();
                                        gridik.ItemsSource = context.Autorization_Employees.ToList();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Для добавления необходимо заполнить все поля, помеченные *", "Ошибка изменения");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Для добавления необходимо заполнить пароль не более, чем 10 и не менее 8 символами", "Ошибка изменения");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Для добавления необходимо заполнить логин не более, чем 30 символами", "Ошибка изменения");
                            }



                        }
                        catch (System.Data.Entity.Infrastructure.DbUpdateException)
                        {
                            context.Autorization_Clients.Remove(autorization_Clients);
                            MessageBox.Show("Данный пороль или логин уже существует. Попробуйте еще раз");
                        }
                    }
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
                var selected = gridik.SelectedItem as Autorization_Employees;
                text1.Text = selected.Logini;
                text2.Text = selected.Porol;
                combobox.SelectedItem = selected.Employees;
            }
        }
    }
}
