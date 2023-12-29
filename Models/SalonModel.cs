using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProiectMedii.Models
{
    public class SalonModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Details { get { return Name + " " + Address; } }
        [OneToMany]
        public List<BookingModel> Bookings { get; set; }
    }
}
