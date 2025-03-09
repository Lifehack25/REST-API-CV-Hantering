using System.Text.Json.Serialization;
using REST_API_CV_Hantering.Models;
using REST_API_CV_Hantering.Data;
using Microsoft.EntityFrameworkCore;
using REST_API_CV_Hantering.Endpoints;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace REST_API_CV_Hantering
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Konfigurera anslutningssträng till SQL Server (lägg i appsettings.json)
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Registrera HttpClient för externa API-anrop
            builder.Services.AddHttpClient();

            // Lägg till Swagger för testning av API:t
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Använd Swagger i utvecklingsläge
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Registrera endpoints
            GET.RegisterEndpoints(app);
            POST.RegisterEndpoints(app);
            PUT.RegisterEndpoints(app);
            DELETE.RegisterEndpoints(app);

            app.Run();
        }
    }
}
