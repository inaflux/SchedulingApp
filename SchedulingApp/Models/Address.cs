using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApp.Models
{

    public class Address
    {
        public int AddressID { get; set; }
        public string AddressName { get; set; }
        public string AddressTwo { get; set; }
        public int CityID { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Address(int addressID, string addressName, string addressTwo, int cityID, string postalCode, string phone, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdatedBy)
        {
            AddressID = addressID;
            AddressName = addressName;
            AddressTwo= addressTwo;
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
