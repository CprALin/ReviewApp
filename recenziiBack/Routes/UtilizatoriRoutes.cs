using System.Runtime.CompilerServices;

namespace recenziiBack.Routes
{
    public static class UtilizatoriRoutes
    {
        public static void ConfigureUtilizatoriRoutes(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllerRoute(
                name : "InregistrareUtilizator",
                pattern : "api/Utilizatori/inregistrare",
                defaults : new {controller = "Utilizatori", action = "inregistrare"}
            );
        }
    }
}
