using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApp.Models
{

    public class User
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastUpdate { get; set; }

        public string LastUpdatedBy { get; set; }

        // Constructor
        public User() { }

        public User(int userID, string userName, string password, bool active, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdatedBy)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
            Active = active;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdatedBy = lastUpdatedBy;
        }
    }
}
