namespace Domain.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.doctorformation")]
    public partial class doctorformation
    {
        public int id { get; set; }

        [StringLength(255)]
        public string date { get; set; }

        [StringLength(255)]
        public string diplome { get; set; }

        public int? doctor_id { get; set; }

        public virtual user user { get; set; }
    }
}
