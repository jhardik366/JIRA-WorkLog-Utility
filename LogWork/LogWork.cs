using System.Net;
using System.Text;
using System.Text.Json;

namespace LogWork
{
    public class LogWork
    {
        public static async Task LogWorkOnJira(string issueNumber, string timeSpent)
        {
            var fileData = File.ReadAllText(@"../../../credentials.json");
            var credentials = JsonSerializer.Deserialize<CredentialsModel>(fileData);

            // Create the HttpClient.
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add(Constants.Authorization, Constants.Basic + Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials.Email + ":" + credentials.Token)));

            string payload = "{\"comment\":{\"content\":[],\"type\":\"doc\",\"version\":1},\"timeSpent\":" + "\"" + timeSpent + "\"" + "}";

            // Create the request.
            var request = new HttpRequestMessage(HttpMethod.Post, Constants.Domain + "rest/api/3/issue/" + issueNumber + "/worklog");
            request.Content = new StringContent(payload, Encoding.UTF8, "application/json");
            request.Headers.Add("accept", "*/*");
            request.Headers.Add("contenttype", "*/*");

            // Send the request.
            var response = await client.SendAsync(request);

            // Check the response code.
            if (response.StatusCode == HttpStatusCode.Created)
            {
                // The work was logged successfully.
                Console.WriteLine("Work logged successfully.");
            }
            else
            {
                // An error occurred.
                Console.WriteLine("Error logging work.");
            }
        }
    }
}
