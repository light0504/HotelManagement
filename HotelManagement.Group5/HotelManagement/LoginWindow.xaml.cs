using HotelManagement.BLL.Service;
using HotelManagement.DAL.Entities;
using Microsoft.IdentityModel.Tokens;
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

namespace HotelManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private MemberService _services = new();
        public LoginWindow()
        {
            InitializeComponent();
        }

        // duy chuyển màn hình 
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // login authenticate thành công thì mới gọi màn hình Main 
            if (txtUser.Text.IsNullOrEmpty() || txtPass.Password.IsNullOrEmpty())
            {
                MessageBox.Show(" email address and requied  ", "requied fields", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Member? account = _services.Login(txtUser.Text, txtPass.Password);
            //account có thể là null hoặc khác null (login thành công 0 
            if (account == null)
            {
                MessageBox.Show("Invalid email addres or wrong password ", "wrong cedentials", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            } // todo : phải thông báo được sai cái gì kê : sai email , hay sai pass 
              // sai 5 lần thì khóa acc trong bao nhiêu phút ...
              // account lúc này 1 record nào đó thuộc role 1 2 3 => authoriztion 

            MessageBox.Show("Sussess Login", "Login", MessageBoxButton.OK);


            MainWindow main = new MainWindow();
            main.currentAccount = account;
            main.UpdateGreetingMessage();
            main.Show();
            this.Hide(); // ẩn chính màn hình login 


        }


    }
}
