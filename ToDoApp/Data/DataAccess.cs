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
        public List<ToDoItem> ReadFromCSV()
        {
            var readResults = new List<ToDoItem>();

            using (var reader = new StreamReader(@"Data/AllItems.csv"))
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
                        item.DueDate = DateTime.Parse(values[(int)Enums.Enums.ToDoItemProperties.DueDate]);
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

        public void DeleteToDoItem(Guid id)
        {
            var allDataItems = ReadFromCSV();

            var index = allDataItems.Where(i => i.Id == id).ToList().First();

            allDataItems.Remove(index);

            using (var writer = new StreamWriter(@"C:/Users/Sayani Pathak/source/repos/ToDoApp/ToDoApp/Data/AllItems - Copy.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(allDataItems);
            }
        }

        ///<inheritdoc/>
        public void AddToDoItem()
        {
            var record = new List<ToDoItem>
            {
                new ToDoItem { Name = "one", Description = "whghebg",
                    DueDate = DateTime.Now, Id = Guid.NewGuid(), IsCompleted = false,
                    WhenItWasAdded = DateTime.Now.AddDays(-10), WhoseResponsibility = "wuakejnrg" },
            };

            // Append to the file.
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                // Don't write the header again.
                HasHeaderRecord = false,
            };
            using (var stream = File.Open(@"C:/Users/Sayani Pathak/source/repos/ToDoApp/ToDoApp/Data/AllItems - Copy.csv", FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(record);
            }
        }
    }
}
