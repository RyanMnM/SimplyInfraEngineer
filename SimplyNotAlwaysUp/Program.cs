using SimplyNotAlwaysUp.Modals;

using System.Text.Json;

var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
};


TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Etc/UTC");

HttpClient client = new();

try
{
    using HttpResponseMessage statusResponse = await client.GetAsync("https://opsgenie.status.atlassian.com/api/v2/status.json");
    using HttpResponseMessage incidentsResponse = await client.GetAsync("https://opsgenie.status.atlassian.com/api/v2/incidents.json");

    statusResponse.EnsureSuccessStatusCode();
    incidentsResponse.EnsureSuccessStatusCode();

    string statusResult = await statusResponse.Content.ReadAsStringAsync();
    string incidentsResult = await incidentsResponse.Content.ReadAsStringAsync();

    Console.WriteLine(statusResult);

    StatusResponse? status = JsonSerializer.Deserialize<StatusResponse>(statusResult, options);

    Console.WriteLine(status);
}
catch (HttpRequestException e)
{
    Console.WriteLine("\nException Caught!");
    Console.WriteLine("Message :{0} ", e.Message);
}
