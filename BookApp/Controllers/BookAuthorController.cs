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
    public class BookAuthorController : ControllerBase
    {
        private readonly IRepository<BookAuthor> repository;
        public BookAuthorController(IRepository<BookAuthor> repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public BookAuthor Insert([FromBody] BookAuthor BookAuthor)
        {
            repository.Insert(BookAuthor);

            repository.Save();
            return BookAuthor;
        }
        [HttpDelete]
        public int Delete([FromQuery] int id)
        {
            repository.Delete(id);
            repository.Save();
            return id;
        }
        [HttpPut]
        public BookAuthor Update([FromBody] BookAuthor Bookauthor)
        {
            repository.Update(Bookauthor);
            repository.Save();
            return Bookauthor;
        }
        [HttpGet]
        public BookAuthor Get([FromQuery] int id)
        {
            return repository.Get(id);
        }
    }
}
