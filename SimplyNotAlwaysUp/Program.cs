using SimplyNotAlwaysUp.Models;

using System.Net.Http;
using System.Text;


// Import the System provided JSON library
using System.Text.Json;

// Set some global JSON (De)Serializer options
JsonSerializerOptions options = new()
{
    PropertyNameCaseInsensitive = true,
    WriteIndented = true
};

// Create a HTTP client to send/post web requests
HttpClient client = new();

// Wrap everything in a try/catch for easier error handling, we can split this out later if we want to handle errors in different stages in different ways.
// For development / testing Visual Studios will help us dial down even with a generic try/catch block.
try
{
    // Capture the time we made the requests
    DateTime dateTime = DateTime.Now;

    // Make our requests to the two OPS Genie JSON endpoints
    using HttpResponseMessage statusResponse = await client.GetAsync("https://opsgenie.status.atlassian.com/api/v2/status.json");
    using HttpResponseMessage incidentsResponse = await client.GetAsync("https://opsgenie.status.atlassian.com/api/v2/incidents.json");

    // Ensure we get valid replies back, will throw and be caught if not, we can add more granular error handling later if required.
    _ = statusResponse.EnsureSuccessStatusCode();
    _ = incidentsResponse.EnsureSuccessStatusCode();

    // Read our responses and store them as basic JSON strings.
    string statusResult = await statusResponse.Content.ReadAsStringAsync();
    string incidentsResult = await incidentsResponse.Content.ReadAsStringAsync();

    // Deserialize our JSON strings into our POD objects using the JSON options created earlier
    StatusResponse? status = JsonSerializer.Deserialize<StatusResponse>(statusResult, options);
    IncidentsResponse? incidents = JsonSerializer.Deserialize<IncidentsResponse>(incidentsResult, options);

    // Format our Slack message (Can look into using POD at a later iteration)
    string slackMessageText = string.Format("*OpsGenie System Status Report* (as of {0:dd/MM/yy hh:mm:ss} \r\n)", dateTime);

    slackMessageText += string.Format("*Overall Status:* {0}\r\n", status.Status.Description.ToString());

    using StringContent slackMessage = new(JsonSerializer.Serialize(new { text = slackMessageText, }), Encoding.UTF8, "application/json");

    // Post our Slack message to the Slack endpoint (https://webhook.site/83af7cc8-0ad8-42b9-bbe6-aa7483a62c7b)
    using HttpResponseMessage response = await client.PostAsync("https://webhook.site/83af7cc8-0ad8-42b9-bbe6-aa7483a62c7b", slackMessage);

    // Handle the response and any errors
    response.EnsureSuccessStatusCode();

    var jsonResponse = await response.Content.ReadAsStringAsync();

    Console.WriteLine($"{jsonResponse}\n");
}
catch (HttpRequestException e)
{
    Console.WriteLine("\nException Caught!");
    Console.WriteLine("Message :{0} ", e.Message);
}