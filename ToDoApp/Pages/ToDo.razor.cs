using System.Collections.Generic;
using ToDoApp.Data;

namespace ToDoApp.Pages
{
    public partial class ToDo
    {
        private ToDoItem ToDoItem = new ToDoItem();

        private List<ToDoItem> ToDoItems = new List<ToDoItem>() { 
            new ToDoItem() { Name = "Sayani's Task", Description ="Learn to code"}, 
            new ToDoItem() {Name= "Andy's Task", Description = "Teach to code" }
        };

        private bool IsListVisible { get; set; } = false;

        private void DisplayElement()
        {
        //TODO: add a clone method for the ToDoItem.
            var toDoItem = new ToDoItem() {Name = ToDoItem.Name, Description = ToDoItem.Description, DueDate = ToDoItem.DueDate };

            ToDoItems.Add(toDoItem);
        }

        private void ToggleList()
        {
            //TODO Make this a lambdaw inline.
            IsListVisible = !IsListVisible;
        }

    }
}