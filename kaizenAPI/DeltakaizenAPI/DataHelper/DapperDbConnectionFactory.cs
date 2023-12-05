using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelper
{
    public class DapperDbConnectionFactory : IDbConnectionFactory
    {
        private readonly IDictionary<ConnectionStrings, string> _connectionDict;

        public DapperDbConnectionFactory(IDictionary<ConnectionStrings, string> connectionDict)
        {
            _connectionDict = connectionDict;
        }

        public IDbConnection CreateDbConnection(ConnectionStrings connectionName)
        {
            string connectionString = null;
            if (_connectionDict.TryGetValue(connectionName, out connectionString))
            {
                return new SqlConnection(connectionString);
            }

            throw new ArgumentNullException();
        }
    }
}
