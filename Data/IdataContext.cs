using Idata.Data.Entities;
using Idata.Data.Entities.Iflight;
using Idata.Data.Entities.Iprofile;
using Idata.Data.Entities.Ireport;
using Idata.Data.Entities.Isite;
using Idata.Data.Entities.Page;
using Idata.Data.Entities.Ramp;
using Idata.Data.Entities.Setup;
using Idata.Entities.Core;
using Idata.Entities.Icomment;
using Idata.Entities.Idhl;
using Idata.Entities.Isite;
using Idata.Entities.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Idata.Data
{
    public partial class IdataContext : DbContext
    {
         
        private static string? _ConectionString = null;

        public IdataContext() : base()
        {
        }
        public IdataContext(DbContextOptions<IdataContext> options) : base(options)
        {
        }

        public sealed override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is EntityBase && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Deleted:
                        ((EntityBase)entityEntry.Entity).deleted_at = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        ((EntityBase)entityEntry.Entity).updated_at = DateTime.UtcNow;
                        entityEntry.Property("created_at").IsModified = false;
                        entityEntry.Property("created_by").IsModified = false;
                        break;
                    case EntityState.Added:
                        ((EntityBase)entityEntry.Entity).created_at = DateTime.UtcNow;

                        break;
                }

            }

            return base.SaveChangesAsync();
        }


        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Station> Stations { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<Page> Page { get; set; } = null!;
        public virtual DbSet<PageTranslations> PageTranslations { get; set; } = null!;
        public virtual DbSet<Setting> Settings { get; set; } = null!;
        public virtual DbSet<SettingTranslation> SettingTranslations { get; set; } = null!;
        public virtual DbSet<Module> Modules { get; set; } = null!;
        public virtual DbSet<ModuleTranslation> ModuleTranslations { get; set; } = null!;
        public virtual DbSet<Revision> Revisions { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<AircraftType> AircraftTypes { get; set; } = null!;
        public virtual DbSet<Airline> Airlines { get; set; } = null!;
        public virtual DbSet<Airport> Airports { get; set; } = null!;
        public virtual DbSet<Flight> Flights { get; set; } = null!;
        public virtual DbSet<FlightScheduleLeg> FlightScheduleLegs { get; set; } = null!;
        public virtual DbSet<FlightSchedule> FlightSchedules { get; set; } = null!;
        public virtual DbSet<Contract> Contracts { get; set; } = null!;
        public virtual DbSet<CostCenter> CostCenters { get; set; } = null!;
        public virtual DbSet<BusinessUnit> BusinessUnits { get; set; } = null!;
        public virtual DbSet<BusinessUnit> BusinessUnitTypes { get; set; } = null!;
        public virtual DbSet<ContractLine> ContractLines { get; set; } = null!;
        public virtual DbSet<ContractStatus> ContractStatuses { get; set; } = null!;
        public virtual DbSet<ContractType> ContractTypes { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerStatus> CustomerStatuses { get; set; } = null!;
        public virtual DbSet<CustomerType> CustomerTypes { get; set; } = null!;

        //Ramp Module
        public virtual DbSet<WorkOrderDelay> workOrderDelays { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<WorkOrder> WorkOrders { get; set; } = null!;
        public virtual DbSet<WorkOrderItem> WorkOrderItems { get; set; } = null!;
        public virtual DbSet<WorkOrderItemAttributes> WorkOrderItemAttributes { get; set; } = null!;
        public virtual DbSet<WorkOrderDateOption> WorkOrderDateOptions { get; set; } = null!;
        public virtual DbSet<WorkOrderLoadServiceType> WorkOrderLoadServiceTypes { get; set; } = null!;
        public virtual DbSet<WorkOrderStatus> WorkOrderStatuses { get; set; } = null!;
        public virtual DbSet<OperationType> OperationTypes { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Attributes> Attributes { get; set; } = null!;
        public virtual DbSet<Values> Values { get; set; } = null!;
        public virtual DbSet<MeasureUnits> MeasureUnits { get; set; } = null!;
        public virtual DbSet<Gate> Gates { get; set; } = null!;
        public virtual DbSet<WorkdayTransaction> WorkdayTransactions { get; set; } = null!;
        public virtual DbSet<ContractRule> ContractRules { get; set; } = null!;
        public virtual DbSet<FlightStatus> FlightStatuses { get; set; } = null!;

        // DHL MODULE
        public virtual DbSet<Staff> Staffs { get; set; } = null!;
        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<ScoreCard> ScoreCards { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<ScheduleStatus> ScheduleStatuses { get; set; } = null!;
        //Ireport Module
        public virtual DbSet<Folder> Folders { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<ReportType> ReportTypes { get; set; } = null!;

        public virtual DbSet<Comment> Comments { get; set; } = null!;

        #region Test Entities
        public virtual DbSet<TestEntity> Tests { get;set; } = null!;
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString, options => options.CommandTimeout(600));
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Departments");

                entity.Property(e => e.options).HasColumnType("text");

                entity.Property(e => e.title)
                    .HasMaxLength(191)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<WorkOrder>()
             .Property(b => b.comments)
             .HasDefaultValue(0);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.email).IsUnique();
            });


            modelBuilder.Entity<Idata.Data.Entities.Page.Page>(entity =>
            {
                entity.ToTable("Page");
                entity.Property(e => e.options).HasColumnType("text");

            });
            modelBuilder.Entity<Module>()
                .Property(m => m.priority)
                .HasDefaultValue(1);
            modelBuilder.Entity<FlightSchedule>()
             .HasMany(fs => fs.flightScheduleLegs)
             .WithOne(c => c.flightSchedule)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Logs");
            });
            modelBuilder.Entity<Gate>(entity =>
            {
                entity.ToTable("Gates");
            });
            modelBuilder.Entity<FlightStatus>(entity =>
            {
                entity.ToTable("FlightStatuses");
            });
            //modelBuilder.Entity<foo>().Metadata.SetIsTableExcludedFromMigrations(true);

        }

        /// <summary>
        /// Configures the connection string for this context.
        /// </summary>
        /// <param name="ConectionString">The connection string to use.</param>
        public static void ConfigureContext(string ConectionString)
        {
            // Store the connection string for later use.
            _ConectionString = ConectionString;
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
