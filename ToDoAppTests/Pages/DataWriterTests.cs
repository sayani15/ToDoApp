using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToDoApp.Data;
using ToDoApp.Pages;

namespace ToDoAppTests.Pages
{
    [TestClass()]
    public class DataWriterTests
    {
        [TestMethod()]
        public void WriteCorrectDataTest()
        {
            var dataWriter = new DataAccess();
            dataWriter.AddToDoItem(new ToDoApp.Data.Models.ToDoItem());
        }
              
    }
}