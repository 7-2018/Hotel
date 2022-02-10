using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Room
    {
        [Column(name: "Room_Number")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int RoomNumber { get; set; }

        [Required]
        [Column(name: "Room_Type")]
        public string RoomType { get; set; }

        [Required]
        [Column(name: "Room_Size")]
        public int RoomSize { get; set; }

        [Column(name: "Available")]
        public bool Dostupna { get; set; }

    }
}
