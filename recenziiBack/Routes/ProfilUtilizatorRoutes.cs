namespace recenziiBack.Routes
{
    public static class ProfilUtilizatorRoutes
    {
        public static void ConfigureProfilRoutes(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllerRoute(
                name: "GetProfilUtilizator",
                pattern: "api/ProfilUtilizatori/getProfilUtilizator/{id}",
                defaults: new { controller = "ProfilUtilizatori", action = "getProfilUtilizator" }
            );

            endpoints.MapControllerRoute(
                name: "UpdatePozaProfil",
                pattern: "api/ProfilUtilizatori/updatePozaProfil/{id}",
                defaults: new { controller = "ProfilUtilizatori", action = "updatePozaProfil" }
            );

            endpoints.MapControllerRoute(
                name: "UpdateDescriereProfil",
                pattern: "api/ProfilUtilizatori/updateDescriereProfil/{id}",
                defaults: new { controller = "ProfilUtilizatori", action = "updateDescriereProfil" }
            );
        }
    }
}
