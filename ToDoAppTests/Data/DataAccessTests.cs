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
            var result = dataAccess.ReadFromCSV(@"..\..\..\", "AllItems.csv");

            // Assert
            result.First().Name.Should().Be("testName");
            result.First().DueDate.Should().BeSameDateAs(new DateTime(2022, 9, 5, 12, 12, 12));
            result.First().WhoseResponsibility.Should().Be("person");
            result.First().Description.Should().Be("testDescription");
            result.First().WhenItWasAdded.Should().BeSameDateAs(new DateTime(2022, 6, 29, 18, 53, 54));
            result.First().Id.Should().Be("59ee27d9-976f-498b-971c-ebe54ea7885a");
            result.First().IsCompleted.Should().Be(false);
        }

        [TestMethod]
        public void AddAndDeleteRecordRoundTrip()
        {
            //Arrange
            var dataAccess = new DataAccess();
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var id3 = Guid.NewGuid();

            var items = new List<ToDoItem>()
            {
                new ToDoItem()
                {
                    Name = "testName23", DueDate = new DateTime(2022, 09, 05, 12, 12, 12), WhoseResponsibility = "person",
                    Description  = "testDescription", WhenItWasAdded = new DateTime(2022, 06, 29, 18, 53, 54), Id = id1,
                    IsCompleted = false
                },
                new ToDoItem() 
                {
                    Name = "testName24", DueDate = new DateTime(2022, 09, 06, 12, 12, 12), WhoseResponsibility = "person2",
                    Description  = "testDescription2", WhenItWasAdded = new DateTime(2022, 06, 29, 18, 53, 14), Id = id2,
                    IsCompleted = false
                },
                new ToDoItem() 
                {
                    Name = "testName25", DueDate = new DateTime(2022, 01, 05, 12, 12, 12), WhoseResponsibility = "person3",
                    Description  = "testDescription3", WhenItWasAdded = new DateTime(2022, 07, 29, 18, 53, 54), Id = id3,
                    IsCompleted = true
                }
            };

            var filePath = @"..\..\..\";
            var fileName = "AllItems.csv";

            //Act
            dataAccess.AddToDoItem(items, filePath, fileName);
            
            //Assert
            var result = dataAccess.ReadFromCSV(filePath, fileName);

            result.ElementAt(result.Count - 1).Name.Should().Be("testName25");
            result.ElementAt(result.Count - 2).Name.Should().Be("testName24");
            result.ElementAt(result.Count - 3).Name.Should().Be("testName23");

            dataAccess.DeleteToDoItem(items.ElementAt(0).Id, filePath, fileName);
            dataAccess.DeleteToDoItem(items.ElementAt(1).Id, filePath, fileName);
            dataAccess.DeleteToDoItem(items.ElementAt(2).Id, filePath, fileName);

            var result2 = dataAccess.ReadFromCSV(filePath, fileName);
            result2.Contains(items.ElementAt(0)).Should().BeFalse();
            result2.Contains(items.ElementAt(1)).Should().BeFalse();
            result2.Contains(items.ElementAt(2)).Should().BeFalse();
        }
    }
}
