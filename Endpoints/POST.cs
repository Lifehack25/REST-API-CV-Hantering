using REST_API_CV_Hantering.Data;
using REST_API_CV_Hantering.Models;

namespace REST_API_CV_Hantering.Endpoints
{
    public class POST
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            // Lägg till en ny person
            app.MapPost("/api/personer", async (Person person, ApplicationDbContext context) =>
            {
                if (string.IsNullOrWhiteSpace(person.Namn))
                {
                    return Results.BadRequest("Namn är obligatoriskt.");
                }
                context.Personer.Add(person);
                await context.SaveChangesAsync();
                return Results.Created($"/api/personer/{person.Id}", person);
            });

            // Lägg till en utbildning för en person
            app.MapPost("/api/personer/{personId:int}/utbildningar", async (
                int personId, 
                Utbildning utbildning, 
                ApplicationDbContext context) =>
            {
                var person = await context.Personer.FindAsync(personId);
                if (person is null)
                {
                    return Results.NotFound("Personen hittades inte.");
                }
                if (string.IsNullOrWhiteSpace(utbildning.Skola))
                {
                    return Results.BadRequest("Skola är obligatoriskt.");
                }
                utbildning.PersonId = personId;
                context.Utbildningar.Add(utbildning);
                await context.SaveChangesAsync();
                return Results.Created($"/api/utbildningar/{utbildning.Id}", utbildning);
            });

            // Lägg till en arbetslivserfarenhet för en person
            app.MapPost("/api/personer/{personId:int}/arbetslivserfarenheter", async (
                int personId, 
                Arbetserfarenhet arbetserfarenhet, 
                ApplicationDbContext context) =>
            {
                var person = await context.Personer.FindAsync(personId);
                if (person is null)
                {
                    return Results.NotFound("Personen hittades inte.");
                }
                if (string.IsNullOrWhiteSpace(arbetserfarenhet.Jobbtitel))
                {
                    return Results.BadRequest("Jobbtitel är obligatoriskt.");
                }
                arbetserfarenhet.PersonId = personId;
                context.Arbetserfarenheter.Add(arbetserfarenhet);
                await context.SaveChangesAsync();
                return Results.Created($"/api/arbetslivserfarenheter/{arbetserfarenhet.Id}", arbetserfarenhet);
            });
        }
    }
}
