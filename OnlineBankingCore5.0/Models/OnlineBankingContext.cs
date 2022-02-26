using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OnlineBankingCore5._0.Models
{
    public partial class OnlineBankingContext : IdentityDbContext<ApplicationUser>
    {
        public OnlineBankingContext()
        {
        }

        public OnlineBankingContext(DbContextOptions<OnlineBankingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
       
        
  
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Complaint> Complaints { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<ViewCustomerTop> ViewCustomerTops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=OnlineBanking;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            base.OnModelCreating(modelBuilder);
          
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            
            //modelBuilder.Entity<AspNetUser>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            //    entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedUserName] IS NOT NULL)");

            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            //    entity.Property(e => e.UserName).HasMaxLength(256);
            //});

           

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Contact)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Complaint>(entity =>
            {
                entity.ToTable("Complaint");

                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Complaints)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Complaint_Customer");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.AspNetUserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nic)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.Occupation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Accounts");

                entity.HasOne(d => d.AspNetUser)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AspNetUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_AspNetUsers");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_city");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.AspNetUserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("salary");

                entity.HasOne(d => d.AspNetUser)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.AspNetUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_AspNetUser");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_city");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Department");

                entity.HasOne(d => d.Qualification)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.QualificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Qualification");
            });

            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.ToTable("Qualification");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewCustomerTop>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewCustomerTop");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
