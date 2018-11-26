using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class PatternTypeModel
    {
        public int id { get; set; }
        public Boolean actif { get; set; }
        public string label { get; set; }
        public string price { get; set; }
        public string periode { get; set; }
    }
}