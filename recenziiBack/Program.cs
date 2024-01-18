
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using recenziiBack.Routes;
using recenziiBack.Services;
using System.Text;

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

            builder.Services.AddScoped<JWTservice>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtConfig:key").Get<string>())),
                    ValidateLifetime = true,
                    ValidIssuer = builder.Configuration.GetSection("JwtConfig:Issuer").Get<string>(),
                    ValidAudience = builder.Configuration.GetSection("JwtConfig:Audience").Get<string>(),
                    ValidateIssuerSigningKey = true
                };
            });


            builder.Services.AddAuthorization();

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
            
            app.UseAuthentication();
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
