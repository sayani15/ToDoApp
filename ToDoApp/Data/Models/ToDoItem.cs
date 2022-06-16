 using System;

namespace ToDoApp.Data.Models
{
    public class ToDoItem
    {
        public string Name { get; set; } = "";

        public DateTime DueDate { get; set; } = new DateTime();

        public string WhoseResponsibility { get; set; } = "";

        public string Description { get; set; } = "";

        public DateTime WhenItWasAdded { get; set; } = new DateTime();

        public Guid Id { get; set; } = Guid.NewGuid();

        public bool IsCompleted { get; set; } = false;

        public ToDoItem()
        {}

        public ToDoItem(string name, string description) //, Guid id, bool isCompleted)DateTime dueDate, , DateTime whenItWasAdded
        {
            Name = name;
            //dueDate = DueDate;
            //whoseResponsibility = WhoseResponsibility;
            Description = description;
            //whenItWasAdded = WhenItWasAdded;
            //id = Id;
         //   isCompleted = IsCompleted;
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        public ToDoItem Clone()
        {
            var clonedItem = new ToDoItem()
            {
                Name = this.Name,
                Description = this.Description,
                DueDate = this.DueDate,
                Id = this.Id,
                WhenItWasAdded = this.WhenItWasAdded,
                WhoseResponsibility = this.WhoseResponsibility,
                IsCompleted = this.IsCompleted
            };

            return clonedItem;
        }
    }
}
