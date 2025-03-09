using REST_API_CV_Hantering.Data;

namespace REST_API_CV_Hantering.Endpoints
{
    public class DELETE
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            // Ta bort en person
            app.MapDelete("/api/personer/{id:int}", async (int id, ApplicationDbContext context) =>
            {
                var person = await context.Personer.FindAsync(id);
                if (person is null)
                {
                    return Results.NotFound();
                }
                context.Personer.Remove(person);
                await context.SaveChangesAsync();
                return Results.NoContent();
            });

            // Ta bort en utbildning
            app.MapDelete("/api/utbildningar/{id:int}", async (int id, ApplicationDbContext context) =>
            {
                var utbildning = await context.Utbildningar.FindAsync(id);
                if (utbildning is null)
                {
                    return Results.NotFound();
                }
                context.Utbildningar.Remove(utbildning);
                await context.SaveChangesAsync();
                return Results.NoContent();
            });

            // Ta bort en arbetslivserfarenhet
            app.MapDelete("/api/arbetslivserfarenheter/{id:int}", async (int id, ApplicationDbContext context) =>
            {
                var arbetsErf = await context.Arbetserfarenheter.FindAsync(id);
                if (arbetsErf is null)
                {
                    return Results.NotFound();
                }
                context.Arbetserfarenheter.Remove(arbetsErf);
                await context.SaveChangesAsync();
                return Results.NoContent();
            });

        }
    }
}
