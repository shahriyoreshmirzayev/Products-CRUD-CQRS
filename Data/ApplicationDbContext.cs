using Microsoft.EntityFrameworkCore;
using Products.Entities;

namespace Products.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            // Test ma'lumotlari
            //           modelBuilder.Entity<Product>().HasData(
            //    new Product
            //    {
            //        Id = 1,
            //        Name = "Laptop",
            //        Description = "Gaming laptop",
            //        Price = 1500.00m,
            //        Stock = 10,
            //        CreatedAt = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
            //        UpdatedAt = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
            //    },
            //    new Product
            //    {
            //        Id = 2,
            //        Name = "Mouse",
            //        Description = "Wireless mouse",
            //        Price = 25.00m,
            //        Stock = 50,
            //        CreatedAt = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
            //        UpdatedAt = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
            //    },
            //    new Product
            //    {
            //        Id = 3,
            //        Name = "Keyboard",
            //        Description = "Mechanical keyboard",
            //        Price = 75.00m,
            //        Stock = 30,
            //        CreatedAt = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
            //        UpdatedAt = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
            //    }
            //);

        }
    }
}
