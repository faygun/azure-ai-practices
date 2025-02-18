using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace azure_ai_practices.translator
{
    public class TranslatorService
    {
        const string endpoint = "https://api.cognitive.microsofttranslator.com";
        const string route = "/translate?api-version=3.0&from=en&to=fr&to=zu&to=tr";
        public static async Task<string> Translate(string text)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string apiKey = Environment.GetEnvironmentVariable("ApiKey");
                    string region = Environment.GetEnvironmentVariable("Region");

                    object[] body = new object[] { new { Text = text } };
                    var requestBody = JsonConvert.SerializeObject(body);

                    using (var request = new HttpRequestMessage())
                    {
                        // Build the request.
                        request.Method = HttpMethod.Post;
                        request.RequestUri = new Uri(endpoint + route);
                        request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                        request.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
                        // location required if you're using a multi-service or regional (not global) resource.
                        request.Headers.Add("Ocp-Apim-Subscription-Region", region);

                        // Send the request and get response.
                        HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                        // Read response as a string.
                        string result = await response.Content.ReadAsStringAsync();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {

                return string.Empty;
            }
        }
    }
}
