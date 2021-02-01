using Microsoft.EntityFrameworkCore;
using Private.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Data.Context
{
    public class PrivateApiContext : DbContext
    {
        public DbSet<PartnerViewEntity> Partners { get; set; }
        public DbSet<PartnerPersonEntity> PartnerPersons { get; set; }
        public DbSet<PartnerUserEntity> PartnerUsers { get; set; }
        public DbSet<CustomerPersonEntity> CustomerPersons { get; set; }
        public DbSet<CustomerUserEntity> CustomerUsers { get; set; }
        public DbSet<PersonAddressEntity> PersonAddress { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<TaxRegimeEntity> TaxRegimes { get; set; }
        public DbSet<OperationNatureEntity> OperationNatures { get; set; }
        public DbSet<OperationProfileEntity> OperationProfiles { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<TaxScenarioEntity> TaxScenarios { get; set; }
        public DbSet<BillingAttributeEntity> BillingAttributes { get; set; }
        public DbSet<BillingPlanEntity> BillingPlans { get; set; }
        public DbSet<PlanAttributeEntity> PlanAttributes { get; set; }
        public DbSet<PartnerBillingPlanEntity> PartnerBillingPlans { get; set; }
        public PrivateApiContext(DbContextOptions<PrivateApiContext> options) : base(options)
        {
        }
    }
}
