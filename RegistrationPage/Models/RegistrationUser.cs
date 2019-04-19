namespace RegistrationPage.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Globalization;

    public partial class RegistrationUser
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTimeOffset DateOfBirth { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }

    public partial class RegistrationUser
    {
        public static RegistrationUser FromJson(string json) => JsonConvert.DeserializeObject<RegistrationUser>(json, RegistrationPage.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this RegistrationUser self) => JsonConvert.SerializeObject(self, RegistrationPage.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}