using System;

namespace ToDoApp.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class ToDoItem
    {
        public string Name = "";

        public DateTime DueDate = new DateTime();

        public string WhoseResponsibility = "";

        public string Description = "";

        public DateTime WhenItWasAdded = new DateTime();

        public Guid Id;

        public bool IsCompleted;
    }
}
