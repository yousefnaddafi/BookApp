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
        private readonly IRepository<Author> AuthorRepository;
        private readonly IRepository<BookAuthor> BookAuthorRepository;
        private readonly IRepository<BookCategory> BookCategoryRepository;
        private readonly IRepository<Category> CategoryRepository;

        public BookController(IRepository<Book> repository,IRepository<Author> AuthorRepository,IRepository<BookAuthor> BookAuthorRepository,
            IRepository<BookCategory> BookCategoryRepository,IRepository<Category> CategoryRepository)
        {
            this.repository = repository;
            this.AuthorRepository = AuthorRepository;
            this.BookAuthorRepository = BookAuthorRepository;
            this.BookCategoryRepository = BookCategoryRepository;
            this.CategoryRepository = CategoryRepository;
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
        [HttpGet]
        public List<Book> GetAll()
        {
            return repository.GetAll();
        }
        
        [HttpPost("Search")]
        public List<Book> Search([FromBody] Search search)
        {
            var BookIds = new List<int>();
            var Books = repository.GetAll();
            var Authors = AuthorRepository.GetAll();
            var Categories = CategoryRepository.GetAll();
            var BookCategories = BookCategoryRepository.GetAll();
            var BookAuthors = BookAuthorRepository.GetAll();
            var MatchAuthorId = new List<int>();
            // get book ids from the author list search
            if (search.authors != null)
            {
                foreach (var item in search.authors)
                {
                    foreach (var Author in Authors)
                    {
                        if (Author.FullName == item)
                        {
                            if (!MatchAuthorId.Contains(Author.Id))
                            {
                                MatchAuthorId.Add(Author.Id);
                            }

                        }
                    }
                }


                foreach (var item in MatchAuthorId)
                {
                    foreach (var element in BookAuthors)
                    {
                        if (item == element.AuthorId)
                        {
                            if (!BookIds.Contains(element.BookId))
                            {
                                BookIds.Add(element.BookId);
                            }
                        }
                    }
                }
            }
            // get book ids from category list search
            if (search.categories != null)
            {

                var MatchCategoryId = new List<int>();
                foreach (var item in search.categories)
                {
                    foreach (var Category in Categories)
                    {
                        if (Category.Name == item)
                        {
                            if (!MatchCategoryId.Contains(Category.Id))
                            {
                                MatchCategoryId.Add(Category.Id);
                            }

                        }
                    }
                }

                foreach (var item in MatchCategoryId)
                {
                    foreach (var element in BookCategories)
                    {
                        if (item == element.CategoryId)
                        {
                            if (!BookIds.Contains(element.BookId))
                            {
                                BookIds.Add(element.BookId);
                            }
                        }
                    }
                }
            }
            //get book ids from publisher
            
            var publication = Books.FirstOrDefault(x => x.Publisher.Name == search.publication);
            if (publication != null)
            {

                var pubId = publication.Id;
                    
                BookIds.Add(pubId);
            }
            // turn book ids to list of books
            var BookList = new List<Book>();
            foreach(var item in BookIds)
            {
                foreach(var element in Books)
                {
                    if(item == element.Id)
                    {
                        if (!BookList.Contains(element))
                        {
                            BookList.Add(element);
                        }
                    }
                }
            }

            return BookList;
        }

    }
}
