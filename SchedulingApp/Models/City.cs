﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApp.Models
{
    
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }

        public int CountryID { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastUpdate { get; set; }

        public string LastUpdatedBy { get; set; }

        public City() { }

        public City(int cityID, string cityName, int countryID, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdatedBy)
        {
            CityID = cityID;
            CityName = cityName;
            CountryID = countryID;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdatedBy = lastUpdatedBy;
        }
    }
}
