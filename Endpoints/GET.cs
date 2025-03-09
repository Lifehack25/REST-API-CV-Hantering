using Microsoft.EntityFrameworkCore;
using REST_API_CV_Hantering.Data;
using REST_API_CV_Hantering.DTOs;

namespace REST_API_CV_Hantering.Endpoints
{
    public class GET
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            // Hämta alla personer med tillhörande utbildningar och arbetslivserfarenheter
            app.MapGet("/api/personer", async (ApplicationDbContext context) =>
                await context.Personer.Include(p => p.Utbildningar)
                                  .Include(p => p.Arbetserfarenheter)
                                  .ToListAsync()
            );

            // Hämta en specifik person baserat på ID
            app.MapGet("/api/personer/{id:int}", async (int id, ApplicationDbContext context) =>
            {
                var person = await context.Personer
                                     .Include(p => p.Utbildningar)
                                     .Include(p => p.Arbetserfarenheter)
                                     .FirstOrDefaultAsync(p => p.Id == id);
                return person is not null ? Results.Ok(person) : Results.NotFound();
            });

            // Hämta GitHub-repos för en specifik användare.
            app.MapGet("/api/github/{username}", async (string username, IHttpClientFactory httpClientFactory) =>
            {
                var client = httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.UserAgent.ParseAdd("CV-API");

                var response = await client.GetAsync($"https://api.github.com/users/{username}/repos");
                if (!response.IsSuccessStatusCode)
                {
                    return Results.NotFound("GitHub-användare hittades inte eller så gick något fel.");
                }

                var content = await response.Content.ReadAsStringAsync();
                var repos = System.Text.Json.JsonSerializer.Deserialize<List<GitHubRepoDto>>(content, new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Mappa till DTO
                var result = repos.Select(r => new GitHubRepoDto
                {
                    Namn = r.Namn,
                    Språk = string.IsNullOrWhiteSpace(r.Språk) ? "okänt" : r.Språk,
                    Beskrivning = string.IsNullOrWhiteSpace(r.Beskrivning) ? "saknas" : r.Beskrivning,
                    Länk = r.Länk
                });

                return Results.Ok(result);
            });

        }
    }
}
