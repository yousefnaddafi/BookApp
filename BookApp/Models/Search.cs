using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Models
{
    public class Search
    {
        public List<string> authors { get; set; }
        public List<string> categories { get; set; }
        public string publication { get; set; }
    }
}
