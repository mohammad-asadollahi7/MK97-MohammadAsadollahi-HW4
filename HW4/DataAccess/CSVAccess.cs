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
        public string GetFilePath()
        {
            string? baseDirectoryPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?
                         .Parent?.Parent?.Parent?.FullName;
            string? dataFolderPath = Path.Combine(baseDirectoryPath, "Data");
            string? csvFilePath = Path.Combine(dataFolderPath, "Users.csv");
            return csvFilePath;
        }

        public List<User> GetAllUsers()
        {

            string? FilePath = GetFilePath();

            var Configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                Delimiter = ","
            };

            using (FileStream fs = new FileStream(FilePath, FileMode.Open))
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

        public void SetUser(User user)
        {
            var users = GetAllUsers();
            user.ID = users.Count() + 1;
            users.Add(user); 


            string? FilePath = GetFilePath();

            var Configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                Delimiter = ","
            };
            using (FileStream fs = new FileStream(FilePath, FileMode.Open))
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
