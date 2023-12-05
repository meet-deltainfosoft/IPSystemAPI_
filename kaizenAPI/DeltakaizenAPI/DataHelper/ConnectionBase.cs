using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelper
{
    public class ConnectionBase
    {
        public IDbConnection DbConnection { get; private set; }

        private IDbConnectionFactory _dbConnectionFactory;

        public ConnectionBase(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public IDbConnection GetDbConnection()
        {
            return _dbConnectionFactory.CreateDbConnection(ConnectionStrings.LiveConnectionString);
        }
    }
}
