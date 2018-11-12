namespace Domain.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.notification")]
    public partial class notification
    {
        public int id { get; set; }

        [StringLength(255)]
        public string comm { get; set; }

        public DateTime? sending_date { get; set; }

        [Column(TypeName = "bit")]
        public bool sentToDoctor { get; set; }

        [Column(TypeName = "bit")]
        public bool sentToPatient { get; set; }

        public int? doctor_id { get; set; }

        public int? patient_id { get; set; }

        public virtual user user { get; set; }

        public virtual user user1 { get; set; }
    }
}
