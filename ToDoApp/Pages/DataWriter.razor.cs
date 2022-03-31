using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data;

namespace ToDoApp.Pages
{
    public class DataWriter
    {
        public void AddToAllItems()
        {
            //var data = new[]
            //{
            //    new Project { CustomerName = "Olivia", Title = "Mother"},
            //    new Project { CustomerName = "Lili", Title = "Elder Sister"}
            //};

            var records = new List<ToDoItem>
            {
                new ToDoItem { Name = "Andy's Task", 
                    //Description = "Teach to code", IsCompleted = true, Id = new Guid(),
                    //DueDate = new DateTime(), WhenItWasAdded = DateTime.Now, WhoseResponsibility = "rtyuio"
                    }
            };

            using (var writer = new StreamWriter(@"C:/Users/Sayani Pathak/source/repos/ToDoApp/ToDoApp/Data/AllItems.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }

        public void AddToAllItems2()
        {
            var records = new List<ToDoItem>
            {
                new ToDoItem { Id = new Guid(), Name = "one" },
            };
            
            using (var writer = new StreamWriter(@"C:/Users/Sayani Pathak/source/repos/ToDoApp/ToDoApp/Data/AllItems - Copy.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }


        }

        public class Foo
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
