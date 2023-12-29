using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMedii.Models
{
    public class ServiceModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        
        public string Type { get; set; }
        
        public string Details { get; set; }
        
        public string Duration { get; set; }
        
        public decimal Price { get; set; }
        [OneToMany]
        public List<BookingModel> Bookings { get; set; }
    }
}
