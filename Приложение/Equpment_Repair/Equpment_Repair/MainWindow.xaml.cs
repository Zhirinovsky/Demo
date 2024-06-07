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

namespace Equpment_Repair
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Equpment_Repair_DatabaseContext db = new Equpment_Repair_DatabaseContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAuthorization_Click(object sender, RoutedEventArgs e)
        {
            var user = db.User.FirstOrDefault(x => x.Login == tbxLogin.Text && x.Password == tbxPassword.Password);
            if (user != null)
            {
                user.Role = db.Role.FirstOrDefault(x => x.Id == user.RoleId);
                switch (user.Role.Name)
                {
                    case "Сотрудник":
                        EmployeeWindow employeeWindow = new EmployeeWindow();
                        employeeWindow.Show();
                        break;

                    case "Клиент":
                        ClientWindow clientWindow = new ClientWindow(user.Id);
                        clientWindow.Show();
                        break;
                }
                Close();
            }
            else
            {
                MessageBox.Show("Введён неправильный логин и/или пароль!");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Scaffold-DbContext "Data Source=DESKTOP-9R2S8EF\MYSERVERNAME;Initial Catalog=Equpment_Repair_Database;Persist Security Info=True;User ID=SA;Password=123;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer
    }
}
