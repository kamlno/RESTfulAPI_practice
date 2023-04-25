using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulAPI_practice.Models
{
    public class student
    {
        public int id { get; set; }
        public DateTime birth_date { get; set; }
        public string full_name { get; set; }
        public string gender { get; set; }
        public DateTime star_date{ get; set; }
    }
}
