using HotelManagement.BLL.Service;
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
    /// Interaction logic for MemberDetailWindow.xaml
    /// </summary>
    public partial class MemberDetailWindow : Window
    {
        MemberService _memSer = new();

        public MemberDetailWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RoleComboBox.ItemsSource = FillRole();
        }

        private List<string> FillRole()
        {
            List<string> roles = new();
            roles.Add("manager");
            roles.Add("housekeeper");
            return roles;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValidId(IdText.Text) ||
                !IsMatchPass(PasswordText.Text, ConfirmPasswordText.Text) ||
                !IsValidPhone(PhoneText.Text) ||
                !IsValidRole(RoleComboBox.SelectedValue.ToString()))
            {
                return;
            }

            Member mem = new Member();
            mem.MemberId = int.Parse(IdText.Text);
            mem.Email = EmailText.Text;
            mem.Password = PasswordText.Text;
            mem.Name = NameText.Text;
            mem.Address = AddressText.Text;
            mem.Phone = PhoneText.Text;
            mem.Role = RoleComboBox.SelectedValue.ToString();
            _memSer.AddMember(mem);
        }

        private bool IsValidId(string id)
        {
            if (!int.TryParse(id, out _))
            {
                MessageBox.Show("Id is not valid", "Wrong ID", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        private bool IsValidPhone(string phone)
        {
            if (!double.TryParse(phone, out _))
            {
                MessageBox.Show("Phone is not valid", "Wrong Phone", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private bool IsMatchPass(string pass, string conf)
        {
            if (pass != conf)
            {
                MessageBox.Show("Password does not Match", "Wrong Password");
                return false;
            }

            return true;
        }

        private bool IsValidRole(string? role)
        {
            if (role == null)
            {
                MessageBox.Show("Please select one Role", "Role select", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
