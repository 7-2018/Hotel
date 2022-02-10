
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataLayer.Models
{
    public class Reservation
    {
        [MaxLength(13)]
        [Column(name: "Guest_ID", Order = 0), ForeignKey("HotelGuest")]
        public string GuestID { get; set; }

        [Column(name: "Hotel_Room_Number", Order = 1), ForeignKey("HotelRoom")]
        public int HotelRoomNumber { get; set; }

        [Column(name: "CheckIn_date", Order = 2)]
        public DateTime CheckInDate { get; set; }

        [Column(name: "CheckOut_date", Order = 3)]
        public DateTime? CheckOutDate { get; set; }

        [Column(name: "Accepted", Order = 4)]
        public bool Accepted { get; set; }

        [JsonIgnore]
        public Guest HotelGuest { get; set; }
        
        [JsonIgnore]
        public Room HotelRoom { get; set; }

        public Reservation()
        {

        }

        public Reservation(string guestID, int hotelRoomNumber, DateTime checkInDate, DateTime checkOutDate)
        {
            GuestID = guestID;
            HotelRoomNumber = hotelRoomNumber;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }
    }
}
