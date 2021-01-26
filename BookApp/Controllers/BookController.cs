﻿using BookApp.Models;
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
        private readonly IBookRepository<Book> repository;
        public BookController(IBookRepository<Book> repository)
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
    }
}
