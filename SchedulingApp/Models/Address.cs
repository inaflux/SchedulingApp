using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApp.Models
{
    //addressId int AI PK
    //address varchar(50)
    //address2 varchar(50)
    //cityId int
    //postalCode varchar(10)
    //phone varchar(20)
    //createDate datetime
    //createdBy varchar(40)
    //lastUpdate timestamp
    //lastUpdateBy varchar(40)
    public class Address
    {
        public int AddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int CityID { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Address(int addressID, string addressLine1, string addressLine2, int cityID, string postalCode, string phone, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdatedBy)
        {
            AddressID = addressID;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            CityID = cityID;
            PostalCode = postalCode;
            Phone = phone;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdatedBy = lastUpdatedBy;
        }
    }
}
