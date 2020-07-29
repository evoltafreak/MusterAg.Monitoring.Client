using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class musteragContext : DbContext
    {
        public musteragContext()
        {
        }

        public musteragContext(DbContextOptions<musteragContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abrechnung> Abrechnung { get; set; }
        public virtual DbSet<AbrechnungAbrechnungposition> AbrechnungAbrechnungposition { get; set; }
        public virtual DbSet<Abrechnungposition> Abrechnungposition { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Credential> Credential { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerPod> CustomerPod { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<DeviceCredential> DeviceCredential { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationPod> LocationPod { get; set; }
        public virtual DbSet<Logging> Logging { get; set; }
        public virtual DbSet<Networkinterface> Networkinterface { get; set; }
        public virtual DbSet<Networkinterfacemode> Networkinterfacemode { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<Pod> Pod { get; set; }
        public virtual DbSet<PodLogging> PodLogging { get; set; }
        public virtual DbSet<Positiontype> Positiontype { get; set; }
        public virtual DbSet<Severity> Severity { get; set; }
        public virtual DbSet<VLogentries> VLogentries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["connectionStringSqlServer"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abrechnung>(entity =>
            {
                entity.HasKey(e => e.IdAbrechnung)
                    .HasName("PK_abrechnung_idAbrechnung");

                entity.ToTable("abrechnung", "musterag");

                entity.HasIndex(e => e.FidPod)
                    .HasName("fk_Abrechnung_Pod");

                entity.Property(e => e.IdAbrechnung).HasColumnName("idAbrechnung");

                entity.Property(e => e.Bill)
                    .HasColumnName("bill")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.FidPod).HasColumnName("fidPod");

                entity.Property(e => e.IsPaid).HasColumnName("isPaid");

                entity.HasOne(d => d.FidPodNavigation)
                    .WithMany(p => p.Abrechnung)
                    .HasForeignKey(d => d.FidPod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abrechnung$fk_Abrechnung_Pod");
            });

            modelBuilder.Entity<AbrechnungAbrechnungposition>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("abrechnung_abrechnungposition", "musterag");

                entity.HasIndex(e => e.FidAbrechnung)
                    .HasName("fk_Abrechnung_AbrechnungPosition");

                entity.HasIndex(e => e.FidAbrechnungPosition)
                    .HasName("fk_AbrechnungPosition_AbrechnungPosition");

                entity.Property(e => e.FidAbrechnung).HasColumnName("fidAbrechnung");

                entity.Property(e => e.FidAbrechnungPosition).HasColumnName("fidAbrechnungPosition");

                entity.HasOne(d => d.FidAbrechnungNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FidAbrechnung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abrechnung_abrechnungposition$fk_Abrechnung_AbrechnungPosition");

                entity.HasOne(d => d.FidAbrechnungPositionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FidAbrechnungPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abrechnung_abrechnungposition$fk_AbrechnungPosition_AbrechnungPosition");
            });

            modelBuilder.Entity<Abrechnungposition>(entity =>
            {
                entity.HasKey(e => e.IdAbrechnungPosition)
                    .HasName("PK_abrechnungposition_idAbrechnungPosition");

                entity.ToTable("abrechnungposition", "musterag");

                entity.HasIndex(e => e.FidPositionType)
                    .HasName("fk_AbrechnungPosition_PositionType");

                entity.Property(e => e.IdAbrechnungPosition).HasColumnName("idAbrechnungPosition");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.FidPositionType).HasColumnName("fidPositionType");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.HasOne(d => d.FidPositionTypeNavigation)
                    .WithMany(p => p.Abrechnungposition)
                    .HasForeignKey(d => d.FidPositionType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abrechnungposition$fk_AbrechnungPosition_PositionType");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.IdCategories)
                    .HasName("PK_categories_idCategories");

                entity.ToTable("categories", "musterag");

                entity.Property(e => e.IdCategories).HasColumnName("idCategories");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.HasKey(e => e.IdCredential)
                    .HasName("PK_credential_idCredential");

                entity.ToTable("credential", "musterag");

                entity.Property(e => e.IdCredential).HasColumnName("idCredential");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(45);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("PK_customer_idCustomer");

                entity.ToTable("customer", "musterag");

                entity.HasIndex(e => e.FidLocation)
                    .HasName("fk_Customer_Location");

                entity.Property(e => e.IdCustomer).HasColumnName("idCustomer");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(200);

                entity.Property(e => e.FidLocation).HasColumnName("fidLocation");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(200);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(200);

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasColumnName("tel")
                    .HasMaxLength(20);

                entity.HasOne(d => d.FidLocationNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.FidLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer$fk_Customer_Location");
            });

            modelBuilder.Entity<CustomerPod>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("customer_pod", "musterag");

                entity.HasIndex(e => e.FidCustomer)
                    .HasName("fk_CustomerPod_Customer");

                entity.HasIndex(e => e.FidPod)
                    .HasName("fk_CustomerPod_Pod");

                entity.Property(e => e.FidCustomer).HasColumnName("fidCustomer");

                entity.Property(e => e.FidPod).HasColumnName("fidPod");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.HasOne(d => d.FidCustomerNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FidCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_pod$fk_CustomerPod_Customer");

                entity.HasOne(d => d.FidPodNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FidPod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_pod$fk_CustomerPod_Pod");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.IdDevice)
                    .HasName("PK_device_idDevice");

                entity.ToTable("device", "musterag");

                entity.HasIndex(e => e.FidCategories)
                    .HasName("fk_Device_Categories");

                entity.HasIndex(e => e.FidLocation)
                    .HasName("fk_Device_Location");

                entity.HasIndex(e => e.FidPod)
                    .HasName("fk_Device_Pod");

                entity.Property(e => e.IdDevice).HasColumnName("idDevice");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.FidCategories).HasColumnName("fidCategories");

                entity.Property(e => e.FidLocation).HasColumnName("fidLocation");

                entity.Property(e => e.FidPod).HasColumnName("fidPod");

                entity.Property(e => e.Hostname)
                    .IsRequired()
                    .HasColumnName("hostname")
                    .HasMaxLength(200);

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasColumnName("ipAddress")
                    .HasMaxLength(45);

                entity.Property(e => e.IsPhysical).HasColumnName("isPhysical");

                entity.Property(e => e.Maxcapacity).HasColumnName("maxcapacity");

                entity.HasOne(d => d.FidCategoriesNavigation)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.FidCategories)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("device$fk_Device_Categories");

                entity.HasOne(d => d.FidLocationNavigation)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.FidLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("device$fk_Device_Location");

                entity.HasOne(d => d.FidPodNavigation)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.FidPod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("device$fk_Device_Pod");
            });

            modelBuilder.Entity<DeviceCredential>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("device_credential", "musterag");

                entity.HasIndex(e => e.FidCredential)
                    .HasName("fk_DeviceCredential_Credential");

                entity.HasIndex(e => e.FidDevice)
                    .HasName("fk_DeviceCredential_Device");

                entity.Property(e => e.FidCredential).HasColumnName("fidCredential");

                entity.Property(e => e.FidDevice).HasColumnName("fidDevice");

                entity.HasOne(d => d.FidCredentialNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FidCredential)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("device_credential$fk_DeviceCredential_Credential");

                entity.HasOne(d => d.FidDeviceNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FidDevice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("device_credential$fk_DeviceCredential_Device");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.IdLocation)
                    .HasName("PK_location_idLocation");

                entity.ToTable("location", "musterag");

                entity.HasIndex(e => e.FidPlace)
                    .HasName("fk_Location_Place");

                entity.Property(e => e.IdLocation).HasColumnName("idLocation");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(200);

                entity.Property(e => e.AddressNr)
                    .HasColumnName("addressNr")
                    .HasMaxLength(10);

                entity.Property(e => e.FidPlace).HasColumnName("fidPlace");

                entity.HasOne(d => d.FidPlaceNavigation)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.FidPlace)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("location$fk_Location_Place");
            });

            modelBuilder.Entity<LocationPod>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("location_pod", "musterag");

                entity.HasIndex(e => e.FidLocation)
                    .HasName("fk_LocationPod_Location");

                entity.HasIndex(e => e.FidPod)
                    .HasName("fk_LocationPod_Pod");

                entity.Property(e => e.FidLocation).HasColumnName("fidLocation");

                entity.Property(e => e.FidPod).HasColumnName("fidPod");

                entity.HasOne(d => d.FidLocationNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FidLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("location_pod$fk_LocationPod_Location");

                entity.HasOne(d => d.FidPodNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FidPod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("location_pod$fk_LocationPod_Pod");
            });

            modelBuilder.Entity<Logging>(entity =>
            {
                entity.HasKey(e => e.IdLogging)
                    .HasName("PK_logging_idLogging");

                entity.ToTable("logging", "musterag");

                entity.HasIndex(e => e.FidSeverity)
                    .HasName("fk_Logging_Severity");

                entity.Property(e => e.IdLogging).HasColumnName("idLogging");

                entity.Property(e => e.FidSeverity).HasColumnName("fidSeverity");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.FidSeverityNavigation)
                    .WithMany(p => p.Logging)
                    .HasForeignKey(d => d.FidSeverity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("logging$fk_Logging_Severity");
            });

            modelBuilder.Entity<Networkinterface>(entity =>
            {
                entity.HasKey(e => e.IdNetworkInterface)
                    .HasName("PK_networkinterface_idNetworkInterface");

                entity.ToTable("networkinterface", "musterag");

                entity.HasIndex(e => e.FidDevice)
                    .HasName("fk_NetworkInterface_Device");

                entity.HasIndex(e => e.FidNetworkInterfaceMode)
                    .HasName("fk_NetworkInterface_NetworkInterfaceMode");

                entity.Property(e => e.IdNetworkInterface).HasColumnName("idNetworkInterface");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.FidDevice).HasColumnName("fidDevice");

                entity.Property(e => e.FidNetworkInterfaceMode).HasColumnName("fidNetworkInterfaceMode");

                entity.Property(e => e.IsPhysical).HasColumnName("isPhysical");

                entity.HasOne(d => d.FidDeviceNavigation)
                    .WithMany(p => p.Networkinterface)
                    .HasForeignKey(d => d.FidDevice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("networkinterface$fk_NetworkInterface_Device");

                entity.HasOne(d => d.FidNetworkInterfaceModeNavigation)
                    .WithMany(p => p.Networkinterface)
                    .HasForeignKey(d => d.FidNetworkInterfaceMode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("networkinterface$fk_NetworkInterface_NetworkInterfaceMode");
            });

            modelBuilder.Entity<Networkinterfacemode>(entity =>
            {
                entity.HasKey(e => e.IdNetworkinterfaceMode)
                    .HasName("PK_networkinterfacemode_idNetworkinterfaceMode");

                entity.ToTable("networkinterfacemode", "musterag");

                entity.Property(e => e.IdNetworkinterfaceMode).HasColumnName("idNetworkinterfaceMode");

                entity.Property(e => e.NetworkinterfaceMode1)
                    .IsRequired()
                    .HasColumnName("networkinterfaceMode")
                    .HasMaxLength(200);

                entity.Property(e => e.Speed)
                    .IsRequired()
                    .HasColumnName("speed")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.HasKey(e => e.IdPlace)
                    .HasName("PK_place_idPlace");

                entity.ToTable("place", "musterag");

                entity.Property(e => e.IdPlace).HasColumnName("idPlace");

                entity.Property(e => e.Canton)
                    .IsRequired()
                    .HasColumnName("canton")
                    .HasMaxLength(200);

                entity.Property(e => e.CantonAbb)
                    .IsRequired()
                    .HasColumnName("cantonAbb")
                    .HasMaxLength(2);

                entity.Property(e => e.Place1)
                    .IsRequired()
                    .HasColumnName("place")
                    .HasMaxLength(200);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasColumnName("zipCode")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<Pod>(entity =>
            {
                entity.HasKey(e => e.IdPod)
                    .HasName("PK_pod_idPod");

                entity.ToTable("pod", "musterag");

                entity.HasIndex(e => e.FidCustomer)
                    .HasName("fk_Pod_Customer");

                entity.Property(e => e.IdPod).HasColumnName("idPod");

                entity.Property(e => e.BillLimit)
                    .HasColumnName("billLimit")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Credit)
                    .HasColumnName("credit")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.FidCustomer).HasColumnName("fidCustomer");

                entity.HasOne(d => d.FidCustomerNavigation)
                    .WithMany(p => p.Pod)
                    .HasForeignKey(d => d.FidCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pod$fk_Pod_Customer");
            });

            modelBuilder.Entity<PodLogging>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pod_logging", "musterag");

                entity.HasIndex(e => e.FidLogging)
                    .HasName("fk_PodLogging_Logging");

                entity.HasIndex(e => e.FidPod)
                    .HasName("fk_PodLogging_Pod");

                entity.Property(e => e.FidLogging).HasColumnName("fidLogging");

                entity.Property(e => e.FidPod).HasColumnName("fidPod");

                entity.HasOne(d => d.FidLoggingNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FidLogging)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pod_logging$fk_PodLogging_Logging");

                entity.HasOne(d => d.FidPodNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FidPod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pod_logging$fk_PodLogging_Pod");
            });

            modelBuilder.Entity<Positiontype>(entity =>
            {
                entity.HasKey(e => e.IdPositionType)
                    .HasName("PK_positiontype_idPositionType");

                entity.ToTable("positiontype", "musterag");

                entity.Property(e => e.IdPositionType).HasColumnName("idPositionType");

                entity.Property(e => e.PositionType1)
                    .IsRequired()
                    .HasColumnName("positionType")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Severity>(entity =>
            {
                entity.HasKey(e => e.IdSeverity)
                    .HasName("PK_severity_idSeverity");

                entity.ToTable("severity", "musterag");

                entity.Property(e => e.IdSeverity).HasColumnName("idSeverity");

                entity.Property(e => e.Severity1)
                    .IsRequired()
                    .HasColumnName("severity")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<VLogentries>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_logentries", "musterag");

                entity.Property(e => e.Hostname)
                    .IsRequired()
                    .HasColumnName("hostname")
                    .HasMaxLength(200);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(200);

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .IsUnicode(false);

                entity.Property(e => e.Pod)
                    .HasColumnName("pod")
                    .HasMaxLength(200);

                entity.Property(e => e.Severity)
                    .IsRequired()
                    .HasColumnName("severity")
                    .HasMaxLength(45);

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
