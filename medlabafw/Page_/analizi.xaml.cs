using medlabafw.DB_;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace medlabafw.Page_
{
    /// <summary>
    /// Логика взаимодействия для analizi.xaml
    /// </summary>
    public partial class analizi : Page
    {

        Сотрудники rabch = new Сотрудники();
        Пациент pacz = new Пациент();
        public analizi(Сотрудники сотр, Пациент пац)
        {
            
            InitializeComponent();
            using (var context = new medlabaEntities())
            {
                pacz = пац;
                rabch = сотр;
                //var currr = context.Анализ.ToList();
                //currr = currr.Where(p => p.Пациент.ToLower().Contains(пац.СНИЛС.ToLower())).ToList();
                var currentTours = context.Анализ.ToList();
                currentTours = currentTours.Where(p => p.Пациент.ToString().Contains(пац.СНИЛС.ToString())).ToList();
                //dgrid.ItemsSource = context.Анализ.Where(p => p.Пациент.ToLower().Contains(пац.СНИЛС.ToLower())).ToList();
                dgrid.ItemsSource = currentTours;
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
                        Анализ анализ = dgrid.Items[i] as Анализ;
                        if (анализ != null)
                        {
                            context.Анализ.AddOrUpdate(анализ); 
                                context.SaveChanges();
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
                dgrid.ItemsSource = context.Анализ.ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (var context = new medlabaEntities())
            {
                //получение списка выделеных строк для удаления
                var SotrForRemoving = dgrid.SelectedItems.Cast<Анализ>().ToList();
                //предупреждение пользователя о удалении данных
                if (MessageBox.Show($"Вы точно хотите удалить следующие {SotrForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    //удаление данных при согласии
                    try
                    {
                        context.Анализ.RemoveRange(SotrForRemoving);
                        context.SaveChanges();
                        MessageBox.Show("Данные удалены!");
                        dgrid.ItemsSource = context.Анализ.ToList();
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
                var dob = dgrid.SelectedItems.Cast<Анализ>().ToList()[0];
                if (dob != null)
                {
                    analiz yyee = new analiz(rabch, pacz, dob);
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
