namespace lookFantastic.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model3 : DbContext
    {
        public Model3()
            : base("name=Model3")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BeautySalons> BeautySalons { get; set; }
        public virtual DbSet<ClothingShops> ClothingShops { get; set; }
        public virtual DbSet<FitnessCentres> FitnessCentres { get; set; }
        public virtual DbSet<HairDressers> HairDressers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<BeautySalons>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<BeautySalons>()
                .Property(e => e.opening_hours)
                .IsUnicode(false);

            modelBuilder.Entity<BeautySalons>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<BeautySalons>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<BeautySalons>()
                .Property(e => e.addr_street)
                .IsUnicode(false);

            modelBuilder.Entity<BeautySalons>()
                .Property(e => e.Tip)
                .IsUnicode(false);

            modelBuilder.Entity<ClothingShops>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ClothingShops>()
                .Property(e => e.opening_hours)
                .IsUnicode(false);

            modelBuilder.Entity<ClothingShops>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<ClothingShops>()
                .Property(e => e.addr_street)
                .IsUnicode(false);

            modelBuilder.Entity<ClothingShops>()
                .Property(e => e.Tip)
                .IsUnicode(false);

            modelBuilder.Entity<FitnessCentres>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<FitnessCentres>()
                .Property(e => e.opening_hours)
                .IsUnicode(false);

            modelBuilder.Entity<FitnessCentres>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<FitnessCentres>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<FitnessCentres>()
                .Property(e => e.addr_street)
                .IsUnicode(false);

            modelBuilder.Entity<FitnessCentres>()
                .Property(e => e.Tip)
                .IsUnicode(false);

            modelBuilder.Entity<HairDressers>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<HairDressers>()
                .Property(e => e.opening_hours)
                .IsUnicode(false);

            modelBuilder.Entity<HairDressers>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<HairDressers>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<HairDressers>()
                .Property(e => e.addr_street)
                .IsUnicode(false);

            modelBuilder.Entity<HairDressers>()
                .Property(e => e.Tip)
                .IsUnicode(false);
        }
    }
}
