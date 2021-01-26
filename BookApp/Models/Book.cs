using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Models
{
    public class Book : IHasIdentity
    {
        public int Id { get; set; }
        public string Title { get; set; }
     
        public DateTime PublishDate { get; set; }
        public string ISBN { get; set; }
       

        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }

        public List<BookCategory> bookCategories { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
    }
}
