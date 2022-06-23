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
        /// Adds a <see cref="ToDoItem"/> to the CSV.
        /// </summary>
        void AddToDoItem(List<ToDoItem>items);
    }
}
