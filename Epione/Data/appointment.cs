namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.appointment")]
    public partial class appointment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public appointment()
        {
            recommandation = new HashSet<recommandation>();
        }

        public int id { get; set; }

        public DateTime? date { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        public int? idDoctor { get; set; }

        public int? medical_Prescription_id { get; set; }

        public int? idPatient { get; set; }

        public int? pattern_id { get; set; }

        public int? planning_id { get; set; }

        public int? rating_id { get; set; }

        public virtual pattern pattern { get; set; }

        public virtual rating rating { get; set; }

        public virtual medical_prescription medical_prescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recommandation> recommandation { get; set; }

        public virtual user user { get; set; }

        public virtual planning planning { get; set; }

        public virtual user user1 { get; set; }
    }
}
