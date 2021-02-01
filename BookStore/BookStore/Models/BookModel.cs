using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string AutherName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
