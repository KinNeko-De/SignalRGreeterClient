using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;


namespace SignalRGreeterClient
{
	class Program
	{
		static async Task Main(string[] args)
		{
			

			var hubConnection = new HubConnectionBuilder()
				.WithUrl("http://localhost:5000/SignalRGreeterHub").Build();


			var stopwatch = new Stopwatch();
			stopwatch.Start();
			await hubConnection.StartAsync();
			var response = await hubConnection.InvokeAsync<string>("SayHello", "SignalR Client");
			stopwatch.Stop();
			Console.WriteLine($"First call needed {stopwatch.ElapsedMilliseconds} ms.");
			Console.WriteLine(response);

			stopwatch.Restart();
			var response2 = await hubConnection.InvokeAsync<string>("SayHello", "SignalR Client2");
			stopwatch.Stop();
			Console.WriteLine($"Second call needed {stopwatch.ElapsedMilliseconds} ms.");

			Console.WriteLine(response2);
		}
	}
}
