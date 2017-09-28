using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab_01_Ian_Gesner.Models;
using Lab_01_Ian_Gesner.Data;

//Go to NuGet manager and do the following:

//Search for all owin packages.Install the latest version(3.0.1) of those that are already 
//installed for your new service project.
//Install EntityFramework for your new project.

namespace AppService.Controllers
{
    public class UserController : ApiController
    {
        EfDataRepository _dataRepository = new EfDataRepository();

        public IEnumerable<User> GetAllUsers()
        {
            var users = _dataRepository.GetAllUsers();
            return _dataRepository.GetAllUsers();
        }

        public IHttpActionResult GetUser(int id)
        {
            var user = _dataRepository.GetUser(id);
            return Ok(user);
        }
    }
}
