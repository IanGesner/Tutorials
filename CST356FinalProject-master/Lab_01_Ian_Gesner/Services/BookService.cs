using Lab_01_Ian_Gesner.Data;
using Lab_01_Ian_Gesner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_01_Ian_Gesner.Services
{
    public class BookService : IBookService
    {
        private readonly IDataRepository _dataRepository;

        public BookService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public List<String> GetUsersWithSameBooks(string userId)
        {
            var books = _dataRepository.GetAllBooks(userId);
            var allBooks = _dataRepository.GetAllBooksForAllUsers();
            List<string> returnEmails = new List<string>();

            foreach (Book globalBook in allBooks)
            {
                foreach (Book usersBook in books)
                {
                    if (usersBook.Title == globalBook.Title && usersBook.Id != globalBook.Id)
                    {
                        string email = _dataRepository.GetUser(globalBook.Id).Email;
                        returnEmails.Add(email);
                    }

                }
            }

            return returnEmails;
        }
    }
}