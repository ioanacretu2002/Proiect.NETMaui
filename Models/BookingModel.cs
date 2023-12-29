using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace ProiectMedii.Models
{
    public class BookingModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        [ForeignKey(typeof(ServiceModel))]
        public int ServiceID { get; set; }
        public string ServiceType { get; set; }
        [ForeignKey(typeof(NailArtistModel))]
        public int NailArtistID { get; set; }
        public string NailArtistName { get; set; }
        [ForeignKey(typeof(SalonModel))]
        public int SalonID { get; set; }
        public string SalonDetails { get; set; }
    }
}
