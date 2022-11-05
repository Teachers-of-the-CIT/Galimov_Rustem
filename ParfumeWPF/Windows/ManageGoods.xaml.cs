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
using System.Windows.Shapes;

namespace ParfumeWPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для ManageGoods.xaml
    /// </summary>
    public partial class ManageGoods : Window
    {
        public ManageGoods()
        {
            InitializeComponent();
        }
        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
