using Dapper;
using recenziiBack.Models;
using System.Data;

namespace recenziiBack.Repositories
{
    public class RestauranteRepository
    {
        private readonly IDbConnection _connection;

        public RestauranteRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Restaurante> GetAllRestaurante()
        {
            return _connection.Query<Restaurante>("GetAllRestaurante", commandType: CommandType.StoredProcedure);
        }
    }
}
