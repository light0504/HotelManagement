using HotelManagement.DAL.Entities;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public  Member  currentAccount { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        public void UpdateGreetingMessage()
        {
            HelloMsgLabel.Content = "Hello " + currentAccount.Role.ToString();
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow log = new(); 
            log.Show();
            this.Close();
        }

        private void btnMember_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTask_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRoom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnService_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
