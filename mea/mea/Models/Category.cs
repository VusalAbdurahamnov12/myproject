using System.Collections.Generic;

namespace mea.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
