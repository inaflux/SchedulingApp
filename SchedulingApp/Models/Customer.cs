using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApp.Models
{
    //customerId int AI PK
    //customerName varchar(45)
    //addressId int
    //active tinyint(1)
    //createDate datetime
    //createdBy varchar(40)
    //lastUpdate timestamp
    //lastUpdateBy varchar(40)
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public int AddressID { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastUpdate { get; set; }

        public string LastUpdatedBy { get; set; }


        // Constructor for creating a new customer

        public Customer() { }

        public Customer(int customerID, string customerName, int addressID, bool active, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdatedBy)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            AddressID = addressID;
            Active = active;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdatedBy = lastUpdatedBy;
        }


    }
}
