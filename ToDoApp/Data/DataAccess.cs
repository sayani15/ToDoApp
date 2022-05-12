using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Data
{
    public class DataAccess
    {
        /// <summary>
        /// Reads all data from CSV.
        /// </summary>
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
                        var item = new ToDoItem(); //Add an Enum not magic numbers.

                        item.Name = values[0];
                        item.DueDate = DateTime.Parse(values[1]);
                        item.WhoseResponsibility = values[2];
                        item.Description = values[3];
                        item.WhenItWasAdded = DateTime.ParseExact(values[4], "dd/MM/yyyy HH:mm:ss", null);
                        
                        item.Id = Guid.Parse(values[5]);
                        item.IsCompleted = values[6].ToLower() == "yes" ? true : false;


                        readResults.Add(item);
                    }

                    counter += 1;

                    //names.Add(values[0]);
                    //dueDates.Add(values[1]);
                    //whoseResponsibilities.Add(values[2]);
                    //descriptions.Add(values[3]);
                    //whenItWasAddedList.Add(values[4]);
                    //ids.Add(values[5]);
                    //isCompletedList.Add(values[6]);

                }
            }

            //ReadResults = readResults;

            return readResults;

        }

        /// <summary>
        /// Adds a <see cref="ToDoItem"/> to the CSV.
        /// </summary>
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
