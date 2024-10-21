using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningApp.Model
{
    public class CleaningOrder
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string ClientName { get; set; }
        public string Phone { get; set; }
        public string RoomType { get; set; }
        public double RoomArea { get; set; }
        public string CleaningType { get; set; }
        public string Priority { get; set; }
        public string Executor { get; set; } = "Не назначен";
        public string Status { get; set; } = "Ожидает обработки";
        public string TimeSpent { get; set; }
        public string MaterialsUsed { get; set; }
        public string ClientFeedback { get; set; }
    }
}

