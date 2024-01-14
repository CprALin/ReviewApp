using Dapper;
using recenziiBack.Models;
using System.Data;
using System.Runtime.CompilerServices;

namespace recenziiBack.Repositories
{
    public class RecenziiRepository
    {
        private readonly IDbConnection _connection;

        public RecenziiRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<GetRecenzieRestaurant> GetRecenziiRestaurant(int id)
        {
            string storedProcedure = "GetRecenzieForRestaurant";

            var parameters = new { IdRestaurant = id };

            return _connection.Query<GetRecenzieRestaurant>(storedProcedure , parameters , commandType : CommandType.StoredProcedure);
        }

        public async Task AddRecenzie(AddRecenzieRestaurant recenzie , int idRestaurant , int idUtilziator)
        {
            string storedProcedure = "AddRecenzie";

            var parameters = new
            {
               IdRestaurant = idRestaurant ,
               IdUtilizator = idUtilziator,
               TitluRecenzie = recenzie.TitluRecenzie,
               DescriereRecenzie = recenzie.DescriereRecenzie,
               ValoareRecenzie = recenzie.ValoareRecenzie
            };

            await _connection.QueryAsync(storedProcedure, parameters , commandType : CommandType.StoredProcedure);
        }


        public async Task UpdateRecenzie(AddRecenzieRestaurant recenzie , int id)
        {
            string storedProcedure = "UpdateRecenzie";

            var parameters = new
            {
                IdRecenzie = id,
                TitluRecenzie = recenzie.TitluRecenzie,
                DescriereRecenzie = recenzie.DescriereRecenzie,
                ValoareRecenzie = recenzie.ValoareRecenzie
            };

            await _connection.QueryAsync(storedProcedure, parameters, commandType : CommandType.StoredProcedure);
        }

        public void DeleteRecenzie(int id)
        {
            string storedProcedure = "DeleteRecenzie";

            var parameters = new { IdRecenzie = id };
        
            _connection.Query(storedProcedure , parameters , commandType : CommandType.StoredProcedure);
        }

        public bool VerificaExistentaRecenzie(int IdUtilizator , int IdRestaurant)
        {
            string storedProcedure = "VerificaExistentaRecenzie";

            var parameters = new DynamicParameters();
            parameters.Add("IdUtilizator", IdUtilizator);
            parameters.Add("IdRestaurant", IdRestaurant);
            parameters.Add("Exist", DbType.Int32, direction: ParameterDirection.Output);

            _connection.Query(storedProcedure , parameters, commandType : CommandType.StoredProcedure);

            int Exist = parameters.Get<int>("Exist");

            if(Exist == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
