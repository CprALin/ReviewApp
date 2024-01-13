using Dapper;
using recenziiBack.Models;
using System.Data;
using recenziiBack.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace recenziiBack.Repositories
{
    public class UtilizatoriRepository
    {
        private readonly IDbConnection _connection;

        public UtilizatoriRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task InregistreazaUtilizator(UtilizatoriInregistrare utilizator)
        {
            //Nume procedura
            string storedProcedure = "RegisterUtilizator";

            //Parametri pentru procedura
            var parameters = new
            {
                NumeUtilizator = utilizator.NumeUtilizator,
                EmailUtilizator = utilizator.EmailUtilizator,
                ParolaUtilizator = HashParola.HashPass(utilizator.ParolaUtilizator)
            };

            //Executa procedura stocata
            await _connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        }
            
        public async Task<int> AutentificareUtilizator(UtilizatorAutentificare utilizator)
        {
            string storedProcedure = "LoginUtilizator";

            var parameters = new DynamicParameters();
            parameters.Add("EmailUtilizator", utilizator.EmailUtilizator);
            var hashedPass = HashParola.HashPass(utilizator.ParolaUtilizator);
            parameters.Add("ParolaUtilizator", hashedPass);
            parameters.Add("IdProfil" , DbType.Int32 , direction: ParameterDirection.Output);

            await _connection.QueryAsync(storedProcedure , parameters, commandType: CommandType.StoredProcedure);


            int IdProfil = parameters.Get<int>("IdProfil");

            if(IdProfil != -1)
            {
                return IdProfil;
            }
            else
            {
                return -1;
            }
                
        }

        public void DeleteUtilizator(int id)
        {
            string storedProcedure = "DeleteUtilizator";

            var parameters = new { IdUtilizator = id };

            _connection.Query(storedProcedure , parameters , commandType : CommandType.StoredProcedure);
        }
    }
}
