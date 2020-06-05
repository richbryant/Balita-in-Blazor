using System.Collections.Generic;

namespace Balita.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Post> Posts { get; set; }
    }
}