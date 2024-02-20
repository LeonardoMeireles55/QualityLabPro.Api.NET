namespace QualityLabPro.Api.Entities;

public class GenericAnalytics
{
    public Guid Id { get; init; }
    public string Date { get; set; }
    public string Level { get; set; }
    public string LevelLot { get; set;}
    public string TestLot { get; set; }
    public string Name { get; set; }
    public double Value { get; set; }
    public double Mean { get; set; }
    public double Sd { get; set; }
    public string UnitValue { get; set; }

    public GenericAnalytics(string date, string level, string levelLot, string testLot, string name,  double value,
        double mean, double sd, string unitValue)
    {
        Id = Guid.NewGuid();
        Date = date;
        LevelLot = levelLot;
        TestLot = testLot;
        Name = name;
        Level = level;
        Value = value;
        Mean = mean;
        Sd = sd;
        UnitValue = unitValue;
    }
}