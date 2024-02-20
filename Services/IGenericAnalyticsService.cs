namespace QualityLabPro.Api.Services;
using QualityLabPro.Api.Entities;

public interface IGenericAnalyticsService
{
    IEnumerable<GenericAnalytics> GetAllGenericAnalytics();
    GenericAnalytics GetGenericAnalyticsById(Guid id);
    GenericAnalytics CreateGenericAnalytics(GenericAnalytics genericAnalytics);
    
    List<GenericAnalytics> CreateGenericAnalyticsList(List<GenericAnalytics> genericAnalytics);
    GenericAnalytics UpdateGenericAnalyticsById(Guid id, GenericAnalytics genericAnalytics);
    bool DeleteAnalytics(Guid id);

}