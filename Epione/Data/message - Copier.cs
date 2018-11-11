namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.message")]
    public partial class message
    {
        public int id { get; set; }

        [StringLength(255)]
        public string content { get; set; }

        public DateTime? date { get; set; }

        public int? discussion_id { get; set; }

        public virtual discussion discussion { get; set; }
    }
}
