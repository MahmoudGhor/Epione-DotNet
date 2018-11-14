using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class TokenModel
    {
        public string succes { get; set; }
        public int user_id { get; set; }
        public string token { get; set; }
        public string type { get; set; }
    }
}