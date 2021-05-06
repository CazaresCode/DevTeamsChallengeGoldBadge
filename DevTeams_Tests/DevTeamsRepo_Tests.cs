using DevTeams_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DevTeams_Tests
{
    [TestClass]
    public class DevTeamsRepo_Tests
    {
        private Developer _dev;
        private DevTeamsRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new DevTeamsRepo();
            _dev = new Developer(007, "James", "Bond", TeamAssignment.FrontEnd); 
            _repo.AddDeveloperToDirectory(_dev);
        }

        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            //AAA
            //Arrange - already done in the Test Initialize method (above)

            //Act
            bool addResult = _repo.AddDeveloperToDirectory(_dev);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetMembers_ShouldReturnCorrectCollection()
        {
            //Arrange

            //Act
            List<Developer> directory = _repo.GetMembers(); //We had to use ctrl + . to add the Generic system above because it is a new class

            //Assert
            bool directoryHasMembers = directory.Contains(_dev); //content is the list... Contains is a built in method for Lists
            Assert.IsTrue(directoryHasMembers);
        }

        [TestMethod]
        public void GetByFirstName_ShouldReturnCorrectContent()
        {
            //Arrange

            //Act
            Developer searchResult = _repo.GetDeveloperByFirstName("Max");

            //Assert
            Assert.AreEqual(_dev, searchResult);
        }


        [TestMethod]
        public void UpdateExistingDeveloper_ShouldReturnUpdatedValue()
        {
            //Arrange

            //Act
            _repo.UpdateExistingDeveloper("Max", new Developer(007, "James", "Bond", TeamAssignment.FrontEnd));

            //Assert
            Assert.AreEqual(_dev.FirstName, "James");
        }

        [TestMethod]
        public void DeleteExistingDeveloper_ShouldReturnTrue()
        {
            bool wasDeleted = _repo.DeleteExistingDeveloper("Max");

            Assert.IsTrue(wasDeleted);
        }

    }
}
