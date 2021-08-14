using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WellBeingApp.Models
{
    public class UserEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Eatting { get; set; }
        public int Sleeping { get; set; }
        public int Activity { get; set; }
        public int Emotional { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public Guid ProfileId { get; set; }

        public UserEntry()
        {

        }
    }
}
