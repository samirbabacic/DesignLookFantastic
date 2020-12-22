using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lookFantastic.Models
{
    public class Location
    {
        public Location()
        {
            FitnessCentres = new List<FitnessCentres>();
            HairDressers = new List<HairDressers>();
            ClothingShops = new List<ClothingShops>();
            BeautySalons = new List<BeautySalons>();
        }
        public List<FitnessCentres> FitnessCentres { get; set; }
        public List<HairDressers> HairDressers { get; set; }
        public List<ClothingShops> ClothingShops { get; set; }
        public List<BeautySalons> BeautySalons { get; set; }
    }
}