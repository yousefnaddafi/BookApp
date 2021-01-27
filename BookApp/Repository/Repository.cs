using BookApp.BookDB;
using BookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Repository
{
    public class Repository<T> : IRepository<T> where T : class , IHasIdentity
    {
        private readonly LibraryDB BookDB;
        public Repository(LibraryDB BookDB)
        {
            this.BookDB = BookDB;
        }
        public void Delete(int id)
        {
            var item = this.BookDB.Set<T>().FirstOrDefault(x => x.Id == id);
            this.BookDB.Remove(item);

        }

        public T Get(int id)
        {
            return this.BookDB.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Insert(T item)
        {
            this.BookDB.Add<T>(item);
        }

        public T Update(T item)
        {
            this.BookDB.Update(item);
            return item;
        }
        public void Save()
        {
            this.BookDB.SaveChanges();
        }
        public List<T> GetAll()
        {
            return this.BookDB.Set<T>().ToList();
        }

        
    }
}
