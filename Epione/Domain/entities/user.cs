namespace Domain.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("epione.user")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            acts = new HashSet<acts>();
            appointment = new HashSet<appointment>();
            appointment1 = new HashSet<appointment>();
            compterendu = new HashSet<compterendu>();
            compterendu1 = new HashSet<compterendu>();
            discussion = new HashSet<discussion>();
            discussion1 = new HashSet<discussion>();
            doctorformation = new HashSet<doctorformation>();
            notification = new HashSet<notification>();
            notification1 = new HashSet<notification>();
            pattern = new HashSet<pattern>();
            planning = new HashSet<planning>();
            recommandation = new HashSet<recommandation>();
        }

        [Required]
        [StringLength(31)]
        public string role { get; set; }

        public int id { get; set; }

        [Column(TypeName = "bit")]
        public bool active { get; set; }

        [StringLength(255)]
        public string city { get; set; }

        public int postal_code { get; set; }

        [StringLength(255)]
        public string street_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthday { get; set; }

        [StringLength(255)]
        public string civil_status { get; set; }

        [Column(TypeName = "bit")]
        public bool? connected { get; set; }

        
        public long created_at { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string firstname { get; set; }

        [Column(TypeName = "date")]
        public DateTime? lastConnect { get; set; }

        [StringLength(255)]
        public string lastname { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string phone { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        public string sexe { get; set; }

        [StringLength(255)]
        public string token { get; set; }

        [StringLength(255)]
        public string username { get; set; }

        [StringLength(255)]
        public string ville { get; set; }

        [StringLength(255)]
        public string Doctolib { get; set; }

        [StringLength(255)]
        public string OfficeAdress { get; set; }

        [StringLength(255)]
        public string Office_Number { get; set; }

        [StringLength(255)]
        public string PaymentMethod { get; set; }

        [StringLength(255)]
        public string Remboursement { get; set; }

        [StringLength(255)]
        public string Website { get; set; }

        [StringLength(255)]
        public string biography { get; set; }

        public int? speciality_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<acts> acts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<appointment> appointment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<appointment> appointment1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compterendu> compterendu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compterendu> compterendu1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<discussion> discussion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<discussion> discussion1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<doctorformation> doctorformation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notification> notification { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notification> notification1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pattern> pattern { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<planning> planning { get; set; }

        public virtual speciality speciality { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recommandation> recommandation { get; set; }
    }
}
