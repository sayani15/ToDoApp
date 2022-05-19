//using CsvHelper;
//using CsvHelper.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ToDoApp.Data;

//namespace ToDoApp.Pages
//{
//    public class DataWriter
//    {
//        public void AddToAllItems()
//        {
//            var record = new List<ToDoItem>
//            {
//                new ToDoItem { Name = "one", Description = "whghebg",
//                    DueDate = DateTime.Now, Id = Guid.NewGuid(), IsCompleted = false,
//                    WhenItWasAdded = DateTime.Now.AddDays(-10), WhoseResponsibility = "wuakejnrg" },
//            };

//            // Append to the file.
//            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
//            {
//                // Don't write the header again.
//                HasHeaderRecord = false,
//            };
//            using (var stream = File.Open(@"C:/Users/Sayani Pathak/source/repos/ToDoApp/ToDoApp/Data/AllItems - Copy.csv", FileMode.Append))
//            using (var writer = new StreamWriter(stream))
//            using (var csv = new CsvWriter(writer, config))
//            {
//                csv.WriteRecords(record);
//            }
//        }
//    }
//}
