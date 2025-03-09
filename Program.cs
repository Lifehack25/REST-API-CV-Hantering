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

            // Konfigurera anslutningsstr�ng till SQL Server (l�gg i appsettings.json)
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Registrera HttpClient f�r externa API-anrop
            builder.Services.AddHttpClient();

            // L�gg till Swagger f�r testning av API:t
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Anv�nd Swagger i utvecklingsl�ge
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
