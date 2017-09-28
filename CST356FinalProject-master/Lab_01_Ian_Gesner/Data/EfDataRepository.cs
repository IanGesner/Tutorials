using Lab_01_Ian_Gesner.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab_01_Ian_Gesner.Data
{
    public class EfDataRepository : IDataRepository
    {
        private readonly DatabaseContext _databaseContext;

        public EfDataRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        //USERS
        public List<User> GetAllUsers()
        {
            return _databaseContext.User.ToList();
        }
        public void AddUser(User user)
        {
            foreach (var group in user.Group)
            {
                _databaseContext.Groups.Attach(group);
            }
            _databaseContext.User.Add(user);
            _databaseContext.SaveChanges();
        }
        public User GetUser(int? id)
        {
            return _databaseContext.User.Find(id);
        }
        public void UpdateUser(User user)
        {
            _databaseContext.Entry(user).State = EntityState.Modified;
            _databaseContext.SaveChanges();
        }
        public void RemoveUser(User user)
        {
            _databaseContext.User.Remove(user);
            _databaseContext.SaveChanges();
        }

        //GROUPS
        public List<Group> GetAllGroups()
        {
            return _databaseContext.Groups.ToList();
        }
        public List<Group> GetAllGroups(string id)
        {
            return _databaseContext.Groups.Where(g => g.Id == id).ToList();
        }
        public Group GetGroup(int? id)
        {
            return _databaseContext.Groups.Find(id);
        }
        public void AddGroup(Group group)
        {
            _databaseContext.Groups.Add(group);
            _databaseContext.SaveChanges();
        }
        public void UpdateGroup(Group id)
        {
            _databaseContext.Entry(id).State = EntityState.Modified;
            _databaseContext.SaveChanges();
        }
        public void RemoveGroup(Group id)
        {
            _databaseContext.Groups.Remove(id);
            _databaseContext.SaveChanges();
        }

        //BOOKS
        public List<Book> GetAllBooksForAllUsers()
        {
            return _databaseContext.Books.ToList();
        }
        public List<Book> GetAllBooks(string id)
        {
            return _databaseContext.Books.Where(b => b.Id == id).ToList();
        }
        public Book GetBook(int? id)
        {
            return _databaseContext.Books.Find(id);
        }
        public void AddBook(Book book)
        {
            _databaseContext.Books.Add(book);
            _databaseContext.SaveChanges();
        }
        public void UpdateBook(Book id)
        {
            _databaseContext.Entry(id).State = EntityState.Modified;
            _databaseContext.SaveChanges();
        }
        public void RemoveBook(Book id)
        {
            _databaseContext.Books.Remove(id);
            _databaseContext.SaveChanges();
        }

        //MOVIES
        public List<Movie> GetAllMovies(string id)
        {
            return _databaseContext.Movies.Where(b => b.Id == id).ToList();
        }
        public Movie GetMovie(int? id)
        {
            return _databaseContext.Movies.Find(id);
        }
        public void AddMovie(Movie movie)
        {
            _databaseContext.Movies.Add(movie);
            _databaseContext.SaveChanges();
        }
        public void UpdateMovie(Movie id)
        {
            _databaseContext.Entry(id).State = EntityState.Modified;
            _databaseContext.SaveChanges();
        }
        public void RemoveMovie(Movie id)
        {
            _databaseContext.Movies.Remove(id);
            _databaseContext.SaveChanges();
        }

        //USER
        public ApplicationUser GetUser(string id)
        {
            return _databaseContext.Users.Find(id);
        }

        public void DisposeContext()
        {
            _databaseContext.Dispose();
        }

    }
}