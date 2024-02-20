namespace QualityLabPro.Api.Services

{
    using QualityLabPro.Api.Repository;
    using QualityLabPro.Api.Entities;
    
    public class GenericAnalyticsService : IGenericAnalyticsService
    {
        private readonly IGenericAnalyticsRepository _genericAnalyticsRepository;

        public GenericAnalyticsService(IGenericAnalyticsRepository genericAnalyticsRepository)
        {
            _genericAnalyticsRepository = genericAnalyticsRepository;
        }
        
        public IEnumerable<GenericAnalytics> GetAllGenericAnalytics()
        {
            return _genericAnalyticsRepository.GetAll();
        }

        public GenericAnalytics GetGenericAnalyticsById(Guid id)
        {
            var analytics = _genericAnalyticsRepository.GetGenericAnalyticsById(id);
            return analytics;
        }

        public GenericAnalytics CreateGenericAnalytics(GenericAnalytics genericAnalytics)
        {
            return _genericAnalyticsRepository.PostGenericAnalytics(genericAnalytics);
        }
        
        
        public List<GenericAnalytics> CreateGenericAnalyticsList(List<GenericAnalytics> genericAnalytics)
        {
            return _genericAnalyticsRepository.PostGenericAnalyticsList(genericAnalytics);
        }

        public GenericAnalytics UpdateGenericAnalyticsById(Guid id, GenericAnalytics genericAnalytics)
        {
            return _genericAnalyticsRepository.PutGenericAnalyticsById(id, genericAnalytics);
        }

        public bool DeleteAnalytics(Guid id)
        {
            return _genericAnalyticsRepository.DeleteGenericAnalytics(id);
        }
    }
}