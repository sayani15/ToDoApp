using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToDoApp.Pages;

namespace ToDoAppTests.Pages
{
    [TestClass()]
    public class DataWriterTests
    {
        [TestMethod()]
        public void WriteCorrectDataTest()
        {
            var dataWriter = new DataWriter();
            dataWriter.AddToAllItems();
        }
              
    }
}