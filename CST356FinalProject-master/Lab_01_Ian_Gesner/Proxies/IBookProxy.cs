using Lab_01_Ian_Gesner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01_Ian_Gesner.Proxies
{
    public interface IBookProxy
    {
        Task<List<Book>> GetAllBooksAsync();
    }
}
