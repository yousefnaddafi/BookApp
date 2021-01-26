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
    public class PublisherController : ControllerBase
    {
        private readonly IRepository<Publisher> repository;
        public PublisherController(IRepository<Publisher> repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public Publisher Insert([FromBody] Publisher publisher)
        {
            repository.Insert(publisher);

            repository.Save();
            return publisher;
        }
        [HttpDelete]
        public int Delete([FromQuery] int id)
        {
            repository.Delete(id);
            repository.Save();
            return id;
        }
        [HttpPut]
        public Publisher Update([FromBody] Publisher publisher)
        {
            repository.Update(publisher);
            repository.Save();
            return publisher;
        }
        [HttpGet]
        public Publisher Get([FromQuery] int id)
        {
            return repository.Get(id);
        }
    }
}
