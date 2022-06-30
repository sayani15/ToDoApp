using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using ToDoApp.Data.Interfaces;
using ToDoApp.Data.Models;

namespace ToDoApp.Data
{
    public class DataAccess : IDataAccess
    {
        ///<inheritdoc/>
        public List<ToDoItem> ReadFromCSV(string filePath, string fileName)
        {
            var readResults = new List<ToDoItem>();

            using (var reader = new StreamReader(filePath + fileName))
            {
                List<string> names = new();
                List<string> dueDates = new();
                List<string> whoseResponsibilities = new();
                List<string> descriptions = new();
                List<string> whenItWasAddedList = new();
                List<string> ids = new();
                List<string> isCompletedList = new();
                var counter = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (counter >= 1)
                    {
                        var item = new ToDoItem();

                        item.Name = values[(int)Enums.Enums.ToDoItemProperties.Name];
                        item.DueDate = DateTime.ParseExact(values[(int)Enums.Enums.ToDoItemProperties.DueDate], "dd/MM/yyyy HH:mm:ss", null);
                        item.WhoseResponsibility = values[(int)Enums.Enums.ToDoItemProperties.WhoseResponsibility];
                        item.Description = values[(int)Enums.Enums.ToDoItemProperties.Description];
                        item.WhenItWasAdded = DateTime.ParseExact(values[(int)Enums.Enums.ToDoItemProperties.WhenItWasAdded], "dd/MM/yyyy HH:mm:ss", null);
                        item.Id = Guid.Parse(values[(int)Enums.Enums.ToDoItemProperties.Id]);
                        item.IsCompleted = values[(int)Enums.Enums.ToDoItemProperties.IsCompleted].ToLower() == "yes" ? true : false;


                        readResults.Add(item);
                    }
                    counter += 1;
                }
            }
            return readResults;
        }

        ///<inheritdoc/>
        public void DeleteToDoItem(Guid id, string filePath, string fileName)
        {
            var allDataItems = ReadFromCSV("Data", "AllItems.csv");

            var index = allDataItems.Where(i => i.Id == id).ToList().First();

            allDataItems.Remove(index);

            using (var writer = new StreamWriter(filePath + fileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(allDataItems);
            }
        }
        
        ///<inheritdoc/>
        public void DeleteAllItems(string filePath, string fileName)
        {
            using (var writer = new StreamWriter(filePath + fileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(new List<ToDoItem>());
            }
        }

        ///<inheritdoc/>
        public void AddToDoItem(List<ToDoItem> items, string filePath, string fileName)
        {
            var record = new List<ToDoItem>();
            record.AddRange(items);

            // Append to the file.
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                // Don't write the header again.
                HasHeaderRecord = false,
            };
            using (var stream = File.Open(filePath + fileName, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords( record);
            }
        }

        ///<inheritdoc/>
        public void Update(ToDoItem toDoItem, string filePath, string fileName)
        {
            var allDBRecords = ReadFromCSV("Data", "AllITems.csv");
            var updatingIndex = -1;

            for (int i = 0; i < allDBRecords.Count; i++)
            {
                if (allDBRecords[i].Id == toDoItem.Id)
                {
                    updatingIndex = i;
                }
            }

            allDBRecords.RemoveAt(updatingIndex);
            allDBRecords.Add(toDoItem);

            DeleteAllItems(filePath, fileName);
            AddToDoItem(allDBRecords, filePath, fileName);
        }
    }
}
