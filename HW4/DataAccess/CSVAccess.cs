using CsvHelper.Configuration;
using CsvHelper;
using HW4.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4.DataAccess
{
    public class CSVAccess
    {
        private string csvFilePath;
        public CSVAccess()
        {
            string? baseDirectoryPath = Directory.GetParent
                         (AppDomain.CurrentDomain.BaseDirectory)?
                         .Parent?.Parent?.Parent?.FullName;
            string? dataFolderPath = Path.Combine(baseDirectoryPath, "Data");
           csvFilePath = Path.Combine(dataFolderPath, "Users.csv");
        }
        

        public List<User> GetAllUsers()
        {

            var Configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                Delimiter = ","
            };

            using (FileStream fs = new FileStream(csvFilePath, FileMode.Open))
            {
                using (TextReader reader = new StreamReader(fs, Encoding.UTF8))
                {
                    using (var csv = new CsvReader(reader, Configuration))
                    {

                        var data = csv.GetRecords<User>().ToList();
                        return data;
                    }
                }
            }
        }

        public void SetAllUsers(List<User> users)
        {

            System.IO.File.WriteAllText(csvFilePath, string.Empty);

            var Configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                Delimiter = ","
            };
            using (FileStream fs = new FileStream(csvFilePath, FileMode.Open))
            {
                using (TextWriter writer = new StreamWriter(fs, Encoding.UTF8))
                {
                    using (var csv = new CsvWriter(writer, Configuration))
                    {
                        csv.WriteRecords(users);
                    }
                }
            }
        }
    }
}
