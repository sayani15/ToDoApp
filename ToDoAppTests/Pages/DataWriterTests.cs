using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToDoApp.Data;
using ToDoApp.Data.Models;
using ToDoApp.Pages;

namespace ToDoAppTests.Pages
{
    [TestClass()]
    public class DataWriterTests
    {
        [TestMethod()]
        public void WriteCorrectDataTest()
        {
            var dA = new DataAccess();

            var item = new ToDoItem() { Description = "iwefuhdjvkc", DueDate = DateTime.Now, Name = "fghjk" };

            dA.AddToDoItem(item);
        }
        
        [TestMethod()]
        public void DeleteCorrectRecord()
        {
            var dA = new DataAccess();

            var id = Guid.NewGuid();

            dA.DeleteToDoItem(id);
        }
              
    }
}