using FakeItEasy;
using Lab_01_Ian_Gesner.Data;
using Lab_01_Ian_Gesner.Models;
using Lab_01_Ian_Gesner.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Lab_01_Tests
{
    [TestFixture]
    public class BookServiceTest
    {
        [TestCase]
        public void GetUsersWithSameBooksTest()
        {
            var fakeRepository = A.Fake<IDataRepository>();
            var fakeApplicationUser = A.Fake<ApplicationUser>();
            List<string> emailsReturned = new List<string>();
            int numberOfEmailsReturned;

            BookService bookService = new BookService(fakeRepository);

        
            List<Book> books = new List<Book>
                    {
                        new Book(){ BookID = 1, Title = "Not Unique", Id = "1"},
                        new Book(){ BookID = 2, Title = "Not Unique", Id = "1" },
                        new Book(){ BookID = 3, Title = "Unique", Id = "2" },
                        new Book(){ BookID = 4, Title = "Unique 1", Id = "3" },
                        new Book(){ BookID = 5, Title = "Unique 2", Id = "4" },
                        new Book(){ BookID = 6, Title = "Unique 3", Id = "5" },
                    };

            foreach (Book book in books)
            {
                fakeRepository.AddBook(book);
            }


            emailsReturned = bookService.GetUsersWithSameBooks("1");
            numberOfEmailsReturned = emailsReturned.Count;

            Assert.AreEqual(0, numberOfEmailsReturned);
        }

    }
}
