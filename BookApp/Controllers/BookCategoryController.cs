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
    public class BookCategoryController : ControllerBase
    {
        private readonly IRepository<BookCategory> repository;
        public BookCategoryController(IRepository<BookCategory> repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public BookCategory Insert([FromBody] BookCategory BookCategory)
        {
            repository.Insert(BookCategory);

            repository.Save();
            return BookCategory;
        }
        [HttpDelete]
        public int Delete([FromQuery] int id)
        {
            repository.Delete(id);
            repository.Save();
            return id;
        }
        [HttpPut]
        public BookCategory Update([FromBody] BookCategory BookCategory)
        {
            repository.Update(BookCategory);
            repository.Save();
            return BookCategory;
        }
        [HttpGet]
        public BookCategory Get([FromQuery] int id)
        {
            return repository.Get(id);
        }
    }
}
