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
        private readonly IRepository<Book> repository;
        
        public BookController(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public Book Insert([FromBody] Book book)
        {
            repository.Insert(book);
            repository.Save();
            return book;
        }
        [HttpDelete]
        public int Delete([FromQuery] int id)
        {
            repository.Delete(id);
            repository.Save();
            return id;
        }
        [HttpPut]
        public Book Update([FromBody] Book Book)
        {
            repository.Update(Book);
            repository.Save();
            return Book;
        }
        [HttpGet]
        public Book Get([FromQuery]int id)
        {
            var M = repository.Get(id);
            return M;
        }

        [HttpPost("Search")]
        public Book Search([FromBody] )

    }
}
