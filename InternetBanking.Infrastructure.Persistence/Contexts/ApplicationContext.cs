using Microsoft.EntityFrameworkCore;
using InternetBanking.Core.Domain.Common;
using InternetBanking.Core.Domain.Entities;
using InternetBanking.Infrastructure.Identity.Entities;


namespace InternetBanking.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }

        public DbSet<Loan> Loans { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API

            #region tables

            modelBuilder.Entity<Account>()
                .ToTable("Accounts");

            modelBuilder.Entity<Beneficiary>()
                .ToTable("Beneficiaries");

            modelBuilder.Entity<Loan>()
                .ToTable("Loans");

            modelBuilder.Entity<Transaction>()
                .ToTable("Transactions");


            #endregion

            #region "primary keys"
            modelBuilder.Entity<Loan>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Beneficiary>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Account>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.Id);

            #endregion

            #region "Relationships"

            modelBuilder.Entity<Account>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(c => c.UserId);



            modelBuilder.Entity<Beneficiary>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(b => b.UserId);


            // Relación uno a muchos entre Cuenta y Transaccion (Cuenta Origen)
            modelBuilder.Entity<Account>()
                .HasMany(c => c.OriginTransactions)
                .WithOne(t => t.OriginAccount)
                .HasForeignKey(t => t.OriginAccountId);

            // Relación uno a muchos entre Cuenta y Transaccion (Cuenta Destino)
            modelBuilder.Entity<Account>()
                .HasMany(c => c.DetinationTransactions)
                .WithOne(t => t.DestinationAccount)
                .HasForeignKey(t => t.DestinationAccountId);

            // Relación uno a muchos entre Cuenta y Prestamo
            modelBuilder.Entity<Account>()
                .HasMany(c => c.Loans)
                .WithOne(p => p.Account)
                .HasForeignKey(p => p.AccountId);

            #endregion

            #region "Property configurations"

            #region accounts

            modelBuilder.Entity<Account>().
                Property(a => a.Amount)
                .IsRequired();

            modelBuilder.Entity<Account>().
                Property(a => a.Type)
                .IsRequired();

            modelBuilder.Entity<Account>().
                Property(a => a.AccountNumber)
                .IsRequired();


            #endregion

            #region beneficiary
            modelBuilder.Entity<Beneficiary>().
              Property(b => b.BeneficiaryName)
              .IsRequired();

            modelBuilder.Entity<Beneficiary>().
              Property(b => b.AccountNumber)
              .IsRequired();

            #endregion

            #region Loan
            modelBuilder.Entity<Loan>().
              Property(b => b.Amount)
              .IsRequired();

            #endregion

            #region Transaction
            modelBuilder.Entity<Transaction>().
              Property(b => b.Type)
              .IsRequired();

            modelBuilder.Entity<Transaction>().
              Property(b => b.Amount)
              .IsRequired();

            #endregion


            #endregion

        }

    }
}
