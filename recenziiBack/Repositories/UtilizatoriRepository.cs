using Dapper;
using recenziiBack.Models;
using System.Data;
using recenziiBack.Services;

namespace recenziiBack.Repositories
{
    public class UtilizatoriRepository
    {
        private readonly IDbConnection _connection;

        public UtilizatoriRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task InregistreazaUtilizator(Utilizatori utilizator)
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
    }
}
