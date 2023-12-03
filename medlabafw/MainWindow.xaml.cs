using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using medlabafw;
using medlabafw.DB_;

namespace medlabafw
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    public medlabafw.DB_.Сотрудники thisuser;
    public MainWindow()
    {
        InitializeComponent();
        using (var context = new medlabaEntities())
        {

        }
        //DB_.medlabaEntities _context = new DB_.medlabaEntities();
    }


    private void Button_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }
    /*public DataTable Select(string selectSql)
    {
        selectSql = selectSql.Trim();
        DataTable dt = new DataTable("dataBase");
        SqlConnection conn = new SqlConnection("server=DESKTOP-DPONHDL;Trusted_Connection=Yes;DataBase=medlaba;");
        conn.Open();
        SqlCommand sqlCommand = conn.CreateCommand();
        sqlCommand.CommandText = selectSql;
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        adapter.Fill(dt);
        return dt;
    }*/
    private void bvhod_Click(object sender, RoutedEventArgs e)
    {
        if (tbLogin.Text.Length > 0) // проверяем введён ли логин     
        {
            if (tbPassword.Password.Length > 0) // проверяем введён ли пароль         
            {             // ищем в базе данных пользователя с такими данными         
                using (var context = new medlabaEntities())
                {
                    bool voshel = false;
                    var users = context.Сотрудники.ToList();
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (users[i].АдресЭлектроннойПочты == tbLogin.Text && users[i].ПарольЭлектроннойПочты == tbPassword.Password)
                        {
                            voshel = true;
                            thisuser = users[i];
                        }
                    }
                    if (voshel)
                    {
                        Window_.rabota rab = new Window_.rabota(thisuser);
                        rab.Show();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Введён неверный логин или пароль");
                }
            }
            else MessageBox.Show("Введите пароль"); // выводим ошибку    
        }
        else MessageBox.Show("Введите логин"); // выводим ошибку 
    }
}
}
