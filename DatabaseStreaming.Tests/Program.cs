using System.Diagnostics;

var endpoints = new string[]
{
    "PeopleAsEnumerable",
};

var iterations = 3;
var httpClient = new HttpClient();

foreach (var endpoint in endpoints)
{
    var times = await MeasureAvgEndpointDuration(httpClient, iterations, endpoint);
    Console.WriteLine($"GET /{endpoint} avg {times}ms");
    Console.WriteLine();
}

async Task<double> MeasureAvgEndpointDuration(HttpClient httpClient, int iterations, string endpoint)
{
    var times = new long[iterations];
    for (var i = 0; i < iterations; i++)
    {
        times[i] = await MeasureEndpointDuration(httpClient, endpoint);
    }

    return times.Average();
}

async Task<long> MeasureEndpointDuration(HttpClient httpClient, string endpoint)
{
    var timer = new Stopwatch();
    timer.Start();

    var result = await httpClient.GetAsync($"https://localhost:7297/{endpoint}");
    result.EnsureSuccessStatusCode();
    await result.Content.ReadAsStringAsync();

    timer.Stop();
    Console.WriteLine($"GET /{endpoint} {timer.ElapsedMilliseconds}ms");
    return timer.ElapsedMilliseconds;
}