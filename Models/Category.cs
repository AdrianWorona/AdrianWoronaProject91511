using System.Collections;
using System.Collections.Generic;

namespace AdrianWoronaProject91511.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}
