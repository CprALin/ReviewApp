using System.Data;
using System.Data.SqlClient;

namespace recenziiBack.Infrastructure
{
    public class DBconnection
    {
        public DBconnection()
        {

        }

        public IDbConnection ConnectToDB()
        {
            string connectionString = @"Server=daw23MSSQL;Database=RecenziiRestaurante;User Id=sa;Password=Ovidius.23;TrustServerCertificate=true";

            IDbConnection connection = new SqlConnection(connectionString);

            connection.Open();

            return connection;
        }
    }
}
