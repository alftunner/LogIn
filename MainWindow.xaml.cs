using System;
using System.Collections.Generic;
using System.IO;
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

namespace LogIn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Login.Text == "" || Password.Password == "")
            {
                MessageBox.Show("Вы заполнили не все поля!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Login.Clear();
                Password.Clear();
            }
            else
            {
                Logger(Login.Text);
                Logger(Password.Password);
                MessageBox.Show("Для вас успешно создана пара логин и пароль", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Login.Clear();
                Password.Clear();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Check();
            Login.Clear();
            Password.Clear();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Open();
            Login.Clear();
            Password.Clear();
        }

        private void Logger(string data)
        {
            using StreamWriter file = new StreamWriter("log.txt", true);
            file.WriteLine(data);
        }

        private void Open()
        {
            string commandText = @"C:\Users\111\source\repos\LogIn\bin\Debug\netcoreapp3.1\log.txt";
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = commandText;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }

        private void Check()
        {
            int counter1 = 0;
            int counter2 = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\111\source\repos\LogIn\bin\Debug\netcoreapp3.1\log.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (line == Login.Text)
                {
                    counter1++;
                }
                if (line == Password.Password)
                {
                    counter2++;
                }
            }

            if(counter1 == counter2)
            {
                MessageBox.Show("Поздравляем! Вы успешно авторизовались!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Вы не зарегистрированы! Но можете зарегистрироваться, нажав кнопку СОЗДАТЬ, хотите?", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }

            file.Close();
        }
    }
}
