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
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> repository;
        public CategoryController(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public Category Insert([FromBody] Category Category)
        {
            repository.Insert(Category);

            repository.Save();
            return Category;
        }
        [HttpDelete]
        public int Delete([FromQuery] int id)
        {
            repository.Delete(id);
            repository.Save();
            return id;
        }
        [HttpPut]
        public Category Update([FromBody] Category Category)
        {
            repository.Update(Category);
            repository.Save();
            return Category;
        }
        [HttpGet]
        public Category Get([FromQuery] int id)
        {
            return repository.Get(id);
        }
    }
}
