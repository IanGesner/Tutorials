using Lab_01_Ian_Gesner.Data;
using Lab_01_Ian_Gesner.Models;
using Lab_01_Ian_Gesner.Services;
using NUnit.Framework;

namespace Lab_01_Tests
{
    [TestFixture]
    public class GroupServiceTest
    {

        [TestCase]
        public void HasEscalatedPrivilegesTest()
        {
            Group group = new Group();
            GroupService groupService = new GroupService();
            group.Name = "Administrators";

            bool result = groupService.HasEscalatedPrivileges(group);


            Assert.AreEqual(true, result);
        }

    }
}
