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

        public void InregistreazaUtilizator(Utilizatori utilizator)
        {
            //Nume procedura
            string storedProcedure = "procedura";

            //Parametri pentru procedura
            var parameters = new
            {
                EmailUtilizator = utilizator.EmailUtilizator,
                ParolaUtilizator = utilizator.ParolaUtilizator,
                RolUtilizator = utilizator.RolUtilizator
            };

            //Executa procedura stocata
            _connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        }
    }
}
