using DigitalLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Repository
{
    internal class BookRepository : IRepository<Book>
    {
        public void Add(Book entity)
        {
            using (var db = new LibraryContext())
            {
                db.Books.Add(entity);
            }
        }

        public Book GetById(int id)
        {
            using (var db = new LibraryContext())
            {
                return db.Books.Find(id);
            }
        }

        public void Update(Book entity)
        {
            using (var db = new LibraryContext())
            {
                db.Books.Update(entity);
            }
        }

        public void Delete(Book entity)
        {
            using (var db = new LibraryContext())
            {
                db.Books.Remove(entity);
            }
        }

        public List<Book> GetAll()
        {
            using (var db = new LibraryContext())
            {
                return db.Books.ToList();
            }
        }

        /// <summary>
        /// 1 - Получать список книг определенного жанра и вышедших между определенными годами.
        /// </summary>
        /// <param name="genreName"></param>
        /// <param name="earlyYear"></param>
        /// <param name="lateYear"></param>
        /// <returns></returns>
        public List<Book> GetBooksByGenreAndYears(string genreName, int earlyYear, int lateYear)
        {
            using var db = new LibraryContext();

            var a =
                from book in db.Books
                from genre1 in book.Genres
                where book.YearOfIssue >= earlyYear
                where book.YearOfIssue <= lateYear
                where genre1.Name.Contains(genreName)
                select book;

            return a.ToList();

        }

        /// <summary>
        /// 2 - Получать количество книг определенного автора в библиотеке.
        /// </summary>
        /// <param name="authorName"></param>
        /// <returns></returns>
        public int GetCountBooksByAuthor(string authorName)
        {
            using var db = new LibraryContext();

            return 
                (from books in db.Books
                from booksAuthor in books.Authors
                where booksAuthor.Name.Equals(authorName)
                select books).Count();
        }

        /// <summary>
        /// 3 - Получать количество книг определенного жанра в библиотеке.
        /// </summary>
        /// <param name="genreName"></param>
        /// <returns></returns>
        public int GetCountBooksByGenre(string genreName)
        {
            using var db = new LibraryContext();

            var genre = db.Genres.Where(g => g.Name.Equals(genreName)).ToArray();

            return db.Books.Count(b => b.Genres.Contains(genre[0]));
        }

        /// <summary>
        /// 4 - Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        /// </summary>
        /// <param name="authorName"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool HasBookByAthorAndTitle(string authorName, string title)
        {
            using var db = new LibraryContext();

            var author = db.Authors.Where(a => a.Name.Equals(authorName)).ToArray()[0];

            return db.Books.Any(b => b.Authors.Contains(author) );
        }

        //TODO 6   7

        /// <summary>
        /// 5 - Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool HasBookByUser(string userName, string bookTitle)
        {
            using var db = new LibraryContext();

            return 
                (from books in db.Books
                from booksUser in books.Users 
                where books.Title.Equals(bookTitle)
                where booksUser.Name.Equals(userName)
                select books ).Any();
        }

        /// <summary>
        /// 6 - Получать количество книг на руках у пользователя.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int GetBooksByUser(string userName)
        {
            var db = new LibraryContext();
            
            return 
                (from books in db.Books
                from booksUser in books.Users
                where booksUser.Name.Equals(userName)
                select books).Count();
        }

        /// <summary>
        /// 7 - Получение последней вышедшей книги.
        /// </summary>
        /// <returns></returns>
        public Book GetLatestPublishedBook()
        {
            var db = new LibraryContext();

            //int maxAge = db.Users.Max(u => u.Age);

            var publishedBook = 
                (from book in  db.Books
                where book.YearOfIssue == db.Books.Max(b => b.YearOfIssue)
                select book).First();
            
            return publishedBook;
        }


        /// <summary>
        /// 8 - Получение списка всех книг, отсортированного в алфавитном порядке по названию
        /// </summary>
        /// <param name="authorName"></param>
        /// <returns></returns>
        public List<Book> GetAllBooksByAlfavit()
        {
            using var db = new LibraryContext();

            return db.Books.OrderBy(b => b.Title).ToList();
        }

        /// <summary>
        /// 9 - Получение списка всех книг, отсортированного в порядке убывания года их выхода
        /// </summary>
        /// <param name="authorName"></param>
        /// <returns></returns>
        public List<Book> GetAllBooksByYear()  //9
        {
            using var db = new LibraryContext();

            return db.Books.OrderByDescending(b => b.YearOfIssue).ToList();
        }
    }
}
