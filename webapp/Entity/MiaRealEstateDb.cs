using System.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartAdminMvc.Identity;

namespace SmartAdminMvc.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MiaRealEstateDb : IdentityDbContext<ApplicationUser>
    {
        public MiaRealEstateDb()
            : base("name=MiaRealEstateDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MiaRealEstateDb, Migrations.Configuration>("MiaRealEstateDb"));
        }

        public virtual DbSet<Portfolio_Address> Portfolio_Address { get; set; }
        public virtual DbSet<Portfolio_Detail> Portfolio_Detail { get; set; }
        public virtual DbSet<Portfolio_ExtraDetail> Portfolio_ExtraDetail { get; set; }
        public virtual DbSet<Portfolio_General> Portfolio_General { get; set; }
        public virtual DbSet<Portfolio_Personal> Portfolio_Personal { get; set; }
        public virtual DbSet<Portfolio_Customer> Portfolio_Customer { get; set; }
        public virtual DbSet<Portfolio_CustomerRequest> Portfilio_CustomerRequest { get; set; }
        public virtual DbSet<Portfolio_Project> Portfolio_Project { get; set; }
        public virtual DbSet<Portfolio_Company> Portfolio_Company { get; set; }
        public virtual DbSet<Portfolio_Contract> Portfolio_Contract { get; set; }
        public virtual DbSet<Portfolio_Banks> Portfolio_Banks { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
base.OnModelCreating(modelBuilder);
        }
    }
}
