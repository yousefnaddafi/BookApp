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
        private readonly IBookRepository<Author> repository;
        public AuthorController(IBookRepository<Author> repository)
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
    }
}
