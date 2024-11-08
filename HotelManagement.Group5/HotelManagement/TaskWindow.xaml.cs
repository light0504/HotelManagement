using HotelManagement.BLL.Services;
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
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        private TaskService _service = new TaskService();   
        public TaskWindow()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DAL.Entities.Task? selected = dgvData.SelectedItem as DAL.Entities.Task;

            if (selected == null)
            {
                MessageBox.Show("Please select an air-con before deleting", "Select one", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult answer = MessageBox.Show("Are you sure?", "Confirm?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No)
            {
                return;
            }
            _service.DeleteTask(selected);
            FillDataGrid(_service.GetAllTasks());
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            DetailTaskWindow detail = new DetailTaskWindow();
            detail.ShowDialog(); 
            FillDataGrid(_service.GetAllTasks());
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            {
                MessageBoxResult answer = MessageBox.Show("Do you really want to exist?", "Exit?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (answer == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
            }
        }
        private void FillDataGrid(List<DAL.Entities.Task> list)
        {
            dgvData.ItemsSource = null; 
            dgvData.ItemsSource = list; 
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            dgvData.ItemsSource = null;
            dgvData.ItemsSource = _service.GetAllTasks();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvData.ItemsSource = _service.GetAllTasks();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DAL.Entities.Task? selected = dgvData.SelectedItem as DAL.Entities.Task;


            if (selected == null)
            {
                MessageBox.Show("Please select an air-con before  updating", "Select one", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DetailTaskWindow detail = new DetailTaskWindow();

            detail.EditedOne = selected;
            detail.ShowDialog();
            FillDataGrid(_service.GetAllTasks());
        }

        private void dgvData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvData.SelectedItem is DAL.Entities.Task selected)
            {
                txtTaskID.Text = selected.TaskId.ToString();
                txtMemberID.Text = selected.MemberId.ToString();
                txtRoomNumber.Text = selected.RoomNumber.ToString();
                txtDateCreate.Text = selected.DateCreate.ToString();
                txtMemberName.Text = selected.MemberName.ToString();
                txtTaskStatus.Text = selected.TaskStatus;
            }
        }
    }
}
