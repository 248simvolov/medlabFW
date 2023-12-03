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
using System.Data;
using MaterialDesignThemes.Wpf;
using medlabafw.Window_;
using medlabafw.DB_;
using System.Data.Entity.Migrations;

namespace medlabafw.Page_
{
    /// <summary>
    /// Логика взаимодействия для pacienti.xaml
    /// </summary>
    public partial class pacienti : Page
    {
        Сотрудники rabch = new Сотрудники();
        public pacienti(Сотрудники rabch1)
        {
            InitializeComponent();
            using (var context = new medlabaEntities())
            {
                dgrid.ItemsSource = context.Пациент.ToList();
                rabch = rabch1;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new medlabaEntities())
            {
                try
                {

                    for (int i = 0; i < dgrid.Items.Count; i++)
                    {
                        Пациент пациент = dgrid.Items[i] as Пациент;
                        if (пациент != null)
                        {
                            context.Пациент.AddOrUpdate(пациент); context.SaveChanges();
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var context = new medlabaEntities())
            {
                dgrid.ItemsSource = context.Пациент.ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (var context = new medlabaEntities())
            {
                //получение списка выделеных строк для удаления
                var SotrForRemoving = dgrid.SelectedItems.Cast<Пациент>().ToList();
                //предупреждение пользователя о удалении данных
                if (MessageBox.Show($"Вы точно хотите удалить следующие {SotrForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    //удаление данных при согласии
                    try
                    {
                        context.Пациент.RemoveRange(SotrForRemoving);
                        context.SaveChanges();
                        MessageBox.Show("Данные удалены!");
                        dgrid.ItemsSource = context.Пациент.ToList();
                    }
                    //вывод ошибки
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                var dob = dgrid.SelectedItems.Cast<Пациент>().ToList()[0];
                if (dob != null)
                {
                    analizi yyee = new analizi(rabch, dob);
                    NavigationService.Navigate(yyee);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
