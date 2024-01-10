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

        public IEnumerable<Restaurante> GetByIdRestaurant(int id)
        {
                //Nume procedura
                string procedura = "GetByIdRestaurant";

                var parameters = new { IdRestaurant = id };

            return _connection.Query<Restaurante>(procedura , parameters , commandType : CommandType.StoredProcedure);
        }
    }
}
