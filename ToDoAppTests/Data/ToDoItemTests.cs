using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            var clone = toDoItem.Clone();

            Assert.AreEqual("A Test Name", clone.Name);
        }
    }
}