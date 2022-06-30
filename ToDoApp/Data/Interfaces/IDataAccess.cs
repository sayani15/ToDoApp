using System;
using System.Collections.Generic;
using ToDoApp.Data.Models;

namespace ToDoApp.Data.Interfaces
{
    public interface IDataAccess
    {
        /// <summary>
        /// Reads all data from specified CSV.
        /// </summary>
        /// <param name="filePath">Relative filepath to the CSV.</param>
        /// <param name="fileName">Name of the CSV file to read from.</param>
        List<ToDoItem> ReadFromCSV(string filePath, string fileName);

        /// <summary>
        /// Deletes the specified to do item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="filePath">The file path.</param>
        /// <param name="fileName">Name of the file.</param>
        void DeleteToDoItem(Guid id, string filePath, string fileName);

        /// <summary>
        /// Deletes all items.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="fileName">Name of the file.</param>
        void DeleteAllItems(string filePath, string fileName);

        /// <summary>
        /// Updates the specified to do item.
        /// </summary>
        /// <param name="toDoItem">To do item.</param>
        /// <param name="filePath">The file path.</param>
        /// <param name="fileName">Name of the file.</param>
        void Update(ToDoItem toDoItem, string filePath, string fileName);

        /// <summary>
        /// Adds a <see cref="ToDoItem"/> to the CSV.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <param name="filePath">The file path.</param>
        /// <param name="fileName">Name of the file.</param>
        void AddToDoItem(List<ToDoItem>items, string filePath, string fileName);
    }
}
