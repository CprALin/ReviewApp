namespace recenziiBack.Routes
{
    public static class RecenziiRoutes
    {
        public static void ConfigureRecenziiRoutes(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllerRoute(
                name: "GetRecenziiRestaurant",
                pattern: "api/Recenzii/getRecenziiRestaurant/{id}",
                defaults: new { controller = "Recenzii", action = "GetRecenzii" }
            );

            endpoints.MapControllerRoute(
               name: "AddRecenzie",
               pattern: "api/Recenzii/addRecenzie/UtilizatorId={idU}/RestaurantId={idR}",
               defaults: new { controller = "Recenzii", action = "AddRecenzie" }
           );

            endpoints.MapControllerRoute(
               name: "UpdateRecenzie",
               pattern: "api/Recenzii/updateRecenzie/{id}",
               defaults: new { controller = "Recenzii", action = "UpdateRecenzie" }
           );

            endpoints.MapControllerRoute(
               name: "DeleteRecenzie",
               pattern: "api/Recenzii/deleteRecenzie/{id}",
               defaults: new { controller = "Recenzii", action = "DeleteRecenzie" }
           );

        }
    }
}
