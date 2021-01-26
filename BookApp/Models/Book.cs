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
        public string Publication { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public string ISBN { get; set; }
        public List<string> Authors { get; set; }
        public List<string> Categories { get; set; }
    }
}
