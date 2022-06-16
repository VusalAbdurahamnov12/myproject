using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace mea.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Description { get; set; }
        public double Price  { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
