using System;

namespace ToDoApp.Data
{

    public class ToDoItem
    {
        public string Name = "";

        public DateTime DueDate = new DateTime();

        public string WhoseResponsibility = "";

        public string Description = "";

        public DateTime WhenItWasAdded = new DateTime();

        public Guid Id = Guid.NewGuid();

        public bool IsCompleted = false;

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
