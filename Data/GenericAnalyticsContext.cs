using Microsoft.EntityFrameworkCore;
namespace QualityLabPro.Api.Data;
    public class GenericAnalyticsContext : DbContext
    {
        public GenericAnalyticsContext(DbContextOptions<GenericAnalyticsContext> options) : base(options)
        {
        }
        public DbSet<GenericAnalytics.GenericAnalytics> GenericAnalytics { get; set; }
    }