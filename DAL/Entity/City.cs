using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
   public class City
    {
        public int ID { get; set; }
        public string CityName { get; set; }
        public int CityCode { get; set; }
        public string DistrictName { get; set; }
        public int ZipCode { get; set; }

    }
}
