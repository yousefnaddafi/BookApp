using BookApp.BookDB;
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
    public class AuthorController : ControllerBase
    {
        private readonly IRepository<Author> repository;
        public AuthorController(IRepository<Author> repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public Author Insert([FromBody ]Author Author)
        {
            repository.Insert(Author);
            
            repository.Save();
            return Author;
        }
        [HttpDelete]
        public int Delete([FromQuery] int id)
        {
            repository.Delete(id);
            repository.Save();
            return id;
        }
        [HttpPut]
        public Author Update([FromBody] Author author)
        {
            repository.Update(author);
            repository.Save();
            return author;
        }
        [HttpGet]
        public Author Get([FromQuery] int id)
        {
            return repository.Get(id); 
        }


    }
}
