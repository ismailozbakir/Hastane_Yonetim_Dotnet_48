using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hastane_Yonetim_Dotnet_48
{
    internal class SqlBaglantisi
    {
        public SqlConnection Baglanti()
        {
            string connectionString = @"Data Source=DESKTOP-5FTUGTC\SQLEXPRESS;Initial Catalog=HastaneProjesi;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            return connection;
        }
    }
}
