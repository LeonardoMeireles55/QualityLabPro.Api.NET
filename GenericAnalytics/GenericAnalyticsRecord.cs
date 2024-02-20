namespace QualityLabPro.Api.GenericAnalytics;

public record GenericAnalyticsRecord(string date, string level, string levelLot, string testLot, string name,  double value,
    double mean, double sd, string unitValue
    );