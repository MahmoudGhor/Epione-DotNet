namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.compterendu")]
    public partial class compterendu
    {
        public int id { get; set; }

        [StringLength(255)]
        public string contenu { get; set; }

        [StringLength(255)]
        public string document { get; set; }

        [StringLength(255)]
        public string img { get; set; }

        public int? doctor_id { get; set; }

        public int? patient_id { get; set; }

        public virtual user user { get; set; }

        public virtual user user1 { get; set; }
    }
}
