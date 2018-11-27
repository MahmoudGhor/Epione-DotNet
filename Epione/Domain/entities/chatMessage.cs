using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public partial class chatMessage
    {
        [StringLength(255)]
        public string content { get; set; }

        [StringLength(255)]
        public string doctorName { get; set; }

        [StringLength(255)]
        public string patientName { get; set; }

        [StringLength(255)]
        public string isPatient { get; set; }
    }
}
