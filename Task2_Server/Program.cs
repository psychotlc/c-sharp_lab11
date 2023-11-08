using Microsoft.EntityFrameworkCore;
using Task2.Models;
using Task2.Controllers;
using Pomelo;

    class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.Configure(app =>
                    {
                        app.UseRouting();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapGet("/api/customers/{id}", async context =>
                            {
                                var id = int.Parse(context.Request.RouteValues["id"] as string);
                                var dbContext = context.RequestServices.GetRequiredService<NorthwindContext>();
                                var employee = await dbContext.Customers.FindAsync(id);
                                if (employee != null)
                                {
                                    await context.Response.WriteAsJsonAsync(employee);
                                }
                                else
                                {
                                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                                }
                            });
                        });
                    });
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<NorthwindContext>(options =>
                        options.UseMySql("Persist Security Info=False;Integrated Security=true;Initial Catalog=Northwind;server=(local)", new MySqlServerVersion(new Version(8, 0, 25))));
                });
        }
    }