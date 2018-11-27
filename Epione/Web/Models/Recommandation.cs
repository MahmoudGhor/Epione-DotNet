namespace Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.recommandation")]
    public partial class recommandation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public recommandation()
        {
            user = new HashSet<user>();
        }

        public int id { get; set; }


        public long created_at { get; set; }

        [StringLength(255)]
        public string justification { get; set; }

        [Column(TypeName = "bit")]
        public bool recommandPath { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        [Column(TypeName = "bit")]
        public bool validation { get; set; }

        public int? appointment_id { get; set; }

        public virtual appointment appointment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> user { get; set; }
    }
}
