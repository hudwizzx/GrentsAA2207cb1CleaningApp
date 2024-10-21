using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using CleaningApp.Model;

namespace CleaningApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<CleaningOrder> orders = new List<CleaningOrder>();
        private List<CleaningOrder> completedOrders = new List<CleaningOrder>();
        private int nextOrderId = 1;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<CleaningOrder> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged("Orders");
            }
        }

        // Метод для добавления новой заявки
        public void AddOrder(string address, string clientName, string phone, string roomType, double roomArea, string cleaningType, string priority)
        {
            CleaningOrder newOrder = new CleaningOrder
            {
                Id = nextOrderId++,
                Address = address,
                ClientName = clientName,
                Phone = phone,
                RoomType = roomType,
                RoomArea = roomArea,
                CleaningType = cleaningType,
                Priority = priority
            };

            orders.Add(newOrder);
            OnPropertyChanged("Orders");
            MessageBox.Show("Заявка добавлена!");
        }

        // Метод для назначения исполнителя
        public void AssignExecutor(CleaningOrder selectedOrder, string executor)
        {
            if (selectedOrder != null)
            {
                selectedOrder.Executor = executor;
                selectedOrder.Status = "Исполнитель назначен";
                OnPropertyChanged("Orders");
                MessageBox.Show($"Исполнитель {executor} назначен на заявку {selectedOrder.Id}");
            }
            else
            {
                MessageBox.Show("Выберите заявку для назначения исполнителя.");
            }
        }

        // Уведомление об изменениях свойств
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
