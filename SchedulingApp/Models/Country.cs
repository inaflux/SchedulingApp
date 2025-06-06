﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApp.Models
{

    public class Country
    {
        public int CountryID { get; set; }

        public string CountryName { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastUpdate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Country(int countryID, string countryName, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdatedBy)
        {
            CountryID = countryID;
            CountryName = countryName;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdatedBy = lastUpdatedBy;
        }
    }
}
