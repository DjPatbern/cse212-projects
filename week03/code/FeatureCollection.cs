public class FeatureCollection
{
    public Feature[] Features { get; set; } = [];
}

public class Feature
{
    public EarthquakeProperties Properties { get; set; } = new();
}

public class EarthquakeProperties
{
    public double? Mag { get; set; }

    public string? Place { get; set; }
}