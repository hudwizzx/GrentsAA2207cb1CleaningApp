using System.Windows;
using System.Windows.Controls;
using CleaningApp.Model;
using CleaningApp.ViewModel;

namespace CleaningApp.View
{
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = (MainViewModel)DataContext;
        }

        // Добавление новой заявки
        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            string address = AddressTextBox.Text;
            string clientName = ClientNameTextBox.Text;
            string phone = PhoneTextBox.Text;
            string roomType = ((ComboBoxItem)RoomTypeComboBox.SelectedItem).Content.ToString();
            double roomArea = double.Parse(RoomAreaTextBox.Text);
            string cleaningType = ((ComboBoxItem)CleaningTypeComboBox.SelectedItem).Content.ToString();
            string priority = ((ComboBoxItem)PriorityComboBox.SelectedItem).Content.ToString();

            viewModel.AddOrder(address, clientName, phone, roomType, roomArea, cleaningType, priority);
        }

        // Назначение исполнителя для заявки
        private void AssignExecutor_Click(object sender, RoutedEventArgs e)
        {
            CleaningOrder selectedOrder = OrdersListView.SelectedItem as CleaningOrder;
            if (selectedOrder != null)
            {
                string executor = ExecutorTextBox.Text;
                viewModel.AssignExecutor(selectedOrder, executor);
            }
            else
            {
                MessageBox.Show("Выберите заявку для назначения исполнителя.");
            }
        }
    }
}