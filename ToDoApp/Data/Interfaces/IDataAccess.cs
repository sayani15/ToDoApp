using System;
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
        /// Adds a <see cref="ToDoItem" /> to the CSV.
        /// </summary>
        /// <param name="toDoItem">Item to add.</param>
        void AddToDoItem(ToDoItem toDoItem);
        
        /// <summary>
        /// Deletes the item matching the specified id.
        /// </summary>
        /// <param name="id">Id of the item to delete.</param>
        void DeleteToDoItem(Guid id);

        /// <summary>
        /// Updates the given <see cref="ToDoItem" /> in the CSV.
        /// </summary>
        /// <param name="toDoItem">Item to update.</param>
        void UpdateToDoItem(ToDoItem toDoItem);
    }
}
