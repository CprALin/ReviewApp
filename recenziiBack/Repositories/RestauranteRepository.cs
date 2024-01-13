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
                string storedProcedure = "GetByIdRestaurant";

                var parameters = new { IdRestaurant = id };

            return _connection.Query<Restaurante>(storedProcedure , parameters , commandType : CommandType.StoredProcedure);
        }

        public async Task AddRestaurant(AdaugaRestaurant restaurant)
        {
            string storedProcedure = "AddRestaurant";

            var parameters = new
            {
                NumeRestaurant = restaurant.NumeRestaurant,
                AdresaRestaurant = restaurant.AdresaRestaurant,
                DescriereRestaurant = restaurant.DescriereRestaurant,
                PozaRestaurant = restaurant.PozaRestaurant
            };

            await _connection.QueryAsync(storedProcedure , parameters , commandType : CommandType.StoredProcedure);
        }

        public async Task UpdateRestaurant(AdaugaRestaurant restaurant , int id)
        {
            string storedProcedure = "UpdateRestaurant";

            var parameters = new
            {
                IdRestaurant = id,
                NumeRestaurant = restaurant.NumeRestaurant,
                AdresaRestaurant = restaurant.AdresaRestaurant,
                DescriereRestaurant = restaurant.DescriereRestaurant,
                PozaRestaurant = restaurant.PozaRestaurant
            };

            await _connection.QueryAsync(storedProcedure , parameters , commandType : CommandType.StoredProcedure);
        }

        public void DeleteRestaurant(int id)
        {
            string storedProcedure = "DeleteRestaurant";

            var parameters = new { IdRestaurant = id };

            _connection.Query(storedProcedure , parameters , commandType : CommandType.StoredProcedure);
        }
    }
}
