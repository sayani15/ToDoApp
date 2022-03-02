using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Data
{
    public class DataAccessManager
    {
        public List<ToDoItem> ReadFromCSV()
        {
            var readResults = new List<ToDoItem>();

            using (var reader = new StreamReader(@"C:\Users\Sayani Pathak\source\repos\ToDoApp\ToDoApp\Data\AllItems.csv")) //TODO show relative file paths
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
                    if (counter >= 1)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        var item = new ToDoItem()
                        {
                            Name = values[0],
                            DueDate = DateTime.Parse(values[1]),
                            WhoseResponsibility = values[2],
                            Description = values[3],
                            WhenItWasAdded = DateTime.Parse(values[4]),
                            Id = Guid.Parse(values[5]),
                            IsCompleted = values[6].ToLower() == "yes" ? true : false
                        };

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

            return readResults;                     

        }
       
    }
}
