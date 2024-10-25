using System.ComponentModel.DataAnnotations;

namespace ASPNETMOD192.Models
{
    public class Client
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateOnly Birthday { get; set; }

        [StringLength(100)]//Limitar a quantidade de caracteres a 100
        public string Addres { get; set; }

        [Required]
        public string VATNumber { get; set; }

        public DateTime AdmissionDate { get; set; }

        public DateTime DeactivationDate { get; set;}

        public string? CellPhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        // CreatedBy Todo Fixme









    }

}
