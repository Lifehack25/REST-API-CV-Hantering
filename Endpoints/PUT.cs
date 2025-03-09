using REST_API_CV_Hantering.Data;
using REST_API_CV_Hantering.Models;

namespace REST_API_CV_Hantering.Endpoints
{
    public class PUT
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            // Uppdatera en befintlig person
            app.MapPut("/api/personer/{id:int}", async (
                int id, 
                Person uppdateradPerson, 
                ApplicationDbContext context) =>
            {
                var person = await context.Personer.FindAsync(id);
                if (person is null)
                {
                    return Results.NotFound();
                }

                if (string.IsNullOrWhiteSpace(uppdateradPerson.Namn))
                {
                    return Results.BadRequest("Namn är obligatoriskt.");
                }
                person.Namn = uppdateradPerson.Namn;
                person.Beskrivning = uppdateradPerson.Beskrivning;
                person.Kontaktuppgifter = uppdateradPerson.Kontaktuppgifter;
                await context.SaveChangesAsync();
                return Results.Ok(person);
            });

            // Uppdatera en utbildning
            app.MapPut("/api/utbildningar/{id:int}", async (
                int id, 
                Utbildning UppdateradUtbildning, 
                ApplicationDbContext context) =>
            {
                var utbildning = await context.Utbildningar.FindAsync(id);
                if (utbildning is null)
                {
                    return Results.NotFound();
                }

                if (string.IsNullOrWhiteSpace(UppdateradUtbildning.Skola))
                {
                    return Results.BadRequest("Skola är obligatoriskt.");
                }
                utbildning.Skola = UppdateradUtbildning.Skola;
                utbildning.Examen = UppdateradUtbildning.Examen;
                utbildning.StartDatum = UppdateradUtbildning.StartDatum;
                utbildning.SlutDatum = UppdateradUtbildning.SlutDatum;
                await context.SaveChangesAsync();
                return Results.Ok(utbildning);
            });

            // Uppdatera en arbetslivserfarenhet
            app.MapPut("/api/arbetslivserfarenheter/{id:int}", async (
                int id, 
                Arbetserfarenhet uppdateradErf,
                ApplicationDbContext context) =>
            {
                var workExp = await context.Arbetserfarenheter.FindAsync(id);
                if (workExp is null)
                {
                    return Results.NotFound();
                }
                workExp.Jobbtitel = uppdateradErf.Jobbtitel;
                workExp.Företag = uppdateradErf.Företag;
                workExp.Beskrivning = uppdateradErf.Beskrivning;
                workExp.Arbetsår = uppdateradErf.Arbetsår;
                await context.SaveChangesAsync();
                return Results.Ok(workExp);
            });
        }
    }
}
