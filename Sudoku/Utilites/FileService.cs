using Newtonsoft.Json;
using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sudoku.Utilites
{
    public class FileService
    {
        private string Path = "C:\\Users\\yaros\\OneDrive\\Рабочий стол\\course-papers\\Sudoku\\Sudoku\\Assets\\Data\\scoreList.json";

        public List<User> LoadData()
        {
            bool fileExists = File.Exists(Path);
            if (!fileExists)
            {
                File.CreateText(Path).Dispose();
                return new List<User>();
            }
            using (var reader = File.OpenText(Path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<User>>(fileText) ?? new List<User>();
            }
        }

        public void SaveData(User user)
        {
            List<User> list = LoadData();
            list.Add(user);
            list.Sort(delegate (User left, User right) { return left.CompareTime(right); });
            using(StreamWriter writter = File.CreateText(Path))
            {
                string output = JsonConvert.SerializeObject(list);
                writter.Write(output);
            }
        }
    }
}
