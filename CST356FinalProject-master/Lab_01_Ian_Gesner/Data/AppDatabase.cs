using Lab_01_Ian_Gesner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_01_Ian_Gesner.Data
{
    public static class AppDatabase
    {
        public static List<User> Users;

        static AppDatabase()
        {
            Users = new List<User>();
        }
    }
}