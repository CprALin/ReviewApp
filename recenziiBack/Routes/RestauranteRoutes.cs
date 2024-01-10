﻿namespace recenziiBack.Routes
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
        }
    }
}
