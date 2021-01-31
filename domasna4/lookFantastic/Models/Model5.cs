namespace lookFantastic.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model5 : DbContext
    {
        public Model5()
            : base("name=Model5")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<BeautySalon> BeautySalons { get; set; }
        public virtual DbSet<ClothingShop> ClothingShops { get; set; }
        public virtual DbSet<FitnessCentre> FitnessCentres { get; set; }
        public virtual DbSet<HairDresser> HairDressers { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<BeautySalon>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<BeautySalon>()
                .Property(e => e.opening_hours)
                .IsUnicode(false);

            modelBuilder.Entity<BeautySalon>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<BeautySalon>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<BeautySalon>()
                .Property(e => e.addr_street)
                .IsUnicode(false);

            modelBuilder.Entity<BeautySalon>()
                .Property(e => e.Tip)
                .IsUnicode(false);

            modelBuilder.Entity<BeautySalon>()
                .HasMany(e => e.Reviews)
                .WithOptional(e => e.BeautySalon)
                .HasForeignKey(e => e.id_beautysalon);

            modelBuilder.Entity<ClothingShop>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ClothingShop>()
                .Property(e => e.opening_hours)
                .IsUnicode(false);

            modelBuilder.Entity<ClothingShop>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<ClothingShop>()
                .Property(e => e.addr_street)
                .IsUnicode(false);

            modelBuilder.Entity<ClothingShop>()
                .Property(e => e.Tip)
                .IsUnicode(false);

            modelBuilder.Entity<ClothingShop>()
                .HasMany(e => e.Reviews)
                .WithOptional(e => e.ClothingShop)
                .HasForeignKey(e => e.id_clothingshop);

            modelBuilder.Entity<FitnessCentre>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<FitnessCentre>()
                .Property(e => e.opening_hours)
                .IsUnicode(false);

            modelBuilder.Entity<FitnessCentre>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<FitnessCentre>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<FitnessCentre>()
                .Property(e => e.addr_street)
                .IsUnicode(false);

            modelBuilder.Entity<FitnessCentre>()
                .Property(e => e.Tip)
                .IsUnicode(false);

            modelBuilder.Entity<FitnessCentre>()
                .HasMany(e => e.Reviews)
                .WithOptional(e => e.FitnessCentre)
                .HasForeignKey(e => e.id_fitnesscentre);

            modelBuilder.Entity<HairDresser>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<HairDresser>()
                .Property(e => e.opening_hours)
                .IsUnicode(false);

            modelBuilder.Entity<HairDresser>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<HairDresser>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<HairDresser>()
                .Property(e => e.addr_street)
                .IsUnicode(false);

            modelBuilder.Entity<HairDresser>()
                .Property(e => e.Tip)
                .IsUnicode(false);

            modelBuilder.Entity<HairDresser>()
                .HasMany(e => e.Reviews)
                .WithOptional(e => e.HairDresser)
                .HasForeignKey(e => e.id_hairdresser);

            modelBuilder.Entity<Review>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Review>()
                .Property(e => e.komentar)
                .IsUnicode(false);
        }
    }
}
