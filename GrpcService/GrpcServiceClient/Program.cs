// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using GrpcService;

var channel = GrpcChannel.ForAddress("https://localhost:7293");
var client = new Weather.WeatherClient(channel);

var weather = new WeatherForecast { Summary = "Hot" };
var reply = await client.SaveForecastAsync(weather);

Console.WriteLine(reply.Success);

var result = await client.GetForecastAsync(new Empty());

Console.WriteLine(result.Summary);

Console.ReadLine();


