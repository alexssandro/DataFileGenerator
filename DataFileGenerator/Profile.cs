using System.Text.Json.Serialization;

namespace DataFileGenerator
{
    internal class Profile
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonPropertyName("Email Address")]
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string LifeCycleStage { get; set; }
        public string ContactOwner { get; set; }
        public string FavoriteIceCreamFlavor { get; set; }
    }
}
