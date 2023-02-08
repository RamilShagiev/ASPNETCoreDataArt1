using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ASPNETCoreDataArt.Models
{
    public class DatabaseHandler
    {
        public readonly IConfiguration _configuration;

        public DatabaseHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetTextById(int searchID)
        {

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DatabaseConnectionString").ToString());

            // if you need to return more rows: change to "SELECT * FROM TestDatabase" and add data to a list. 

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + _configuration.GetConnectionString("TableName").ToString() + " WHERE id = " + searchID, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            TextFromDatabase text = new TextFromDatabase();

            if (dt.Rows.Count > 0)
            {
                text.MyProperty = Convert.ToString(dt.Rows[0]["data"]);
            }

            return text.MyProperty;
        }
    }
}
