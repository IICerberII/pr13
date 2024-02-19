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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ToDo> strList { get; set; }

        
        public MainWindow()
        {
            InitializeComponent();

            strList = new List<ToDo>();
            mainListBox.ItemsSource = strList;
            strList.Add(new ToDo("Приготовить покушать", "Нет описания", new DateTime (2024, 01, 15)));
            strList.Add(new ToDo("Поработать", "Съездить на совещание в Москву", new DateTime(2024, 01, 20)));
            strList.Add(new ToDo("Отдохнуть", "Съездить в отпуск в Сочи", new DateTime(2024, 02, 01)));


            dateToDo.SelectedDate = new DateTime(2024,01,10);
            descriptionToDo.Text = "Описания нет";


        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GroupToDo.Visibility = Visibility.Visible;
        }
        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            GroupToDo.Visibility = Visibility.Hidden;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mainListBox.SelectedItem != null)
            {
                var selecteditem = mainListBox.SelectedItem as ToDo;

                if (selecteditem != null)
                {
                    strList.Remove(selecteditem);

                    mainListBox.Items.Refresh();

                }
            }
        }


        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            string Name = titleToDo.Text;
            DateTime? selectedDate = dateToDo.SelectedDate;

            DateTime dueDate = selectedDate ?? DateTime.Now;
            string Description = descriptionToDo.Text;

            strList.Add(new ToDo(Name, Description, dueDate));
            mainListBox.Items.Refresh();

            titleToDo.Text = "";
            descriptionToDo.Text = "";
            dateToDo.SelectedDate = null;
        }

        private void descriptionToDo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
