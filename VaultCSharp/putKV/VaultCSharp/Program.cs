using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VaultCSharpExample
{
    class Program
    {
        // The since CS 7.1 TYPE can be Task instead of void
        static async Task Main(string[] args)
        {
            // Creating an instance of the HTTP Client
            HttpClient HttpClient = HttpClientFactory.Create();
            //Setting the URL to our HashiCorp Secret
            string url = "http://10.100.1.11:8200/v1/kv/data/person";
            // Setting the Token Header and the Root Token
            HttpClient.DefaultRequestHeaders.Add("X-Vault-Token", "s.SnKaRZmpWdN4iT5oUtC7WFQu");
            // Setting the Content-type to application/json
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // Making the HTTP Get call to consult our Secret
            JObject json = JObject.Parse(await HttpClient.GetStringAsync(url));
            // Printing the response
            Console.WriteLine(json);
            // Storing the key-value pairs of our secret from the response
            JToken secrets = json["data"]["data"];
            // Validating the previous statement is true
            Console.WriteLine("\n" + secrets);
            // Storing our key-value pairs to a Dictionary for future data manipulation
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(secrets.ToString());
            // Looping through our key-value pairs
            foreach (var item in values)
            {
                // Printing our key-value pairs
                Console.WriteLine($"Key: {item.Key} Value: {item.Value}");
            }
        }
    }
}
