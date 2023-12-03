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

namespace medlabafw.Window_
{
    /// <summary>
    /// Логика взаимодействия для rabota.xaml
    /// </summary>
    public partial class rabota : Window
    {
        public rabota(medlabafw.DB_.Сотрудники rabch)
        {
            InitializeComponent();
            frpac.Navigate(new Page_.pacienti(rabch));
            lrab.Content = rabch.Фамилия + " " + rabch.Имя;
        }

        private void bclose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void bsver_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void bmashtb_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
    }
}
