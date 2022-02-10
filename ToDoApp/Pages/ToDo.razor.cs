using System;
using System.Collections.Generic;
using ToDoApp.Data;

namespace ToDoApp.Pages
{
    public partial class ToDo
    {
        public DateTime DateValue { get; set; } = DateTime.Now;
        private ToDoItem ToDoItem = new ToDoItem();

        private List<ToDoItem> ToDoItems = new List<ToDoItem>() {
            new ToDoItem() { Name = "Sayani's Task", Description ="Learn to code"},
            new ToDoItem() {Name= "Andy's Task", Description = "Teach to code" }
        };

        private bool IsListVisible { get; set; } = false;

        private void DisplayElement()
        {
            var toDoItem = ToDoItem.Clone();
            if (toDoItem.Name != "")
            {
                toDoItem.WhenItWasAdded = System.DateTime.Now;
                ToDoItems.Add(toDoItem);
            }
        }

    }
}