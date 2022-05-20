using System.Diagnostics;

var endpoints = new string[]
{
    "PeopleAsEnumerable",
    "PeopleAsList",
    "PeopleAsArray",
};

var iterations = 3;
var httpClient = new HttpClient();

foreach (var endpoint in endpoints)
{
    var times = await MeasureAvgEndpointDuration(iterations, endpoint);
    Console.WriteLine($"Average: GET /{endpoint} {times:0}ms");
    Console.WriteLine();
}

async Task<double> MeasureAvgEndpointDuration(int iterations, string endpoint)
{
    var times = new long[iterations];
    for (var i = 0; i < iterations; i++)
    {
        times[i] = await MeasureEndpointDuration(endpoint);
        Console.WriteLine($"Iteration {i}: GET /{endpoint} {times[i]:0}ms");
    }

    return times.Average();
}

async Task<long> MeasureEndpointDuration(string endpoint)
{
    var timer = new Stopwatch();
    timer.Start();

    var result = await httpClient.GetAsync($"https://localhost:7297/{endpoint}");
    result.EnsureSuccessStatusCode();
    await result.Content.ReadAsStringAsync();

    timer.Stop();
    return timer.ElapsedMilliseconds;
}
