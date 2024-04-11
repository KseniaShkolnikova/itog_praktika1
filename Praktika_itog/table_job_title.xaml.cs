using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для table_job_title.xaml
    /// </summary>
    public partial class table_job_title : Page
    {
        private SUSHIK_STOREEntities4 context = new SUSHIK_STOREEntities4();
        public table_job_title()
        {
            InitializeComponent();
            gridik.ItemsSource = context.Job_Title.ToList();
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
                var gg = gridik.SelectedItem as Job_Title;
                bool result = false;
                foreach (var item in context.Employees)
                {
                    if (item.Job_Title_ID == gg.ID_Job_Title)
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
                    context.Job_Title.Remove(gridik.SelectedItem as Job_Title);
                    context.SaveChanges();
                    gridik.ItemsSource = context.Job_Title.ToList();
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
                if (text1.Text.Length <= 50)
                {
                    bool result = false;
                    foreach (var item in context.Job_Title)
                    {
                        if (item.Name_Job_Title == text1.Text)
                        {
                            result = true;
                        }
                    }
                    if (result != true)
                    {
                        Job_Title c = new Job_Title();
                        result = false;
                        foreach (var item in context.Job_Title)
                        {
                            if (item.Name_Job_Title == text1.Text)
                            {
                                result = true;
                            }
                        }
                        if (result == true)
                        {
                            MessageBox.Show("Наименование должности должно быть уникальным", "Ошибка добавления");
                        }
                        else
                        {
                            if (proverk(text1) == true)
                            {
                                MessageBox.Show("Данное поле может содержать только русские буквы", "Ошибка добавления");
                            }
                            else
                            {
                                c.Name_Job_Title = text1.Text;
                                context.Job_Title.Add(c);
                                context.SaveChanges();
                                gridik.ItemsSource = context.Job_Title.ToList();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Наименование должномти должно быть уникальной", "Ошибка добавления");
                    }

                }
                else
                {

                    MessageBox.Show("Наименование должности не должно привышать 50 символов", "Ошибка добавления");
                }
            }
            else
            {

                MessageBox.Show("Для добавления зполните все поля, помеченные '*'", "Ошибка добавления");
            }
        }

        private void izmen_Click(object sender, RoutedEventArgs e)
        {
            if (gridik.SelectedItem != null)
            {
                var gg = gridik.SelectedItem as Job_Title;
                bool result = false;
                foreach (var item in context.Employees)
                {
                    if (item.Job_Title_ID == gg.ID_Job_Title)
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
                    var selected = gridik.SelectedItem as Job_Title;
                    if (text1.Text != "")
                    {
                        result = false;
                        foreach (var item in context.Job_Title)
                        {
                            if (item.Name_Job_Title == text1.Text)
                            {
                                result = true;
                            }
                        }
                        if (result != true)
                        {
                            MessageBox.Show("Наименование должности должно быть уникальным", "Ошибка добавления");
                        }
                        else
                        {
                            if (proverk(text1) == true)
                            {
                                MessageBox.Show("Данное поле может содержать только русские буквы", "Ошибка добавления");
                            }
                            else
                            {
                                selected.Name_Job_Title = text1.Text;
                                context.SaveChanges();
                                gridik.ItemsSource = context.Job_Title.ToList();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Наименование должности не должно привышать 50 символов", "Ошибка добавления");
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
                var selected = gridik.SelectedItem as Job_Title;
                text1.Text = selected.Name_Job_Title;
            }
        }

        private void json_Click(object sender, RoutedEventArgs e)
        {
            SerDesir serDesir = new SerDesir();
            var listproduct = serDesir.Jsonviser<List<Job_Title>>("job_title.json");
            foreach (var item in listproduct)
            {
                var povtor = context.Job_Title.FirstOrDefault(x => x.Name_Job_Title == item.Name_Job_Title);
                if (povtor == null)
                {
                    context.Job_Title.Add(item);
                    context.SaveChanges();
                }
            }
            json.IsEnabled = false;
            gridik.ItemsSource = context.Job_Title.ToList();
        }
    }
}

