using TravelPlannerServices.Interfaces;
using TravelPlannerServices.Services;
using TravelPlannerServices.Data;
using Microsoft.EntityFrameworkCore;

namespace TravelPlannerServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            var corsConfigName = "CORS-Config";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: corsConfigName, policy =>
                {
                    policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                });
            });
            builder.Services.AddDbContext<DataContext>(options =>
                        {
                            options.UseSqlServer(builder.Configuration.GetConnectionString("MSSqlConnection"));
                        });
            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // add services
            builder.Services.AddScoped<ITravelItemsService, TravelItemsMSSqlService>();
            builder.Services.AddScoped<IExpenseItemsServices, ExpenseItemsMSSqlServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(corsConfigName);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
