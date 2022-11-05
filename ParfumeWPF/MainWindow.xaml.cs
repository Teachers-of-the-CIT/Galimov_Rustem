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

namespace ParfumeWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ImportImagesGoods()
        {
            var fileData = File.ReadAllLines(@"C:\Users\ryuzi\Downloads\ДЭ\4438_ДЭ\Сессия\Товар_import\file.csv");
            var images = Directory.GetFiles(@"C:\Users\ryuzi\Downloads\ДЭ\4438_ДЭ\Сессия\Товар_import\images");

            foreach (var line in fileData)
            {
                var data = line.Split(';');
                var TempGood = new Models.Good
                {
                    Code = data[0].Replace("\"", ""),
                    Name = data[1].Replace("\"", ""),
                    Measurment = data[2].Replace("\"", ""),
                    Price = decimal.Parse(data[3].Replace("\"", "")),
                    MaxSale = int.Parse(data[4].Replace("\"", "")),
                    Manufacturer = data[5].Replace("\"", ""),
                    Provider = data[6].Replace("\"", ""),
                    CategoryId = (data[7].Replace("\"", "") == "Мужской парфюм") ? 1 : 2,
                    NowSale = int.Parse(data[8].Replace("\"", "")),
                    StorageCount = int.Parse(data[9].Replace("\"", "")),
                    Description = data[10].Replace("\"", ""),
                };

                try
                {
                    Console.WriteLine(data[11]);
                    if(data[11] != "\"\"")
                    {
                        TempGood.Image = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(data[11].Replace("\"", ""))));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Models.parfumeEntities.GetContext().Goods.Add(TempGood);
                Models.parfumeEntities.GetContext().SaveChanges();
            }

        }

        private void signinButton_Click(object sender, RoutedEventArgs e)
        {
            Models.User user = Models.parfumeEntities.GetContext().Users.FirstOrDefault(p => p.Login == loginTextBox.Text && p.Password == passwordTextBox.Password);
            if(user != null)
            {
                if(user.Role.Id == 1)
                {
                    Windows.Admin admin = new Windows.Admin();
                    admin.Show();
                    this.Hide();
                }
                if (user.Role.Id == 2)
                {
                    Windows.Manager manager = new Windows.Manager();
                    manager.Show();
                    this.Hide();
                }
            }
        }

        private void guestButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Goods goods = new Windows.Goods();
            goods.Show();
            this.Hide();
        }
    }

}
