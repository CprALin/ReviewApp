using Dapper;
using recenziiBack.Models;
using System.Data;

namespace recenziiBack.Repositories
{
    public class ProfilUtilizatorRepository
    {
        private readonly IDbConnection _connection;

        public ProfilUtilizatorRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<GetProfilUtilizator> GetProfilUtilizator(int id)
        {
            string storedProcedure = "GetProfilUtilizator";

            var parameters = new { IdProfil = id };

            return _connection.Query<GetProfilUtilizator>(storedProcedure , parameters , commandType : CommandType.StoredProcedure);
        }

        public async Task UpdatePozaProfil(UpdatePozaProfilUtilziator profil, int id)
        {
            string storedProcedure = "UpdatePozaProfil";

            var parameters = new
            {
                IdProfil = id,
                NewPozaProfil = profil.PozaProfil
            };

            await _connection.QueryAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateDescriereProfil(UpdateDescriereProfilUtilziator profil , int id)
        {
            string storedProcedure = "UpdateDescriereProfil";

            var parameters = new
            {
              IdProfil = id,
              NewDescriereProfil = profil.DescriereProfil
            };

            await _connection.QueryAsync(storedProcedure, parameters , commandType: CommandType.StoredProcedure);
        }
    }
}
