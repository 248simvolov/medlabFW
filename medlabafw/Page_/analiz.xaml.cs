using medlabafw.DB_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
using System.Data.Entity.Migrations;

namespace medlabafw.Page_
{
    /// <summary>
    /// Логика взаимодействия для analiz.xaml
    /// </summary>
    public partial class analiz : Page
    {
        Анализ da11 = new Анализ();
        Сотрудники sotr1 = new Сотрудники();
        Пациент pac = new Пациент();
        List<medlabafw.DB_.ПараметрыАнализов> пара = new List<medlabafw.DB_.ПараметрыАнализов>();
        public analiz(Сотрудники сотр, Пациент пац, Анализ анализ)
        {
            InitializeComponent();
            using (var context = new medlabaEntities())
            {
                var currentTours = context.РезультатАнализа.ToList();
                var counter = context.ПараметрыАнализов.ToList();
                counter = counter.Where(p => p.ПринадлежитТипу.ToString().Contains(анализ.КодТипа.ToString())).ToList();
                currentTours = currentTours.Where(p => p.Анализ.ToString().Contains(анализ.КодАнализа.ToString())).ToList();
                пара = counter;
                if (currentTours.Count <= 0)
                {
                    for (int i = 0; i < counter.Count; i++)
                    {
                        РезультатАнализа yihyyy = new РезультатАнализа();
                        yihyyy.ПараметрАнализа = counter[i].КодПараметра;
                        yihyyy.Анализ = анализ.КодАнализа;
                        currentTours.Add(yihyyy);
                        context.РезультатАнализа.AddOrUpdate(yihyyy);
                    }
                }
                
                da11 = анализ;
                pac = пац;
                sotr1 = сотр;
                dgrid.ItemsSource = currentTours;
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                string host = "smtp.";
                bool naiden = false;
                //заись в host smtp сервера
                for (int i = 0; i < sotr1.АдресЭлектроннойПочты.Length; i++)
                {
                    if (naiden)
                        host += sotr1.АдресЭлектроннойПочты[i];
                    if (sotr1.АдресЭлектроннойПочты[i] == '@')
                        naiden = true;
                }
                smtp.Host = host;
                //указание данных почтового ящика
                smtp.Credentials = new NetworkCredential(sotr1.АдресЭлектроннойПочты, sotr1.ПарольЭлектроннойПочты);
                smtp.EnableSsl = true;
                //что куда отправляется
                MailMessage m = new MailMessage(sotr1.АдресЭлектроннойПочты, pac.ЭлектроннаяПочта);
                //создание тела письма
                string data = $"Анализ проведил: {sotr1.Фамилия} {sotr1.Имя} {sotr1.Отчество}\n";


                using (var context = new medlabaEntities())
                {
                    var currentTours = context.ТипАнализа.ToList();
                    currentTours = currentTours.Where(p => p.КодТипа.ToString().Contains(da11.КодТипа.ToString())).ToList();
                    m.Subject = currentTours[0].Название;
                    for (int i = 0; i < dgrid.Items.Count; i++)
                    {
                        РезультатАнализа анализ = dgrid.Items[i] as РезультатАнализа;
                        if (анализ != null)
                        {
                            try
                            {
                                context.РезультатАнализа.AddOrUpdate(анализ); context.SaveChanges();
                                //создание тела письма
                                string назв = пара[i].Название;
                                data += $"{назв}: {анализ.Значение}\n";
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                        }
                    }
                    //запись тела письма
                    m.Body = data;
                    //отправка
                    smtp.Send(m);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var context = new medlabaEntities())
            {
                var currentTours = context.РезультатАнализа.ToList();
                var counter = context.ПараметрыАнализов.ToList();
                counter = counter.Where(p => p.ПринадлежитТипу.ToString().Contains(da11.КодТипа.ToString())).ToList();
                currentTours = currentTours.Where(p => p.Анализ.ToString().Contains(da11.КодАнализа.ToString())).ToList();
                if (currentTours.Count <= 0)
                {
                    for (int i = 0; i < counter.Count; i++)
                    {
                        РезультатАнализа yihyyy = new РезультатАнализа();
                        yihyyy.ПараметрАнализа = counter[i].КодПараметра;
                        yihyyy.Анализ = da11.КодАнализа;
                        currentTours.Add(yihyyy);
                    }
                }
                dgrid.ItemsSource = currentTours;
            }
        }
    }
}
