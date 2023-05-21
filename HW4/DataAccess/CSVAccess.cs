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
        string? baseDirectoryPath = string.Empty;
        string? dataFolderPath = string.Empty;
        string? csvFilePath = string.Empty;

        public List<User> GetAllUsers()
        {
            baseDirectoryPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?
                         .Parent?.Parent?.Parent?.FullName;
            dataFolderPath = Path.Combine(baseDirectoryPath, "Data");
            csvFilePath = Path.Combine(dataFolderPath, "Users.csv");


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
    }
}
