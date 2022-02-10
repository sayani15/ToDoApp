using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ToDoApp.Data.Tests
{
    [TestClass()]
    public class ToDoItemTests
    {
        [TestMethod()]
        public void CloneTest()
        {
            var toDoItem = new ToDoItem();
            toDoItem.Name = "A Test Name";
            toDoItem.Description = "wow what an amazing task description";
            toDoItem.WhoseResponsibility = "me";
            toDoItem.IsCompleted = false;
            toDoItem.Id = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D");
            toDoItem.WhenItWasAdded = new DateTime(2022, 2, 10, 18, 50, 0);

            var clone = toDoItem.Clone();

            Assert.AreEqual("A Test Name", clone.Name);
            Assert.AreEqual("wow what an amazing task description", clone.Description);
            Assert.AreEqual("me", clone.WhoseResponsibility);
            Assert.AreEqual(false, clone.IsCompleted);
            Assert.AreEqual(new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D"), clone.Id);
            Assert.AreEqual(new DateTime(2022, 2, 10, 18, 50, 0), clone.WhenItWasAdded);

        }
              
    }
}