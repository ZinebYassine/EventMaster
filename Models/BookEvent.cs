using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class BookEvent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? date { get; set; }
        public string? Venue { get; set; }

        [NotMapped]
        public List<SelectListItem> AvailableVenues { get; set; }
    }
}
