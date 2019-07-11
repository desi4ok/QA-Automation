namespace RegistrationPage.Models
{
    using Newtonsoft.Json;

    public partial class Address
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zipCode")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ZipCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("info")]
        public string Info { get; set; }

        [JsonProperty("mobPhone")]
        public string MobPhone { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }
    }
}