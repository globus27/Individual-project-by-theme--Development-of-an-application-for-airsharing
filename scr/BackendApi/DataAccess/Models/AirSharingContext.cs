using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class AirSharingContext : DbContext
    {
        public AirSharingContext()
        {
        }

        public AirSharingContext(DbContextOptions<AirSharingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Aircraft> Aircraft { get; set; } = null!;
        public virtual DbSet<AircraftCategory> AircraftCategories { get; set; } = null!;
        public virtual DbSet<AircraftCoordinate> AircraftCoordinates { get; set; } = null!;
        public virtual DbSet<AircraftInfo> AircraftInfos { get; set; } = null!;
        public virtual DbSet<AircraftInsurance> AircraftInsurances { get; set; } = null!;
        public virtual DbSet<AircraftRegistrCertificate> AircraftRegistrCertificates { get; set; } = null!;
        public virtual DbSet<Airfield> Airfields { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeServiceInfo> EmployeeServiceInfos { get; set; } = null!;
        public virtual DbSet<FlightLicense> FlightLicenses { get; set; } = null!;
        public virtual DbSet<LeasingCompany> LeasingCompanies { get; set; } = null!;
        public virtual DbSet<LeasingInfo> LeasingInfos { get; set; } = null!;
        public virtual DbSet<MoneyTransaction> MoneyTransactions { get; set; } = null!;
        public virtual DbSet<Passport> Passports { get; set; } = null!;
        public virtual DbSet<PaymentInfo> PaymentInfos { get; set; } = null!;
        public virtual DbSet<Rental> Rentals { get; set; } = null!;
        public virtual DbSet<ServiceInfo> ServiceInfos { get; set; } = null!;
        public virtual DbSet<ServiceInfoAirfield> ServiceInfoAirfields { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        //"Server= GLEB27 ;Database= AirSharing ;User Id= sa ;Password= 123456 ;"
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => new { e.Idadmin, e.IdUser })
                    .HasName("ID_Admin");

                entity.ToTable("Admin");

                entity.Property(e => e.Idadmin).HasColumnName("IDAdmin");

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R3_User_Admin");
            });

            modelBuilder.Entity<Aircraft>(entity =>
            {
                entity.HasKey(e => e.IdAircraft)
                    .HasName("ID_Aircraft");

                entity.HasIndex(e => e.IdAircraftCategory, "IX_R9");

                entity.Property(e => e.IdAircraft).HasColumnName("ID_Aircraft");

                entity.Property(e => e.IdAircraftCategory).HasColumnName("ID_AircraftCategory");

                entity.Property(e => e.ManufactureCountry)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.ModelName)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAircraftCategoryNavigation)
                    .WithMany(p => p.Aircraft)
                    .HasForeignKey(d => d.IdAircraftCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R9_AircraftCategory_Aircraft");
            });

            modelBuilder.Entity<AircraftCategory>(entity =>
            {
                entity.HasKey(e => e.IdAircraftCategory)
                    .HasName("ID_AircraftCategory");

                entity.ToTable("AircraftCategory");

                entity.Property(e => e.IdAircraftCategory).HasColumnName("ID_AircraftCategory");

                entity.Property(e => e.AircraftType)
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AircraftCoordinate>(entity =>
            {
                entity.HasKey(e => e.IdAircraftCoordinates)
                    .HasName("ID_AircraftCoordinates");

                entity.HasIndex(e => e.IdAircraft, "IX_R11");

                entity.Property(e => e.IdAircraftCoordinates).HasColumnName("ID_AircraftCoordinates");

                entity.Property(e => e.Altitude).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.IdAircraft).HasColumnName("ID_Aircraft");

                entity.Property(e => e.Latitude).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.PressureOnBoard).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Speed).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.IdAircraftNavigation)
                    .WithMany(p => p.AircraftCoordinates)
                    .HasForeignKey(d => d.IdAircraft)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R11_Aircraft_AircraftCoordinates");
            });

            modelBuilder.Entity<AircraftInfo>(entity =>
            {
                entity.HasKey(e => e.IdAircraftInfo)
                    .HasName("ID_AircraftInfo");

                entity.ToTable("AircraftInfo");

                entity.HasIndex(e => e.IdAircraft, "IX_R10");

                entity.Property(e => e.IdAircraftInfo).HasColumnName("ID_AircraftInfo");

                entity.Property(e => e.EngineType)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.IdAircraft).HasColumnName("ID_Aircraft");

                entity.Property(e => e.MaxWeight).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdAircraftNavigation)
                    .WithMany(p => p.AircraftInfos)
                    .HasForeignKey(d => d.IdAircraft)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R10_Aircraft_AircraftInfo");
            });

            modelBuilder.Entity<AircraftInsurance>(entity =>
            {
                entity.HasKey(e => e.IdAircraftInsurance)
                    .HasName("ID_AircraftInsurance");

                entity.ToTable("AircraftInsurance");

                entity.HasIndex(e => e.IdAircraft, "IX_R16");

                entity.HasIndex(e => e.IdLeasingCompany, "IX_R24");

                entity.Property(e => e.IdAircraftInsurance).HasColumnName("ID_AircraftInsurance");

                entity.Property(e => e.CoverageAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.DateofExpiry).HasColumnType("date");

                entity.Property(e => e.DateofIssue).HasColumnType("date");

                entity.Property(e => e.IdAircraft).HasColumnName("ID_Aircraft");

                entity.Property(e => e.IdLeasingCompany).HasColumnName("ID_LeasingCompany");

                entity.Property(e => e.InsuranceCompany)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.InsuranceNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdAircraftNavigation)
                    .WithMany(p => p.AircraftInsurances)
                    .HasForeignKey(d => d.IdAircraft)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R16_Aircraft_AircraftInsurance");

                entity.HasOne(d => d.IdLeasingCompanyNavigation)
                    .WithMany(p => p.AircraftInsurances)
                    .HasForeignKey(d => d.IdLeasingCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R24_LeasingCompany_AircraftInsurance");
            });

            modelBuilder.Entity<AircraftRegistrCertificate>(entity =>
            {
                entity.HasKey(e => e.IdAircraftRegistrCertificate)
                    .HasName("ID_AircraftRegistrCertificates");

                entity.ToTable("AircraftRegistrCertificate");

                entity.HasIndex(e => e.IdAircaft, "IX_R13");

                entity.HasIndex(e => e.Attribute1, "IX_R20");

                entity.Property(e => e.IdAircraftRegistrCertificate).HasColumnName("ID_AircraftRegistrCertificate");

                entity.Property(e => e.CertifacteNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DateofExpiry).HasColumnType("date");

                entity.Property(e => e.DateofIssue).HasColumnType("date");

                entity.Property(e => e.IdAircaft).HasColumnName("ID_Aircaft");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Attribute1Navigation)
                    .WithMany(p => p.AircraftRegistrCertificates)
                    .HasForeignKey(d => d.Attribute1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R20_LeasingCompany_AircraftRegistrCertificate");

                entity.HasOne(d => d.IdAircaftNavigation)
                    .WithMany(p => p.AircraftRegistrCertificates)
                    .HasForeignKey(d => d.IdAircaft)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R13_Aircraft_AircraftRegistrCertificate");
            });

            modelBuilder.Entity<Airfield>(entity =>
            {
                entity.HasKey(e => e.IdAirfield)
                    .HasName("ID_Airfield");

                entity.ToTable("Airfield");

                entity.Property(e => e.IdAirfield).HasColumnName("ID_Airfield");

                entity.Property(e => e.City)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Name)
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("ID_Employee");

                entity.ToTable("Employee");

                entity.HasIndex(e => e.IdAirfield, "IX_R22");

                entity.HasIndex(e => e.Number, "IX_Relationship3");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.FullName)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.IdAirfield).HasColumnName("ID_Airfield");

                entity.Property(e => e.MailAdress)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.PassportNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PostName)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.SalaryRate).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdAirfieldNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdAirfield)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R22_Airfield_Employee");

                entity.HasOne(d => d.NumberNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Number)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R18_Passport_Employee");
            });

            modelBuilder.Entity<EmployeeServiceInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Employee_ServiceInfo");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.IdServiceInfo).HasColumnName("ID_ServiceInfo");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R23_Employee_Employee_ServiceInfo");

                entity.HasOne(d => d.IdServiceInfoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdServiceInfo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R23_ServiceInfo_Employee_ServiceInfo");
            });

            modelBuilder.Entity<FlightLicense>(entity =>
            {
                entity.HasKey(e => e.IdFlightLicense)
                    .HasName("ID_FlightLicense");

                entity.ToTable("FlightLicense");

                entity.HasIndex(e => e.IdUser, "IX_R1_User_FlightLicense");

                entity.Property(e => e.IdFlightLicense).HasColumnName("ID_FlightLicense");

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.Property(e => e.CityofResidence)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.CountryofResidence)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.DateofExpiry).HasColumnType("datetime");

                entity.Property(e => e.DateofIssue).HasColumnType("date");

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.LicenseCategory)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.NumberFlightLicense)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.FlightLicenses)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R1_User_FlightLicense");
            });

            modelBuilder.Entity<LeasingCompany>(entity =>
            {
                entity.HasKey(e => e.IdLeasingCompany)
                    .HasName("ID_LeasingCompany");

                entity.ToTable("LeasingCompany");

                entity.Property(e => e.IdLeasingCompany).HasColumnName("ID_LeasingCompany");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("ContactEMail");

                entity.Property(e => e.Ogrn)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("OGRN")
                    .IsFixedLength();
            });

            modelBuilder.Entity<LeasingInfo>(entity =>
            {
                entity.HasKey(e => e.IdLeasingInfo)
                    .HasName("ID_LeasingInfo");

                entity.ToTable("LeasingInfo");

                entity.HasIndex(e => e.IdLeasingCompany, "IX_R25");

                entity.HasIndex(e => e.IdAircraft, "IX_Relationship2");

                entity.Property(e => e.IdLeasingInfo).HasColumnName("ID_LeasingInfo");

                entity.Property(e => e.IdAircraft).HasColumnName("ID_Aircraft");

                entity.Property(e => e.IdLeasingCompany).HasColumnName("ID_LeasingCompany");

                entity.Property(e => e.LeaseEndDate).HasColumnType("date");

                entity.Property(e => e.LeaseStartDate).HasColumnType("date");

                entity.Property(e => e.MonthlyPayment).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdAircraftNavigation)
                    .WithMany(p => p.LeasingInfos)
                    .HasForeignKey(d => d.IdAircraft)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R17_Aircraft_LeasingInfo");

                entity.HasOne(d => d.IdLeasingCompanyNavigation)
                    .WithMany(p => p.LeasingInfos)
                    .HasForeignKey(d => d.IdLeasingCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R25_LeasingCompany_LeasingInfo");
            });

            modelBuilder.Entity<MoneyTransaction>(entity =>
            {
                entity.HasKey(e => e.IdMoneyTransaction)
                    .HasName("ID_MoneyTransaction");

                entity.ToTable("MoneyTransaction");

                entity.HasIndex(e => e.IdRental, "IX_R19");

                entity.HasIndex(e => e.IdUserSender, "IX_R5");

                entity.Property(e => e.IdMoneyTransaction).HasColumnName("ID_MoneyTransaction");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.IdRental).HasColumnName("ID_Rental");

                entity.Property(e => e.IdUserSender).HasColumnName("ID_User_Sender");

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdRentalNavigation)
                    .WithMany(p => p.MoneyTransactions)
                    .HasForeignKey(d => d.IdRental)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R19_Rental_MoneyTransaction");

                entity.HasOne(d => d.IdUserSenderNavigation)
                    .WithMany(p => p.MoneyTransactions)
                    .HasForeignKey(d => d.IdUserSender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R5_User_MoneyTransaction");
            });

            modelBuilder.Entity<Passport>(entity =>
            {
                entity.HasKey(e => e.IdPassport)
                    .HasName("ID_Passport");

                entity.ToTable("Passport");

                entity.Property(e => e.IdPassport).HasColumnName("ID_Passport");

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.Property(e => e.CodeDepartament)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DateofIssue).HasColumnType("date");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PlaceBorn)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.PlaceIssue)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentInfo>(entity =>
            {
                entity.HasKey(e => e.IdPaymetnInfo)
                    .HasName("ID_PaymentInfo");

                entity.ToTable("PaymentInfo");

                entity.HasIndex(e => e.IdUser, "IX_R6");

                entity.Property(e => e.IdPaymetnInfo).HasColumnName("ID_PaymetnInfo");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cvc)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CVC")
                    .IsFixedLength();

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.PaymentInfos)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R6_User_PaymentInfo");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasKey(e => e.IdRental)
                    .HasName("ID_Rental");

                entity.ToTable("Rental");

                entity.HasIndex(e => e.IdAircraft, "IX_R12");

                entity.HasIndex(e => e.IdUser, "IX_R4");

                entity.HasIndex(e => e.IdFlightLicense, "IX_R7");

                entity.Property(e => e.IdRental).HasColumnName("ID_Rental");

                entity.Property(e => e.IdAircraft).HasColumnName("ID_Aircraft");

                entity.Property(e => e.IdFlightLicense).HasColumnName("ID_FlightLicense");

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.RentalStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdAircraftNavigation)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.IdAircraft)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R12_Aircraft_Rental");

                entity.HasOne(d => d.IdFlightLicenseNavigation)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.IdFlightLicense)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R7_FlightLicense_Rental");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R4_User_Rental");
            });

            modelBuilder.Entity<ServiceInfo>(entity =>
            {
                entity.HasKey(e => e.IdServiceInfo)
                    .HasName("ID_ServiceInfo");

                entity.ToTable("ServiceInfo");

                entity.HasIndex(e => e.IdAircraft, "IX_R15");

                entity.Property(e => e.IdServiceInfo).HasColumnName("ID_ServiceInfo");

                entity.Property(e => e.Decription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdAircraft).HasColumnName("ID_Aircraft");

                entity.Property(e => e.TimeOfViolation).HasColumnType("datetime");

                entity.HasOne(d => d.IdAircraftNavigation)
                    .WithMany(p => p.ServiceInfos)
                    .HasForeignKey(d => d.IdAircraft)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R15_Aircraft_ServiceInfo");
            });

            modelBuilder.Entity<ServiceInfoAirfield>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ServiceInfo_Airfield");

                entity.Property(e => e.IdAirfield).HasColumnName("ID_Airfield");

                entity.Property(e => e.IdServiceInfo).HasColumnName("ID_ServiceInfo");

                entity.HasOne(d => d.IdAirfieldNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAirfield)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R21_Airfield");

                entity.HasOne(d => d.IdServiceInfoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdServiceInfo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R21_ServiceInfo");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("ID_User");

                entity.ToTable("User");

                entity.HasIndex(e => e.IdPassport, "IX_Relationship4");

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.Email)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.IdPassport).HasColumnName("ID_Passport");

                entity.Property(e => e.Login)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPassportNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdPassport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R2_Passport_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
