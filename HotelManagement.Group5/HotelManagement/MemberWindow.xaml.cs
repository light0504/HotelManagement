using HotelManagement.BLL.Service;
using HotelManagement.DAL.Entities;
using System;
using System.Collections;
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
    /// Interaction logic for MemberWindow.xaml
    /// </summary>
    public partial class MemberWindow : Window
    {
        Member? _selectedMember = null;
        MemberService _memSer = new();

        public Member? LoginMember { get; set; }

        public MemberWindow()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (LoginMember.Role == "manager")
            {
                CleanData();
                MemberDataGrid.ItemsSource = _memSer.GetAllMembers();
                SearchComboBox.ItemsSource = ListSearchOption();
                FilterComboBox.ItemsSource = ListFilterOption();
                return;
            }
            AddButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
        }

        private List<string> ListSearchOption()
        {
            List<string> searchOptions = new();
            searchOptions.Add("ID");
            searchOptions.Add("Name");
            return searchOptions;
        }

        private List<string> ListFilterOption()
        {
            List<string> filterOptions = new();
            filterOptions.Add("manager");
            filterOptions.Add("housekeeper");

            return filterOptions;
        }

        private void CleanData()
        {
            IdText.Text = string.Empty;
            EmailText.Text = string.Empty;
            NameText.Text = string.Empty;
            PhoneText.Text = string.Empty;
            AddressText.Text = string.Empty;
            RoleText.Text = string.Empty;
            MemberDataGrid.ItemsSource = null;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MemberDetailWindow memberDetailWindow = new MemberDetailWindow();
            memberDetailWindow.Show();
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedMember == null)
            {
                MessageBox.Show("Please select ONE", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _memSer.Remove(_selectedMember.MemberId);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please selected ONE", "Search FAIL", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            CleanData();

            if (SearchComboBox.SelectedValue == "ID")
            {
                if (ListSearch("ID") == null)
                {
                    MessageBox.Show("this ID doesnot exist", "Search FAIL", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                MemberDataGrid.ItemsSource = ListSearch(SearchComboBox.SelectedValue.ToString());
                return;
            }
            else if (SearchComboBox.SelectedValue == "Name")
            {
                if (ListSearch("Name") == null)
                {
                    MessageBox.Show("this name does not exist", "Search FAIL", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                MemberDataGrid.ItemsSource = ListSearch(SearchComboBox.SelectedValue.ToString());
                return;
            }
        }

        private List<Member>? ListSearch(string option)
        {
            List<Member>? list = null;

            if (option == "ID")
            {
                list.Add(_memSer.GetMemberById(int.Parse(SearchText.Text)));
                return list;
            }
            else
            {
                return list = _memSer.GetMembersByName(SearchText.Text);
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            if (FilterComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please selected ONE", "Filter FAIL", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            CleanData();

            if (FilterComboBox.SelectedValue == "manager")
            {
                MemberDataGrid.ItemsSource = ListFilter("manager");
                return;
            }
            else
            {
                MemberDataGrid.ItemsSource = ListFilter("housekeeper");
                return;
            }
        }

        private List<Member>? ListFilter(string option)
        {
            List<Member>? list = null;
            if (option == "manager")
            {
                return list = _memSer.GetMemberListByRole("manager");
            }
            else
            {
                return list = _memSer.GetMemberListByRole("housekeeper");
            }
        }

        private void MemberDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MemberDataGrid.SelectedItems.Count > 0)
            {
                _selectedMember = MemberDataGrid.SelectedItems[0] as Member;
                FillMemberToTextBox(_selectedMember);
            }
        }

        private void FillMemberToTextBox(Member? member)
        {
            IdText.Text = member.MemberId.ToString();
            EmailText.Text = member.Email;
            AddressText.Text = member.Address;
            NameText.Text = member.Name;
            PhoneText.Text = member.Phone;
            RoleText.Text = member.Role;
        }
    }
}
