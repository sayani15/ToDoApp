using System.Collections.Generic;
using ToDoApp.Data.Models;

namespace ToDoApp.Data.Interfaces
{
    public interface IDataAccess
    {
        /// <summary>
        /// Reads all data from CSV.
        /// </summary>
        List<ToDoItem> ReadFromCSV();

        /// <summary>
        /// Adds a <see cref="ToDoItem"/> to the CSV.
        /// </summary>
        void AddToDoItem(ToDoItem item);
    }
}
