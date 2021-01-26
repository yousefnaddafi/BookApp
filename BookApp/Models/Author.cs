using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Models
{
    public class Author : IHasIdentity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<Book> Books { get; set; }
    }
}
