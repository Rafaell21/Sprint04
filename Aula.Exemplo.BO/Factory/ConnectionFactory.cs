using System;
using System.Configuration;
using System.Data;
using Sistema.Arquitetura.Library.Data.DbClient;


namespace Aula.Exemplo.BO.Factory
{
    public static class ConnectionFactory
    {

        /// <summary>
        /// Get the IDbConnection Defaul./>.
        /// </summary>
        public static IDbConnection GetDbConnectionDefault()
        {
            //string connectionString = Config.Get("conn_string_default");
            string connectionString = ConfigurationManager.ConnectionStrings["conn_string_default"].ConnectionString;
            if (connectionString == null)
            {
                throw new ArgumentException("String de conexão 'conn_string_default' não encontrada.");
            }
            DbFactory db = new DbFactory(Sistema.Arquitetura.Library.Data.DbClient.DbType.MSSQL, connectionString);
            return db.DbConnection;
        }
    }
}
