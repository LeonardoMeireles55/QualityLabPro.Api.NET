using QualityLabPro.Api.Data;

namespace QualityLabPro.Api.GenericAnalytics;

public static class GenericAnalyticsEntryPoint
{
    public static void GenericAnalyticsController(this WebApplication webApplication)
    {
        var entryPointsGenericAnalytics = webApplication.MapGroup("");
        webApplication.MapGet("", (GenericAnalyticsContext context) =>
        {
            var results = context.GenericAnalytics.ToList();
            return results;
        });
        
        webApplication.MapPost("",
            async (GenericAnalyticsRecord request, GenericAnalyticsContext context) =>
            {
                var newGenericAnalytics = new GenericAnalytics(request.date, request.level, request.level_lot,
                    request.test_lot, request.name, request.value, request.mean, request.sd, request.unit_value);
                var result  = await context.GenericAnalytics.AddAsync(newGenericAnalytics);
                await context.SaveChangesAsync();
                
                Console.Write(result);
            });

        webApplication.MapPost("/list",
            async (List<GenericAnalyticsRecord> requestList, GenericAnalyticsContext context) =>
            {
                {
                    var genericAnalyticsList = requestList.Select(request =>
                            new GenericAnalytics(request.date, request.level, request.level_lot,
                                request.test_lot, request.name, request.value, request.mean, request.sd,
                                request.unit_value))
                        .ToList();

                    await context.GenericAnalytics.AddRangeAsync(genericAnalyticsList);
                    await context.SaveChangesAsync();
                }
            });
    }
}