using System.ComponentModel.DataAnnotations;
namespace WebApp.Models
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Manager { get; set; }
        public int ManagerPhone { get; set; }
        public int Capacity { get; set; }
        public string? adresse { get; set; }
    }
}
