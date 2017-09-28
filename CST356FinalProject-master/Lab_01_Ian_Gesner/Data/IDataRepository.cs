using Lab_01_Ian_Gesner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01_Ian_Gesner.Data
{
    public interface IDataRepository
    {
        //USERS
        List<User> GetAllUsers();
        void AddUser(User person);
        User GetUser(int? id);
        void UpdateUser(User id);
        void RemoveUser(User id);

        //GROUPS
        List<Group> GetAllGroups();
        List<Group> GetAllGroups(string id);
        Group GetGroup(int? id);
        void AddGroup(Group group);
        void UpdateGroup(Group id);
        void RemoveGroup(Group id);

        //BOOKS
        List<Book> GetAllBooksForAllUsers();
        List<Book> GetAllBooks(string id);
        Book GetBook(int? id);
        void AddBook(Book book);
        void UpdateBook(Book id);
        void RemoveBook(Book id);

        //MOVIES
        List<Movie> GetAllMovies(string id);
        Movie GetMovie(int? id);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie id);
        void RemoveMovie(Movie id);

        //APPLICATION USER
        ApplicationUser GetUser(string id);

        void DisposeContext();
    }
}
