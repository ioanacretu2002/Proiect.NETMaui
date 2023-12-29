using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProiectMedii.Models
{
    public class NailArtistModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get { return FirstName + " " + LastName; } }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [OneToMany]
        public List<BookingModel> Bookings { get; set; }
    }
}
