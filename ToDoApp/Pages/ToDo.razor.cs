using Blazored.Modal;
using Blazored.Modal.Services;
using System;
using System.Collections.Generic;
using ToDoApp.Data;
using ToDoApp.Data.Models;

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
            var reader = new DataAccess();
            var CSVRecords = reader.ReadFromCSV();
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

        public Guid Guid = Guid.NewGuid();
        public string ModalDisplay = "none;";
        public string ModalClass = "";
        public bool ShowBackdrop = false;
        

        private void OpenModal(Guid id, string name, string description, string dueDate)
        {
            var parameters = new ModalParameters();
            parameters.Add("Id", $"{id}");
            parameters.Add("Name", $"{name}");
            parameters.Add("Description", $"{description}");
            parameters.Add("DueDate", $"{dueDate}");

            Modal.OnClose += ModalClosed;
            Modal.Show<EditItemModal>("Edit", parameters);
        }

        private async void ModalClosed(ModalResult result)
        {
            Modal.OnClose -= ModalClosed;
        }
    }
}