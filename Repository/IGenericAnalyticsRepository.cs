namespace QualityLabPro.Api.Repository;
using QualityLabPro.Api.Entities;

public interface IGenericAnalyticsRepository
{
    IEnumerable<GenericAnalytics> GetAll();
    GenericAnalytics GetGenericAnalyticsById(Guid guid);
    GenericAnalytics PostGenericAnalytics(GenericAnalytics genericAnalytics);
    List<GenericAnalytics> PostGenericAnalyticsList(List<GenericAnalytics> genericAnalytics);

    GenericAnalytics PutGenericAnalyticsById(Guid idGuid, GenericAnalytics genericAnalytics);
    bool DeleteGenericAnalytics(Guid guid);
}