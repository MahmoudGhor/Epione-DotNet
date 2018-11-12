namespace Domain.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.discussion")]
    public partial class discussion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public discussion()
        {
            message = new HashSet<message>();
        }

        public int id { get; set; }

        public DateTime? created_at { get; set; }

        public int? idUser1 { get; set; }

        public int? idUser2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<message> message { get; set; }

        public virtual user user { get; set; }

        public virtual user user1 { get; set; }
    }
}
