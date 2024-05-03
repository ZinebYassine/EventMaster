using System.ComponentModel.DataAnnotations;
namespace WebApp.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Phone { get; set; }

    }
}

