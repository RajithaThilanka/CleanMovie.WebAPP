using CleanMovie.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanMovie.Infrastructure.Persistence;

public class MovieDbContext:DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options):base(options) { }

        public DbSet <Movie> Movies { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<MovieRental> MovieRentals { get; set; }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to many (Member and Rentals)
            modelBuilder.Entity<Member>()
                .HasOne<Rental>(s => s.Rental)
                .WithMany(r => r.Members)
                .HasForeignKey(s => s.rentalId);

            //Many to Many (Rental and Movie)
            modelBuilder.Entity<MovieRental>()
                .HasKey(g => new { g.rentalId, g.movieId });

            //Handle Decimal
            modelBuilder.Entity<Rental>()
                .Property(p => p.rentalPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Movie>()
                .Property(p => p.moviePrice)
                .HasColumnType("decimal(18,2)");
        }

        private void UpdateTimestamps()
        {
            var utcNow = DateTime.UtcNow;

            var timestampProperties = new Dictionary<Type, string>
         {
             { typeof(Movie), "createdAt" },
             { typeof(Member), "createdAt" },
             { typeof(Rental), "createdAt" },
         };

            foreach (var entityEntry in ChangeTracker.Entries())
            {
                if (entityEntry.State == EntityState.Added || entityEntry.State == EntityState.Modified)
                {
                    if (timestampProperties.TryGetValue(entityEntry.Entity.GetType(), out var timestampProperty))
                    {
                        entityEntry.Property(timestampProperty).CurrentValue = utcNow;

                        if (entityEntry.State == EntityState.Modified)
                        {
                            entityEntry.Property("updatedAt").CurrentValue = utcNow;
                        }
                    }
                }
            }
        }

    }