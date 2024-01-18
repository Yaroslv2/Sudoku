using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Time {  get; set; }

        public User(string userame, string time) 
        {
            Username = userame;
            Time = time;
        }

        public int CompareTime(User user)
        {
            for (int i = 0; i < Time.Length || i < user.Time.Length; i++)
            {
                if (Time[i] < user.Time[i]) return -1;
                if (Time[i] > user.Time[i]) return 1;
            }

            return 0;
        }
    }
}
