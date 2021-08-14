using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WellBeingApp.Models
{
    public class User
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string username, string password)
        {
            this.Id = Guid.NewGuid();
            this.Username = username;
            this.Password = password;
        }

        public bool CheckInfo()
        {
            if (!this.Username.Equals("") && !this.Password.Equals(""))
                return true;
            else
                return false;
        }
    }
}
