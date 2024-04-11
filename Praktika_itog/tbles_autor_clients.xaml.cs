using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Xml.Linq;

namespace Praktika_itog
{
    /// <summary>
    /// Логика взаимодействия для tbles_autor_clients.xaml
    /// </summary>
    public partial class tbles_autor_clients : Page
    {
        private SUSHIK_STOREEntities4 context = new SUSHIK_STOREEntities4();
        public tbles_autor_clients()
        {
            InitializeComponent();
            gridik.ItemsSource = context.Autorization_Clients.ToList();
            combobox.ItemsSource = context.Clients.ToList();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (gridik.SelectedItem != null)
            {
                bool result = false;
                var gg = gridik.SelectedItem as Autorization_Clients;
                foreach (var item in context.Clients)
                {
                    if (item.ID_Clients == gg.Clients_ID)
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
                    context.Autorization_Clients.Remove(gridik.SelectedItem as Autorization_Clients);
                    context.SaveChanges();
                    gridik.ItemsSource = context.Autorization_Clients.ToList();
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления", "Ошибка удаления");
            }
        }

        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            if ( text1.Text != "" && text2.Text != "" && combobox.SelectedItem != null)
            {
                Autorization_Employees autorization_Clients = new Autorization_Employees();
                Employees employees = new Employees();
                employees.Surname = "sdsdf";
                employees.Names = "sdsdf";
                employees.Phone_Number = "151";
                employees.Job_Title_ID = 1;
                try
                {
                    context.Employees.Remove(employees);
                    context.SaveChanges();

                }
                catch 
                {

                }
                context.Employees.Add(employees);
                try
                {
                    context.SaveChanges();
                    if (text1.Text.Any(char.IsWhiteSpace) == true && text2.Text.Any(char.IsWhiteSpace) == true)
                    {
                        MessageBox.Show("В поле присутсвуют пробелы","Ошибка ввода");
                    }
                    else
                    {
                        autorization_Clients.Logini = text1.Text;
                        autorization_Clients.Porol = text2.Text;
                        autorization_Clients.Employees = employees;
                        context.Autorization_Employees.Add(autorization_Clients);
                        try
                        {
                            context.SaveChanges();
                            context.Employees.Remove(employees);
                            context.Autorization_Employees.Remove(autorization_Clients);
                            context.SaveChanges();
                            Autorization_Clients c = new Autorization_Clients();
                            if (text1.Text != "" && text1.Text.Length <= 30)
                            {
                                c.Logini = text1.Text;
                                if (text2.Text != "" && text2.Text.Length <= 10 && text2.Text.Length >= 8)
                                {
                                    c.Porol = text2.Text;
                                    if (combobox.SelectedItem != null)
                                    {
                                        c.Clients = combobox.SelectedItem as Clients;
                                        context.Autorization_Clients.Add(c);
                                        context.SaveChanges();
                                        gridik.ItemsSource = context.Autorization_Clients.ToList();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Пожалуйста, выберите клиента", "Не все поля заполнены");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Пароль должен состоять не более, чем из 10 и не менее 8 символов", "Ошибка создания пороля");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Логин должен содержать в себе не более 30 символов", "Ошибка создания логина");
                            }
                        }
                        catch (System.Data.Entity.Infrastructure.DbUpdateException)
                        {
                            try
                            {
                                context.Employees.Remove(employees);
                                context.Autorization_Employees.Remove(autorization_Clients);
                                context.SaveChanges();
                                MessageBox.Show("Пользователь с таким логином или поролем уже существует. Попробуйте еще раз", "Ошибка авторизации");
                            }
                            catch
                            {
                                MessageBox.Show("Пользователь с таким логином или поролем уже существует. Попробуйте еще раз", "Ошибка авторизации");

                            }
                        }
                    }
                }
                catch
                {
                    try
                    {
                        context.Employees.Remove(employees);
                        context.Autorization_Employees.Remove(autorization_Clients);
                        context.SaveChanges();
                    }
                    catch
                    {

                    }   
                    MessageBox.Show("Пользователь с таким логином или поролем уже существует. Попробуйте еще раз", "Ошибка авторизации");
                }
            }
            else
            {
                MessageBox.Show("Необходимо заполнить все поля","Ошибка создания");
            }
        }

        private void izmen_Click(object sender, RoutedEventArgs e)
        {
            if (gridik.SelectedItem != null)
            {
                bool result = false;
                var gg = gridik.SelectedItem as Autorization_Clients;
                foreach (var item in context.Clients)
                {
                    if (item.ID_Clients == gg.Clients_ID)
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
                    Employees employees = new Employees();
                    employees.Surname = "s";
                    employees.Names = "s";
                    employees.Phone_Number = "1";
                    employees.Job_Title_ID = 1;
                    context.Employees.Add(employees);
                    context.SaveChanges();
                    Autorization_Employees autorization_Clients = new Autorization_Employees();
                    if (text1.Text.Any(char.IsWhiteSpace) == true && text2.Text.Any(char.IsWhiteSpace) == true)
                    {
                        MessageBox.Show("В поле присутсвуют пробелы", "Ошибка ввода");
                    }
                    else
                    {
                        autorization_Clients.Logini = text1.Text;
                        autorization_Clients.Porol = text2.Text;
                        autorization_Clients.Employees = employees;
                        context.Autorization_Employees.Add(autorization_Clients);
                        try
                        {
                            context.SaveChanges();
                            context.Autorization_Employees.Remove(autorization_Clients);
                            context.Employees.Remove(employees);
                            var selectedq = gridik.SelectedItem as Autorization_Clients;
                            if (text1.Text != "" && text1.Text.Length <= 30)
                            {
                                selectedq.Logini = text1.Text;
                                if (text2.Text != "" && text2.Text.Length <= 10 && text2.Text.Length >= 8)
                                {
                                    selectedq.Porol = text2.Text;
                                    selectedq.Clients = combobox.SelectedItem as Clients;
                                    context.SaveChanges();
                                    gridik.ItemsSource = context.Autorization_Clients.ToList();
                                }
                                else
                                {
                                    MessageBox.Show("Пароль должен состоять не более чем из 10 и не менее 8 символов", "Ошибка создания пароля");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Логин должен содержать в себе не более 30 символов", "Ошибка создания логина");
                            }

                        }
                        catch (System.Data.Entity.Infrastructure.DbUpdateException)
                        {
                            context.Autorization_Employees.Remove(autorization_Clients);
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
                var selected = gridik.SelectedItem as Autorization_Clients;
                text1.Text = selected.Logini;
                text2.Text = selected.Porol;
                combobox.SelectedItem = selected.Clients;
            }
        }
    }
}
