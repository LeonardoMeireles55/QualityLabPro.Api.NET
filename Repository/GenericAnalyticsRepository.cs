using Microsoft.EntityFrameworkCore;

namespace QualityLabPro.Api.Repository;
using QualityLabPro.Api.Entities;

public class GenericAnalyticsRepository : IGenericAnalyticsRepository

{
    public static List<GenericAnalytics> _GenericAnalytics { get; set; } = new List<GenericAnalytics>();
    
    public IEnumerable<GenericAnalytics> GetAll()
    {
        return _GenericAnalytics;
    }

    public GenericAnalytics? GetGenericAnalyticsById(Guid Id)
    {
        return _GenericAnalytics.FirstOrDefault(p => p.Id == Id);
    }

    public GenericAnalytics PostGenericAnalytics(GenericAnalytics genericAnalytics)
    {
        _GenericAnalytics.Add(genericAnalytics);
        return genericAnalytics;
    }

    public List<GenericAnalytics> PostGenericAnalyticsList(List<GenericAnalytics> genericAnalytics)
    { 
        _GenericAnalytics.AddRange(genericAnalytics);
        return genericAnalytics;
    }

    public GenericAnalytics PutGenericAnalyticsById(Guid idGuid, GenericAnalytics genericAnalytics)
    {
        var analytics = _GenericAnalytics.FirstOrDefault(up => up.Id == idGuid);

        analytics.Value = genericAnalytics.Value;
        analytics.UnitValue = genericAnalytics.UnitValue;
        analytics.Sd = genericAnalytics.Sd;
        
        _GenericAnalytics.Add(analytics);

        return _GenericAnalytics.Find(x => x.Id == idGuid);

    }

    public bool DeleteGenericAnalytics(Guid idGuid)
    {
        var analytics = _GenericAnalytics.FirstOrDefault(p => p.Id == idGuid);
        if (analytics is not null)
        {
            _GenericAnalytics.Remove(analytics);
            return true;
        }
        return false;
    }
}