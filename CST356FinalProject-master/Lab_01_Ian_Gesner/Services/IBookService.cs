using Lab_01_Ian_Gesner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01_Ian_Gesner.Services
{
    public interface IBookService
    {
        List<String> GetUsersWithSameBooks(string userId);
    }
}
