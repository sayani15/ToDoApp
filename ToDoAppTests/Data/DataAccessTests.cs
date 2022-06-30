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
            result.First().Name.Should().Be("sdfgh");
            result.First().DueDate.Should().BeSameDateAs(new DateTime(2022, 3, 25, 18, 45, 21));
            result.First().WhoseResponsibility.Should().Be("sdfghj");
            result.First().Description.Should().Be("wesdfgvh");
            result.First().WhenItWasAdded.Should().BeSameDateAs(new DateTime(2022, 3, 24, 13, 34, 56));
            result.First().Id.Should().Be("940c0799-82d2-4aa4-9726-5d9cba44f9d8");
            result.First().IsCompleted.Should().Be(true);
        }

        [TestMethod]
        public void AddAndDeleteRecordRoundTrip()
        {
            //Arrange
            var dataAccess = new DataAccess();
            var items = new List<ToDoItem>()
            {
                new ToDoItem()
                {
                    Name = "testName", DueDate = new DateTime(2022, 09, 05, 12, 12, 12), WhoseResponsibility = "person",
                    Description  = "testDescription", WhenItWasAdded = new DateTime(2022, 06, 29, 18, 53, 54), Id = Guid.NewGuid(),
                    IsCompleted = false
                },
                new ToDoItem() 
                {
                    Name = "testName2", DueDate = new DateTime(2022, 09, 06, 12, 12, 12), WhoseResponsibility = "person2",
                    Description  = "testDescription2", WhenItWasAdded = new DateTime(2022, 06, 29, 18, 53, 14), Id = Guid.NewGuid(),
                    IsCompleted = false
                },
                new ToDoItem() 
                {
                    Name = "testName3", DueDate = new DateTime(2022, 01, 05, 12, 12, 12), WhoseResponsibility = "person3",
                    Description  = "testDescription3", WhenItWasAdded = new DateTime(2022, 07, 29, 18, 53, 54), Id = Guid.NewGuid(),
                    IsCompleted = true
                }
            };

            var filePath = @"..\..\..\";
            var fileName = "AllItems.csv";

            //Act
            dataAccess.AddToDoItem(items, filePath, fileName);

            //TODO look at this: https://github.com/JoshClose/CsvHelper/issues/697

            //Assert
            var result = dataAccess.ReadFromCSV(filePath, fileName);
            result.Contains(items.ElementAt(0)).Should().BeTrue();
            result.Contains(items.ElementAt(1)).Should().BeTrue();
            result.Contains(items.ElementAt(2)).Should().BeTrue();

            //dataAccess.DeleteToDoItem(items.ElementAt(0).Id);
            //dataAccess.DeleteToDoItem(items.ElementAt(1).Id);
            //dataAccess.DeleteToDoItem(items.ElementAt(2).Id);

            //result = dataAccess.ReadFromCSV(@"../", "AllItems.csv");
            //result.Contains(items.ElementAt(0)).Should().BeFalse();
            //result.Contains(items.ElementAt(1)).Should().BeFalse();
            //result.Contains(items.ElementAt(2)).Should().BeFalse();
        }
    }
}
