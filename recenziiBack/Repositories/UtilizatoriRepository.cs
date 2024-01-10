using Dapper;
using recenziiBack.Models;
using System.Data;

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
                EmailUtilizator = utilizator.EmailUtilizator,
                ParolaUtilizator = utilizator.ParolaUtilizator
            };

            //Executa procedura stocata
            await _connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        }
    }
}
