namespace Domain.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.pattern")]
    public partial class pattern
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pattern()
        {
            appointment = new HashSet<appointment>();
        }

        public int id { get; set; }

        [Column(TypeName = "bit")]
        public bool isActif { get; set; }

        [StringLength(255)]
        public string label { get; set; }

        public int periode { get; set; }

        public float price { get; set; }

        public int? doctor_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<appointment> appointment { get; set; }

        public virtual user user { get; set; }
    }
}
