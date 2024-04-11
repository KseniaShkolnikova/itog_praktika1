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
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;

namespace Praktika_itog
{
    /// <summary>
    /// Логика взаимодействия для registr.xaml
    /// </summary>
    public partial class registr : Page
    {
        private SUSHIK_STOREEntities4 context = new SUSHIK_STOREEntities4();
        public registr()
        {
            InitializeComponent();
        }
        public static bool proverk (TextBox textBox)
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
        private void vxod_Click(object sender, RoutedEventArgs e)
        {
            bool result = true;
            foreach (var item in context.Autorization_Employees)
            {
                if (item.Logini == login.Text)
                {
                    if (item.Porol == parol.Text)
                    {
                        result = false;
                    }
                }
            }
            foreach (var item1 in context.Autorization_Clients)
            {
                if (item1.Logini == login.Text)
                {
                    if (item1.Porol == parol.Text)
                    {
                        result= false;
                    }
                }
            }
            if (result == false)
            {
                MessageBox.Show("Пожалуйста придумайте другой пароль или логин");
            }
            else
            {
                Clients cl = new Clients();
                Autorization_Clients aut = new Autorization_Clients();
                if (name.Text == "" || surname.Text == "" ||  login.Text=="" || parol.Text == "")
                {
                    MessageBox.Show("Пожалуйста, заполните все необходимые поля, помеченные * ", "Ошибка ввода");
                }
                else
                {
                    if (proverk(name)==true)
                    {
                        MessageBox.Show("Пожалуйста, удалите из поля 'Имя' цифры или стороние знаки", "Ошибка ввода");
                    }
                    else
                    {
                        if (name.Text.Length > 50)
                        {
                            MessageBox.Show("Ваше имя слишком длинное", "Ошибка ввода");
                        }
                        else
                        {
                            if (name.Text.Any(char.IsWhiteSpace)==true)
                            {
                                MessageBox.Show("В поле присутсвуют пробелы", "Ошибка ввода");
                            }
                            else
                            {
                                cl.Names = name.Text;
                                if (proverk(surname) == true)
                                {
                                    MessageBox.Show("Пожалуйста, удалите из поля 'Фамилия' цифры или стороние знаки ", "Ошибка ввода");
                                }
                                else
                                {
                                    if (surname.Text.Length > 50)
                                    {
                                        MessageBox.Show("Ваша фамилия слишком длинная", "Ошибка ввода");
                                    }
                                    else
                                    {
                                        if (surname.Text.Any(char.IsWhiteSpace) == true)
                                        {
                                            MessageBox.Show("В поле присутсвуют пробелы", "Ошибка ввода");
                                        }
                                        else
                                        {
                                            cl.Surname = surname.Text;
                                            if (proverk(middle_name) == true)
                                            {
                                                MessageBox.Show("Пожалуйста, удалите из поля 'Отчество' цифры или стороние знаки", "Ошибка ввода");

                                            }
                                            else
                                            {
                                                if (middle_name.Text.Length > 50)
                                                {
                                                    MessageBox.Show("Ваше отчество слишком длинное", "Ошибка ввода");
                                                }
                                                else
                                                {
                                                    if (middle_name.Text.Any(char.IsWhiteSpace) == true)
                                                    {
                                                        MessageBox.Show("В поле присутсвуют пробелы", "Ошибка ввода");
                                                    }
                                                    else
                                                    {
                                                        cl.Middle_Name = middle_name.Text;
                                                        if (login.Text.Length > 30)
                                                        {
                                                            MessageBox.Show("Ваш логин слишком длинный. не более 30 символов", "Ошибка ввода");

                                                        }
                                                        else
                                                        {
                                                            if (login.Text.Any(char.IsWhiteSpace) == true)
                                                            {
                                                                MessageBox.Show("В поле присутсвуют пробелы", "Ошибка ввода");
                                                            }
                                                            else
                                                            {
                                                                aut.Logini = login.Text;
                                                                if (parol.Text.Length > 8)
                                                                {
                                                                    MessageBox.Show("Ваш пороль должен состоять не мене, чем из 8 и не более 10 символов", "Ошибка ввода");
                                                                }
                                                                else
                                                                {
                                                                    if (parol.Text.Any(char.IsWhiteSpace) == true)
                                                                    {
                                                                        MessageBox.Show("В поле присутсвуют пробелы", "Ошибка ввода");
                                                                    }
                                                                    else
                                                                    {
                                                                        aut.Porol = parol.Text;
                                                                        context.Clients.Add(cl);
                                                                        context.Autorization_Clients.Add(aut);
                                                                        context.SaveChanges();
                                                                        clients_main clients_Main = new clients_main(parol.Text, login.Text);
                                                                        clients_Main.Show();
                                                                        Application.Current.Windows.OfType<MainWindow>().First().Close();
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }               
            }
        }
    }
}
