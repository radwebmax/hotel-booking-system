using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace HotelReservation.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter the issued date.")]
        [DataType(DataType.Date)]
        public DateTime ArrivalDateTime { get; set; }

        [Required(ErrorMessage = "Enter the issued date.")]
        [DataType(DataType.Date)]
        public DateTime DepartureDateTime { get; set; }

        [StringLength(50)]
        public string Room { get; set; }

        [StringLength(50)]
        public string RoomPreference { get; set; }

        public int GuestsNumber { get; set; }

        public int ChildrenNumber { get; set; }


        [NotMapped]
        public string ArrivalDate => ArrivalDateTime.ToString("MM/dd/yyyy");


        [NotMapped]
        public string DepartureDate => DepartureDateTime.ToString("MM/dd/yyyy");



    }
}
