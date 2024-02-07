using AirTek;
using AirTek.Repository;
using AirTek.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<IFlight, FlightService>();
builder.Services.AddSingleton<ISchedule, SchedulerService>();
builder.Services.AddSingleton<IOrder, OrderService>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<IScheduleRepository, ScheduleRepository>();
builder.Services.AddSingleton<IFlightRepository, FlightRepository>();
builder.Services.AddSingleton<IFileRead<JSONFileReader>, JSONFileReader>();
builder.Services.AddSingleton<IFileRead<TextFileReader>, TextFileReader>();
builder.Services.AddSingleton<IWriter<FlightWriter>, FlightWriter>();
builder.Services.AddSingleton<IWriter<OrderWriter>, OrderWriter>();
builder.Services.AddSingleton<App>();
//builder.Configuration.AddJsonFile("AppSettings.json");

using IHost host = builder.Build();

await host.Services.GetService<App>().Run();
await host.RunAsync();