using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace mi2cs
{
    public static class MaterialIconDownloader
    {
        [DebuggerDisplay("{Name}")]
        public partial class Icon
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("codepoint")]
            public string Codepoint { get; set; }

            [JsonProperty("aliases")]
            public string[] Aliases { get; set; }

            [JsonProperty("tags")]
            public string[] Tags { get; set; }

            [JsonProperty("author")]
            public string Author { get; set; }

            [JsonProperty("version")]
            public string Version { get; set; }
        }

        public static async Task<IReadOnlyList<MaterialIcon>> DownloadIconCodes(string endpoint)
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("Downloading: " + endpoint);

                var content = await client.GetStringAsync(endpoint);

                var icons = JsonConvert.DeserializeObject<List<Icon>>(content);
                
                var result = icons.Select(icon => new MaterialIcon(icon.Name, icon.Codepoint)).ToList();

                Console.WriteLine("Discovered " + result.Count + " icons from " + endpoint);

                return result;
            }
        }
    }
}
