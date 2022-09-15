using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCardTask.Models
{
    public class VCard
    {
        public int Id { get; set; }
        [JsonProperty("first")]
        public string Firstname { get; set; }
        [JsonProperty("last")]
        public string Lastname { get; set; }
        [JsonProperty("name")]
        public string Email { get; set; }
        [JsonProperty("name")]
        public string Phone { get; set; }
        [JsonProperty("name")]
        public string Country { get; set; }
        [JsonProperty("name")]
        public string City { get; set; }
    }
}
