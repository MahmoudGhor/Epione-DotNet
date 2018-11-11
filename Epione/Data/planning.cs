namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.planning")]
    public partial class planning
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public planning()
        {
            appointment = new HashSet<appointment>();
        }

        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? day { get; set; }

        [Column(TypeName = "bit")]
        public bool disponibility { get; set; }

        public DateTime? end_at { get; set; }

        public DateTime? start_at { get; set; }

        public int? doctor_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<appointment> appointment { get; set; }

        public virtual user user { get; set; }
    }
}
