using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalLibrary.Model;

namespace DigitalLibrary.Repository
{
    internal class UserRepository : IRepository<User>
    {
        public void Add(User user)
        {
            using (var db = new LibraryContext())
            {
                db.Users.Add(user);
            }
        }

        public User GetById(int id)
        {
            using (var db = new LibraryContext())
            {
                return db.Users.Find(id);
            }
        }

        public void Update(User entity)
        {
            using (var db = new LibraryContext())
            {
                db.Users.Update(entity);
            }
        }

        public void Delete(User user)
        {
            using (var db = new LibraryContext())
            {
                db.Users.Remove(user);
            }
        }
        public List<User> GetAll()
        {
            using (var db = new LibraryContext())
            {
                return db.Users.ToList();
            }
        }

    }
}
