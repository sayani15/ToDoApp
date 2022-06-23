using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.Data;
using ToDoApp.Data.Models;

namespace ToDoAppTests.Data
{
    [TestClass()]
    public class DataAccessTests
    {
        [TestMethod()]
        public void CheckThatReadFromCSVReturnsTheExpectedData()
        {
            // Arange
            var dataAccess = new DataAccess();

            // Act
            var result = dataAccess.ReadFromCSV(@"../", "AllItems.csv");

            // Assert
            result.First().Name.Should().Be("sdfgh");
            result.First().DueDate.Should().BeSameDateAs(new DateTime(2022, 3, 25));
        }

        [TestMethod]
        public void AddAndDeleteRecordRoundTrip()
        {
            //Arrange
            var dataAccess = new DataAccess();
            var items = new List<ToDoItem>()
            {
                new ToDoItem() {Name = ... },
                new ToDoItem() {Name = ... },
                new ToDoItem() {Name = ... }
            };

            //Act
            dataAccess.AddToDoItem(items);

            //Assert
            var result = dataAccess.ReadFromCSV(@"../", "AllItems.csv");
            result.Contains(items.ElementAt(0)).Should().BeTrue();
            result.Contains(items.ElementAt(1)).Should().BeTrue();
            result.Contains(items.ElementAt(2)).Should().BeTrue();

            dataAccess.DeleteToDoItem(items.ElementAt(0).Id);
            dataAccess.DeleteToDoItem(items.ElementAt(1).Id);
            dataAccess.DeleteToDoItem(items.ElementAt(2).Id);

            result = dataAccess.ReadFromCSV(@"../", "AllItems.csv");
            result.Contains(items.ElementAt(0)).Should().BeFalse();
            result.Contains(items.ElementAt(1)).Should().BeFalse();
            result.Contains(items.ElementAt(2)).Should().BeFalse();
        }
    }
}
