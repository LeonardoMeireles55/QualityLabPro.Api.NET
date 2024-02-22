using QualityLabPro.Api.Data;

namespace QualityLabPro.Api.Repository;
using QualityLabPro.Api.Entities;

public class GenericAnalyticsRepository : IGenericAnalyticsRepository

{
    private List<GenericAnalytics> _GenericAnalytics { get;}
    private GenericAnalyticsContext _context;
    
    public GenericAnalyticsRepository(GenericAnalyticsContext context)
    {
        _context = context;
        _GenericAnalytics = new List<GenericAnalytics>();
    }
    
    public IEnumerable<GenericAnalytics> GetAll()
    {
        return _context.GenericAnalytics.ToList();
    }

    public GenericAnalytics GetGenericAnalyticsById(Guid iGuid)
    {
        return _context.GenericAnalytics.FirstOrDefault(p => p.Id == iGuid)??
            throw new ArgumentNullException(nameof(iGuid));
    }

    public GenericAnalytics PostGenericAnalytics(GenericAnalytics genericAnalytics)
    {
        _context.Add(genericAnalytics);
        _context.SaveChanges();
        return genericAnalytics;
    }

    public List<GenericAnalytics> PostGenericAnalyticsList(List<GenericAnalytics> genericAnalytics)
    { 
        _context.AddRange(genericAnalytics);
        _context.SaveChanges();
        return genericAnalytics;
    }

    public GenericAnalytics PutGenericAnalyticsById(Guid idGuid, GenericAnalytics genericAnalytics)
    {
        var analytics = _GenericAnalytics.FirstOrDefault(up => up.Id == idGuid);

        analytics.Value = genericAnalytics.Value;
        analytics.UnitValue = genericAnalytics.UnitValue;
        analytics.Sd = genericAnalytics.Sd;
        
        _context.Add(analytics);
        _context.SaveChanges();

        return _GenericAnalytics.Find(x => x.Id == idGuid);

    }

    public bool DeleteGenericAnalytics(Guid idGuid)
    {
        var analytics = _context.GenericAnalytics.FirstOrDefault(p => p.Id == idGuid);
        if (analytics is not null)
        {
            _context.Remove(analytics);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}