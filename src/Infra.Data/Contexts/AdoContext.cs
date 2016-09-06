using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infra.Data.Contexts
{
    public class AdoContext
    {
        private SqlConnection _connection;

        public SqlConnection CreateConnection()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            return _connection;
        }

        private readonly SqlParameterCollection _sqlParameterCollection = new SqlCommand().Parameters;

        private SqlCommand CreateCommand(CommandType cmdType, string cmdSql)
        {
            _connection = CreateConnection();
            _connection.Open();
            var cmd = _connection.CreateCommand();
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdSql;
            cmd.CommandTimeout = 7200;
            foreach (SqlParameter sqlParameter in _sqlParameterCollection)
            {
                cmd.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
            }

            return cmd;
        }

        protected void AddParameters(string parameterName, object value)
        {
            _sqlParameterCollection.AddWithValue(parameterName, value);
        }

        protected void ClearParameters()
        {
            _sqlParameterCollection.Clear();
        }

        protected SqlDataReader ExecuteQuery(CommandType cmdType, string cmdSql)
        {

            var cmd = CreateCommand(cmdType, cmdSql);
            var dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
