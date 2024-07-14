using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-0A9SGIVO\\SQLEXPRESS;database=EczaneProje;integrated security=true;");
        }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable(name: "AspNetUsers"); // Tablo adını belirtin
                entity.HasKey(e => e.Id); // Primary key tanımlaması
                                          // Diğer özellikler (örneğin, NormalizeUserName gibi) ve ilişkiler
            });

            modelBuilder.Entity<AppRole>(entity =>
            {
                entity.ToTable(name: "AspNetRoles"); // Tablo adını belirtin
                entity.HasKey(e => e.Id); // Primary key tanımlaması
                                          // Diğer özellikler ve ilişkiler
            });

            modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("AspNetUserLogins"); // Tablo adı
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey }); // Composite primary key
                                                                            // Diğer özellikler
            });

            modelBuilder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable("AspNetUserRoles"); // Tablo adı
                entity.HasKey(e => new { e.UserId, e.RoleId }); // Composite primary key
                                                                // Diğer özellikler
            });

            modelBuilder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("AspNetUserClaims"); // Tablo adı
                entity.HasKey(e => e.Id); // Primary key
                                          // Diğer özellikler
            });

            modelBuilder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("AspNetUserTokens"); // Tablo adı
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name }); // Composite primary key
                                                                               // Diğer özellikler
            });

            modelBuilder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("AspNetRoleClaims"); // Tablo adı
                entity.HasKey(e => e.Id); // Primary key
                                          // Diğer özellikler
            });


            modelBuilder.Entity<Drug>()
                .HasKey(d => d.NDC); // Primary key

            modelBuilder.Entity<Drug>()
                .Property(d => d.NDC)
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            modelBuilder.Entity<Drug>()
                .Property(d => d.supplierFK)
                .HasColumnName("supplierFK") // Veritabanındaki sütun adı
                .HasColumnType("int");

            modelBuilder.Entity<Drug>()
                .HasOne(d => d.Supplier)
                .WithMany()
                .HasForeignKey(d => d.supplierFK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Drug>()
                .Property(d => d.created_at)
                .HasColumnType("datetime2");

            // Diğer ilişkiler ve yapılandırmalar buraya eklenebilir

            // Address - Transaction relationship
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Address)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AddressId);

            // Transaction - TransactionDetail relationship
            modelBuilder.Entity<TransactionDetail>()
                .HasOne(td => td.Transaction)
                .WithMany(t => t.TransactionDetails)
                .HasForeignKey(td => td.transactionFK);

            // AppUser - Address relationship
            modelBuilder.Entity<Address>()
                .HasOne(a => a.AppUser)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserFK);

            // Transaction details fix
            modelBuilder.Entity<TransactionDetail>()
                .HasKey(td => td.id);

            modelBuilder.Entity<TransactionDetail>()
                .Property(td => td.id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TransactionDetail>()
                .Property(td => td.drugFK)
                .IsRequired();

            modelBuilder.Entity<TransactionDetail>()
                .HasOne(td => td.Drug)
                .WithMany() // Burada ilişkili tablodaki koleksiyonu belirtmeniz gerekir, örneğin Drug sınıfında bir ICollection<TransactionDetail> tanımlanmışsa onu ekleyebilirsiniz.
                .HasForeignKey(td => td.drugFK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); // Gerekirse silme davranışını burada ayarlayabilirsiniz

            modelBuilder.Entity<TransactionDetail>()
                .Property(td => td.quantity)
                .IsRequired();

            modelBuilder.Entity<TransactionDetail>()
                .Property(td => td.price)
                .IsRequired();

            modelBuilder.Entity<TransactionDetail>()
                .Property(td => td.created_at)
                .HasColumnType("datetime2")
                .IsRequired();


            //Transaction fix
            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.id);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Transaction>()
                .Property(t => t.userFK)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.AppUser)
                .WithMany() // Burada ilişkili tablodaki koleksiyonu belirtmeniz gerekir, örneğin AppUser sınıfında bir ICollection<Transaction> tanımlanmışsa onu ekleyebilirsiniz.
                .HasForeignKey(t => t.userFK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); // Gerekirse silme davranışını burada ayarlayabilirsiniz

            modelBuilder.Entity<Transaction>()
                .Property(t => t.AddressId)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Address)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AddressId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Gerekirse silme davranışını burada ayarlayabilirsiniz

            modelBuilder.Entity<Transaction>()
                .Property(t => t.totalPrice)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .Property(t => t.created_at)
                .HasColumnType("datetime2")
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .HasMany(t => t.TransactionDetails)
                .WithOne(td => td.Transaction)
                .HasForeignKey(td => td.transactionFK)
                .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Stock>()
                .HasOne(s => s.Drug)
                .WithMany()
                .HasForeignKey(s => s.DrugFK)
                .IsRequired();

                // Gereksiz DrugNDC sütununu veritabanında göstermeyi iptal et
                modelBuilder.Entity<Stock>()
                    .Ignore("DrugNDC");

        }
    }

}
