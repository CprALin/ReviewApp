using Microsoft.AspNetCore.Mvc;

namespace recenziiBack.Routes
{
    public static class RestauranteRoutes
    {
        public static void ConfigureRestauranteRoutes(this IEndpointRouteBuilder endpoints) 
        {
            endpoints.MapControllerRoute(
                name: "GetAllRestaurante",
                pattern: "api/Restaurante/getRestaurante",
                defaults: new { controller = "Restaurante", action = "GetRestaurante" }
            );

            endpoints.MapControllerRoute(
                name : "GetByIdRestaurant",
                pattern : "api/Restaurante/getRestaurant/{id}",
                defaults : new { controller = "Restaurante" , action = "GetRestaurant"}
            );

            endpoints.MapControllerRoute(
                name : "AddRestaurant",
                pattern : "api/Restaurante/addRestaurant",
                defaults : new { controller = "Restaurante" , action = "AddRestaurant"}
            );

            endpoints.MapControllerRoute(
                name : "UpdateRestaurant",
                pattern : "api/Restaurante/updateRestaurant/{id}",
                defaults : new { controller = "Restaurante" , action = "UpdateRestaurant" }
            );

            endpoints.MapControllerRoute(
                name : "DeleteRestaurant",
                pattern : "api/Restaurante/deleteRestaurant/{id}",
                defaults : new { controller = "Restaurante" , action = "DeleteRestaurant"}
            );
        }
    }
}
