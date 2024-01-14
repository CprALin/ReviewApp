
using recenziiBack.Routes;

namespace recenziiBack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adaugă serviciile pentru container.
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            builder.Services.AddControllers();

          
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configurează pipeline-ul de cereri HTTP.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(); // Fără specificarea unor politici, acceptă orice origine

            app.UseAuthorization();

            //Rute
            UtilizatoriRoutes.ConfigureUtilizatoriRoutes(app);
            RestauranteRoutes.ConfigureRestauranteRoutes(app);
            ProfilUtilizatorRoutes.ConfigureProfilRoutes(app);
            RecenziiRoutes.ConfigureRecenziiRoutes(app);

            app.Run();
        }
    }
}
