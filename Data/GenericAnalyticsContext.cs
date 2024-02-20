using Microsoft.EntityFrameworkCore;
namespace QualityLabPro.Api.Data;
using QualityLabPro.Api.Entities;
    public class GenericAnalyticsContext : DbContext
    {
        public GenericAnalyticsContext(DbContextOptions<GenericAnalyticsContext> options) : base(options)
        {
        }
        public DbSet<GenericAnalytics> GenericAnalytics { get; set; }
    }