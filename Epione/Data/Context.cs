using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.entities;

namespace Data
{
    public class Context : DbContext
    {
        public Context() : base("name=Epione")
        {

        }
        public virtual DbSet<acts> acts { get; set; }
        public virtual DbSet<appointment> appointment { get; set; }
        public virtual DbSet<compterendu> compterendu { get; set; }
        public virtual DbSet<discussion> discussion { get; set; }
        public virtual DbSet<doctorformation> doctorformation { get; set; }
        public virtual DbSet<medical_prescription> medical_prescription { get; set; }
        public virtual DbSet<message> message { get; set; }
        public virtual DbSet<notification> notification { get; set; }
        public virtual DbSet<pattern> pattern { get; set; }
        public virtual DbSet<planning> planning { get; set; }
        public virtual DbSet<rating> rating { get; set; }
        public virtual DbSet<recommandation> recommandation { get; set; }
        public virtual DbSet<speciality> speciality { get; set; }
        public virtual DbSet<user> user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<acts>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<appointment>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<appointment>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<appointment>()
                .HasMany(e => e.rating)
                .WithOptional(e => e.appointment)
                .HasForeignKey(e => e.appointment_id);

            modelBuilder.Entity<appointment>()
                .HasMany(e => e.recommandation)
                .WithOptional(e => e.appointment)
                .HasForeignKey(e => e.appointment_id);

            modelBuilder.Entity<compterendu>()
                .Property(e => e.contenu)
                .IsUnicode(false);

            modelBuilder.Entity<compterendu>()
                .Property(e => e.document)
                .IsUnicode(false);

            modelBuilder.Entity<compterendu>()
                .Property(e => e.img)
                .IsUnicode(false);

            modelBuilder.Entity<discussion>()
                .HasMany(e => e.message)
                .WithOptional(e => e.discussion)
                .HasForeignKey(e => e.discussion_id);

            modelBuilder.Entity<doctorformation>()
                .Property(e => e.date)
                .IsUnicode(false);

            modelBuilder.Entity<doctorformation>()
                .Property(e => e.diplome)
                .IsUnicode(false);

            modelBuilder.Entity<medical_prescription>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<medical_prescription>()
                .HasMany(e => e.appointment)
                .WithOptional(e => e.medical_prescription)
                .HasForeignKey(e => e.medical_Prescription_id);

            modelBuilder.Entity<message>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.comm)
                .IsUnicode(false);

            modelBuilder.Entity<pattern>()
                .Property(e => e.label)
                .IsUnicode(false);

            modelBuilder.Entity<pattern>()
                .HasMany(e => e.appointment)
                .WithOptional(e => e.pattern)
                .HasForeignKey(e => e.pattern_id);

            modelBuilder.Entity<planning>()
                .HasMany(e => e.appointment)
                .WithOptional(e => e.planning)
                .HasForeignKey(e => e.planning_id);

            modelBuilder.Entity<rating>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<recommandation>()
                .Property(e => e.justification)
                .IsUnicode(false);

            modelBuilder.Entity<recommandation>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<recommandation>()
                .HasMany(e => e.user)
                .WithMany(e => e.recommandation)
                .Map(m => m.ToTable("recommandation_user").MapLeftKey("Recommandation_id").MapRightKey("doctors_id"));

            modelBuilder.Entity<speciality>()
                .Property(e => e.speciality1)
                .IsUnicode(false);

            modelBuilder.Entity<speciality>()
                .HasMany(e => e.user)
                .WithOptional(e => e.speciality)
                .HasForeignKey(e => e.speciality_id);

            modelBuilder.Entity<user>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.street_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.civil_status)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.token)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.ville)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Doctolib)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.OfficeAdress)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Office_Number)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.PaymentMethod)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Remboursement)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.biography)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.acts)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.doctor_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.appointment)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.doctor_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.appointment1)
                .WithOptional(e => e.user1)
                .HasForeignKey(e => e.patient_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.compterendu)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.patient_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.compterendu1)
                .WithOptional(e => e.user1)
                .HasForeignKey(e => e.doctor_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.discussion)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.idUser1);

            modelBuilder.Entity<user>()
                .HasMany(e => e.discussion1)
                .WithOptional(e => e.user1)
                .HasForeignKey(e => e.idUser2);

            modelBuilder.Entity<user>()
                .HasMany(e => e.doctorformation)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.doctor_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.notification)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.doctor_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.notification1)
                .WithOptional(e => e.user1)
                .HasForeignKey(e => e.patient_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.pattern)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.doctor_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.planning)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.doctor_id);
        }
    }
}
