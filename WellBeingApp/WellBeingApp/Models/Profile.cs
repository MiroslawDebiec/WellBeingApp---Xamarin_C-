using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WellBeingApp.Models
{
    public class Profile
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Score { get; set; }

        public Profile()
        {

        }

        public Profile(Guid userId)
        {
            this.Id = Guid.NewGuid();
            this.UserId = userId;
        }
    }
}
