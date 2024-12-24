using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_Webiste.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Column("PatientName",TypeName = "varchar(100)")]
        [Required]
        public string Name { get; set; }

        [Column("Email", TypeName = "varchar(200)")]
        [Required]
        public string Email { get; set; }

        [Column("PhoneNo", TypeName = "varchar(20)")] 
        [Required]
        public string Phone { get; set; }

        [Column("Date", TypeName ="date")]
        [Required]
        public DateTime Date { get; set; }

        [Column("Slots", TypeName = "varchar(200)")]
        [Required]
        public   string Slots { get; set; }

        [Column("No_Of_Persons", TypeName = "varChar(20)")]
        [Required(ErrorMessage = "Number of persons is required.")]
        [Range(1, 25, ErrorMessage = "Number of persons must be between 1 and 25.")]
        public string No_Of_Persons { get; set; }
    }
} 