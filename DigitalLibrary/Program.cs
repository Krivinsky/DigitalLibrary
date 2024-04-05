using DigitalLibrary.Model;
using DigitalLibrary.Repository;

namespace DigitalLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AddData();

            BookRepository bookRepository = new BookRepository();

            var books = bookRepository.GetBooksByGenreAndYears("Detective", 1970, 1980); //1
            
            foreach (Book book in books)
            {
                Console.WriteLine("Task 1 - " + book.Title);
            }


            Console.WriteLine("Task 2 - " + bookRepository.GetCountBooksByAuthor("AuthorName2")); //2 - 2 
            Console.WriteLine("Task 3 - " + bookRepository.GetCountBooksByGenre("Fantasy")); //3 - 2
            Console.WriteLine("Task 4 - " + bookRepository.HasBookByAthorAndTitle("AuthorName1", "BookTitle1")); //4 - True
            Console.WriteLine("Task 5 - " + bookRepository.HasBookByUser("NameUser2", "BookTitle3")); //5 - True
            Console.WriteLine("Task 6 - " + bookRepository.GetBooksByUser("NameUser1"));
            Console.WriteLine("Task 7 - " + bookRepository.GetLatestPublishedBook().YearOfIssue);
            
            Console.WriteLine("Task 8: " + "\r\n");  //8
            books = bookRepository.GetAllBooksByAlfavit();
            foreach (Book book in books)
            {
                Console.WriteLine(book.Title);
            }


            Console.WriteLine("Task 9: " + "\r\n");  //9
            books = bookRepository.GetAllBooksByYear();
            foreach (Book book in books)
            {
                Console.WriteLine(book.YearOfIssue);
            }
        }

        /// <summary>
        /// Создание таблиц и добавление данных в таблицы
        /// </summary>
        private static void AddData()
        {
            using (var db = new LibraryContext())
            {
                User user1 = new User { Name = "NameUser1", Email = "EmailUser1@mail.com" };
                User user2 = new User { Name = "NameUser2", Email = "EmailUser2@mail.com" };
                db.AddRange(user1, user2);

                Author author1 = new Author { Name = "AuthorName1" };
                Author author2 = new Author { Name = "AuthorName2" };
                Author author3 = new Author { Name = "AuthorName3" };
                db.AddRange(author1, author2, author3);

                Book book1 = new Book { Title = "BookTitle1", YearOfIssue = 1977 };
                Book book2 = new Book { Title = "BookTitle2", YearOfIssue = 1967 };
                Book book3 = new Book { Title = "BookTitle3", YearOfIssue = 1957 };
                Book book4 = new Book { Title = "BookTitle4", YearOfIssue = 1947 };
                db.AddRange(book1, book2, book3, book4);

                Genre genre1 = new Genre { Name = "Detective" };
                Genre genre2 = new Genre { Name = "Fantasy" };
                db.AddRange(genre1, genre2);

                user1.Books.AddRange(new Book[] {book1, book2});
                user2.Books.AddRange(new Book[] {book3});

                book1.Authors.Add(author1);
                book1.Genres.Add(genre1);

                book2.Authors.AddRange(new Author[] {author2, author3});
                book2.Genres.Add(genre1);

                book3.Authors.Add(author2);
                book3.Genres.Add(genre2);

                book4.Authors.Add(author3);
                book4.Genres.Add(genre2);
                
                db.SaveChanges();
            }
        }
    }
}
