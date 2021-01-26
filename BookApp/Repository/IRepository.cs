using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Repository
{
    public interface IRepository<T>
    {
        T Get(int id);
        void Insert(T item);
        T Update(T item);
        void Delete(int id);
        void Save();
    }
}
