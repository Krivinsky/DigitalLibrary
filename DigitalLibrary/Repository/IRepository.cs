using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);

        T GetById(int id);

        void Update(T entity);

        void Delete(T entity);

        List<T> GetAll();
    }
}
