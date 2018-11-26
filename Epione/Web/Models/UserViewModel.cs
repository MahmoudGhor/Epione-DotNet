using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class UserViewModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string picture { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public DateTime birthday { get; set; }
        public AdresseModel adresse { get; set; }
        public string ville { get; set; }
        public string sexe { get; set; }
        public string civil_status { get; set; }
        public long created_at { get; set; }
        public string phone { get; set; }
        public Boolean active { get; set; }
        public string token { get; set; }
        public DateTime lastConnect { get; set; }
        public Boolean connected { get; set; }
        public string type { get; set; }
        public string biography { get; set; }
        public string paymentMethod { get; set; }
        public string remboursement { get; set; }
        public string doctolib { get; set; }
        public string officeAdress { get; set; }
        public string website { get; set; }
        public string office_Number { get; set; }
        public List<PatternTypeModel> patterns { get; set; }



    }
}