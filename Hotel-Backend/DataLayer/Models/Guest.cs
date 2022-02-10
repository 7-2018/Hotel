using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Guest
    {
        [MaxLength(13)]
        [Column(name: "ID")]
        [Key]
        public string ID { get; set; }

        [Required]
        [Column(name: "Name")]
        public string Name { get; set; }

        [Required]
        [Column(name: "Surname")]
        public string Surname { get; set; }

        [Required]
        [MaxLength(9)]
        [Column(name: "ID_card_number")]
        public string IDCardNumber { get; set; }

        public Guest()
        {

        }

        public Guest(string iD, string name, string surname, string iDCardNumber)
        {
            ID = iD;
            Name = name;
            Surname = surname;
            IDCardNumber = iDCardNumber;
        }
    }
}
