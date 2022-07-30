using System.Text.Json.Serialization;

namespace NasaConsumer.Clients.Models
{
    public class AsteroidsResponse
    {
        public AsteroidsResponse()
        {
            this.NearEarthObjects = new Dictionary<string, IEnumerable<NearEarthObject>>();
        }

        [JsonPropertyName("links")]
        public AsteroidsResponseLinks Links { get; set; }

        [JsonPropertyName("element_count")]
        public long ElementCount { get; set; }

        [JsonPropertyName("near_earth_objects")]
        public Dictionary<string, IEnumerable<NearEarthObject>> NearEarthObjects { get; set; }
    }

    public class AsteroidsResponseLinks
    {
        [JsonPropertyName("next")]
        public Uri Next { get; set; }

        [JsonPropertyName("prev")]
        public Uri Prev { get; set; }

        [JsonPropertyName("self")]
        public Uri Self { get; set; }
    }

    public class NearEarthObject
    {
        public NearEarthObject()
        {
            this.CloseApproachData = new List<CloseApproachDatum>();
        }

        [JsonPropertyName("links")]
        public NearEarthObjectLinks Links { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("neo_reference_id")]
        public string NeoReferenceId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nasa_jpl_url")]
        public Uri NasaJplUrl { get; set; }

        [JsonPropertyName("absolute_magnitude_h")]
        public double AbsoluteMagnitudeH { get; set; }

        [JsonPropertyName("estimated_diameter")]
        public EstimatedDiameter EstimatedDiameter { get; set; }

        [JsonPropertyName("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardousAsteroid { get; set; }

        [JsonPropertyName("close_approach_data")]
        public IEnumerable<CloseApproachDatum> CloseApproachData { get; set; }

        [JsonPropertyName("is_sentry_object")]
        public bool IsSentryObject { get; set; }
    }

    public class CloseApproachDatum
    {
        [JsonPropertyName("close_approach_date")]
        public DateTime CloseApproachDate { get; set; }

        [JsonPropertyName("close_approach_date_full")]
        public string CloseApproachDateFull { get; set; }

        [JsonPropertyName("epoch_date_close_approach")]
        public long EpochDateCloseApproach { get; set; }

        [JsonPropertyName("relative_velocity")]
        public RelativeVelocity RelativeVelocity { get; set; }

        [JsonPropertyName("miss_distance")]
        public MissDistance MissDistance { get; set; }

        [JsonPropertyName("orbiting_body")]
        public string OrbitingBody { get; set; }
    }

    public class MissDistance
    {
        [JsonPropertyName("astronomical")]
        public string Astronomical { get; set; }

        [JsonPropertyName("lunar")]
        public string Lunar { get; set; }

        [JsonPropertyName("kilometers")]
        public string Kilometers { get; set; }

        [JsonPropertyName("miles")]
        public string Miles { get; set; }
    }

    public class RelativeVelocity
    {
        [JsonPropertyName("kilometers_per_second")]
        public string KilometersPerSecond { get; set; }

        [JsonPropertyName("kilometers_per_hour")]
        public string KilometersPerHour { get; set; }

        [JsonPropertyName("miles_per_hour")]
        public string MilesPerHour { get; set; }
    }

    public class EstimatedDiameter
    {
        [JsonPropertyName("kilometers")]
        public EstimatedMinMaxDiameter Kilometers { get; set; }

        [JsonPropertyName("meters")]
        public EstimatedMinMaxDiameter Meters { get; set; }

        [JsonPropertyName("miles")]
        public EstimatedMinMaxDiameter Miles { get; set; }

        [JsonPropertyName("feet")]
        public EstimatedMinMaxDiameter Feet { get; set; }
    }

    public class EstimatedMinMaxDiameter
    {
        [JsonPropertyName("estimated_diameter_min")]
        public double EstimatedDiameterMin { get; set; }

        [JsonPropertyName("estimated_diameter_max")]
        public double EstimatedDiameterMax { get; set; }
    }

    public class NearEarthObjectLinks
    {
        [JsonPropertyName("self")]
        public Uri Self { get; set; }
    }
}