using QualityLabPro.Api.Data;

namespace QualityLabPro.Api.GenericAnalytics;

public static class GenericAnalyticsEntryPoint
{
    public static void AddGenericAnalyticsEntryPoint(this WebApplication webApplication)
    {
        var entryPointsGenericAnalytics = webApplication.MapGroup("analytics");
        webApplication.MapGet("", (GenericAnalyticsContext context) =>
        {
            var results = context.GenericAnalytics.ToList();
            return results;
        });


        webApplication.MapPost("",
            async (GenericAnalyticsRecord request, GenericAnalyticsContext context) =>
            {
                var newGenericAnalytics = new GenericAnalytics(request.date, request.level, request.levelLot,
                    request.testLot, request.name, request.value, request.mean, request.sd, request.unitValue);
                var result  = await context.GenericAnalytics.AddAsync(newGenericAnalytics);
                await context.SaveChangesAsync();
                
                Console.Write(result);
            });
    }
}