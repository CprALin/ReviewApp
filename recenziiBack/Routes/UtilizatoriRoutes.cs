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

            endpoints.MapControllerRoute(
                name : "AutentificareUtilizator",
                pattern : "api/Utilizatori/autentificare",
                defaults : new { controller = "Utilizatori" , action = "autentificare"}
            );

            endpoints.MapControllerRoute(
                name : "DeleteUtilizator",
                pattern : "api/Utilizatori/deleteUtilizator",
                defaults : new { controller = "Utilizatori" , action = "deleteUtilizator"}
            );
        }
    }
}
