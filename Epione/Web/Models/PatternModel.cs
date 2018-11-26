using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class PatternModel
    {
        public int id { get; set; }
        public int idDoctor { get; set; }
        public string label { get; set; }
        public string price { get; set; }
        public string periode { get; set; }
        //public IEnumerable<PatternModel> patternModels { get; set; }


    }
}