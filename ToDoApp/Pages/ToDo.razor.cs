using System;
using System.Collections.Generic;
using ToDoApp.Data;

namespace ToDoApp.Pages
{
    public partial class ToDo
    {

        private List<ToDoItem> ToDoItems = new List<ToDoItem>() {
            new ToDoItem() { Name = "Sayani's Task", Description ="Learn to code"},
            new ToDoItem() {Name = "Andy's Task", Description = "Teach to code", IsCompleted = true}
        };

        public ToDo()
        {
            var reader = new DataReader();
            var CSVRecords = reader.ReadResults;
            ToDoItems.AddRange(CSVRecords);
        }

        public DateTime DateValue { get; set; } = DateTime.Now;
        private ToDoItem ToDoItem = new ToDoItem();

        private bool IsListVisible { get; set; } = false;

        private void DisplayElement()
        {
            var toDoItem = ToDoItem.Clone();
            if (toDoItem.Name != "")
            {
                toDoItem.DueDate = DateValue;
                toDoItem.WhenItWasAdded = System.DateTime.Now;
                ToDoItems.Add(toDoItem);
            }
        }
    }
}