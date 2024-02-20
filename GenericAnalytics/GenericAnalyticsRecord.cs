namespace QualityLabPro.Api.GenericAnalytics;

public record GenericAnalyticsRecord(string date, string level, string level_lot, string test_lot, string name,
    double value, double mean, double sd, string unit_value
    );