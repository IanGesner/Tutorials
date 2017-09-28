using Lab_01_Ian_Gesner.Data;
using Lab_01_Ian_Gesner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_01_Ian_Gesner.Services
{

    public class GroupService : IGroupService
    {

        public bool HasEscalatedPrivileges(Group group)
        {
            return (group.Name == "Administrators");
        }
    }
}