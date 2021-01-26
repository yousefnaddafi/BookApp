using BookApp.Models;
using BookApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book> Bookrepository;
        
        public BookController(IRepository<Book> repository)
        {
            this.Bookrepository = repository;
        }

        [HttpPost]
        public Book Insert([FromBody] Book book)
        {
            Bookrepository.Insert(book);
            Bookrepository.Save();
            return book;
        }
        [HttpGet]
        public Book Get([FromQuery]int id)
        {
            var M = Bookrepository.Get(id);
            return M;
        }
    }
}
