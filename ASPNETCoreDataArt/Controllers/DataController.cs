using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ASPNETCoreDataArt.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ASPNETCoreDataArt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        
        public DataController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetData")]
        
        // Transform date to ID

        public int Transform(DateTime date)
        {

            // FORMULA START

            DateTime firstDay = new DateTime(2023, 1, 1);
            TimeSpan daysHavePassed = date - firstDay;

            int transformResult = daysHavePassed.Days;

            // FORMULA END

            return transformResult;
        }

        // Find data with ID and return it

        public string GetData(int searchID)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DataConnectionString").ToString());

            // if you need to return more rows: change to SELECT * FROM TestDatabase and add some of them to list. 

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + _configuration.GetConnectionString("DatabaseName").ToString() + " WHERE ID = " + searchID, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Response response = new Response();

            TextFromDatabase text = new TextFromDatabase();
            if (dt.Rows.Count > 0)
            {   
                text.MyProperty = Convert.ToString(dt.Rows[0]["data"]);
                
                //If you want return more rows from database:

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{                    
                //    
                //}
                
            }

            if(text.MyProperty != null)
            {
                return text.MyProperty; 
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = "No data found";
                return (response.StatusCode + response.ErrorMessage);
            }
        }
    }
}
