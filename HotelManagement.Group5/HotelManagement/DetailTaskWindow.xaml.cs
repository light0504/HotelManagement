using HotelManagement.BLL.Service;
using HotelManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelManagement
{
    /// <summary>
    /// Interaction logic for DetailTaskWindow.xaml
    /// </summary>
    public partial class DetailTaskWindow : Window
    {

        private TaskService _service = new();

        public DAL.Entities.Task EditedOne {  get; set; }   
        public DetailTaskWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (!CheckTaskVar()) return;

            DAL.Entities.Task obj = new(); 

         
            obj.MemberId = int.Parse(txtMemberID.Text);
            obj.RoomNumber = int.Parse(txtRoomNumber.Text);
            obj.DateCreate = dtpDateCreate.SelectedDate.Value;
            obj.MemberName = txtMemberName.Text;
            obj.TaskStatus = cboTaskStatus.Text;

            if (EditedOne == null)
            {
                _service.AddTask(obj);
            }
            else
            {
                obj.TaskId = EditedOne.TaskId;
                _service.UpdateTask(obj);

            }
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (EditedOne == null)
            {
                return;
            }

            txtMemberID.Text = EditedOne.MemberId.ToString();
            txtRoomNumber.Text = EditedOne.RoomNumber.ToString();
            dtpDateCreate.SelectedDate = EditedOne.DateCreate;
            txtMemberName.Text = EditedOne.MemberName.ToString();
            cboTaskStatus.Text = EditedOne.TaskStatus;
        }


        private bool CheckTaskVar()
        {
            // Validate Member ID
            if (string.IsNullOrWhiteSpace(txtMemberID.Text) || !int.TryParse(txtMemberID.Text, out int memberId) || memberId <= 0)
            {
                MessageBox.Show("Member ID must be a positive integer", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Validate Room Number
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text) || !int.TryParse(txtRoomNumber.Text, out int roomNumber) || roomNumber <= 0)
            {
                MessageBox.Show("Room number must be a positive integer", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Validate Date Created
            if (dtpDateCreate.SelectedDate == null)
            {
                MessageBox.Show("Date of creation is required", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Validate Member Name
            if (string.IsNullOrWhiteSpace(txtMemberName.Text) || txtMemberName.Text.Trim().Length < 5)
            {
                MessageBox.Show("Member name is required and cannot exceed 5 characters", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Validate Task Status
            if (string.IsNullOrWhiteSpace(cboTaskStatus.Text))
            {
                MessageBox.Show("Task status is required", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
