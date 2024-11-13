using System.Text.Json.Serialization;

namespace task1.models
{
    public class Address
    {

        public int AddressId { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        [JsonIgnore]
        public Student Student { get; set; }
    }
}
