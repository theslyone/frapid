using Newtonsoft.Json;
using System;

namespace Frapid.Events.Models
{
    [Serializable]
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }
    }
}
