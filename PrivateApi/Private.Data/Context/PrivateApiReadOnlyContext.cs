using Microsoft.EntityFrameworkCore;
using Private.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Data.Context
{
    public class PrivateApiReadOnlyContext : DbContext
    {
        public DbSet<PartnerViewEntity> Partners { get; set; }
        public DbSet<PartnerPersonEntity> PartnerPersons { get; set; }
        public DbSet<PartnerUserViewEntity> PartnerUsers { get; set; }
        public DbSet<CustomerViewEntity> Customers { get; set; }
        public DbSet<CustomerPersonEntity> CustomerPersons { get; set; }
        public DbSet<CustomerUserViewEntity> CustomerUsers { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<PersonAddressEntity> PersonAddress { get; set; }
        public DbSet<UserViewEntity> Users { get; set; }
        public DbSet<TaxRegimeEntity> TaxRegimes { get; set; }
        public DbSet<OperationNatureEntity> OperationNatures { get; set; }
        public DbSet<OperationProfileEntity> OperationProfiles { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<TaxScenarioViewEntity> TaxScenarios { get; set; }
        public DbSet<QueryLogViewEntity> QueryLogs { get; set; }
        public DbSet<BillingAttributeEntity> BillingAttributes { get; set; }
        public DbSet<BillingPlanEntity> BillingPlans { get; set; }
        public DbSet<PlanAttributeEntity> PlanAttributes { get; set; }
        public DbSet<PartnerPlanViewEntity> PartnerPlans { get; set; }
        public DbSet<ReportEntity> Reports { get; set; }
        public DbSet<ItemReportEntity> ItemReports { get; set; }
        public DbSet<RequestReportEntity> RequestReports { get; set; }
        public PrivateApiReadOnlyContext(DbContextOptions<PrivateApiReadOnlyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartnerUserViewEntity>()
                .HasKey(e => new { e.Id, e.IdUser });

            modelBuilder.Entity<CustomerUserViewEntity>()
                .HasKey(e => new { e.Id, e.IdUser });

            modelBuilder.Entity<PartnerPlanViewEntity>()
                .HasKey(e => new { e.Id, e.IdPartnerPerson, e.IdBillingPlan, e.IdPlanAttribute });
        }
    }
}
