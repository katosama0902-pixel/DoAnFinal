using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class CinemaModel : DbContext
    {
        public CinemaModel()
            : base("name=CinemaModel")
        {
        }

        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<movie> movies { get; set; }
        public virtual DbSet<ticket> tickets { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<customer>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.tickets)
                .WithOptional(e => e.customer)
                .HasForeignKey(e => e.customer_id);

            modelBuilder.Entity<movie>()
                .Property(e => e.movie_id)
                .IsUnicode(false);

            modelBuilder.Entity<movie>()
                .Property(e => e.movie_image)
                .IsUnicode(false);

            modelBuilder.Entity<ticket>()
                .Property(e => e.movie_id)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.tickets)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.staff_id)
                .WillCascadeOnDelete(false);
        }
    }
}
