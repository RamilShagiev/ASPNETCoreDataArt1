using ASPNETCoreDataArt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreDataArt.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger1;

        public ApiController(ILogger<ApiController> logger, DatabaseServices databaseHandler, DatabaseHandler databaceService)
        {
            this.DatabaseHandler = databaseHandler;
            this.DatabaseService = databaceService;
            _logger1 = logger;
        }

        public DatabaseServices DatabaseHandler { get; }
        public DatabaseHandler DatabaseService { get; }

        [HttpGet]
        [Route("getText")]
        public string GetText(DateTime date)
        {
            Response response = new Response();
            
            int searchID = DatabaseHandler.Transform(date);

            if(searchID < 0)
            {
                response.StatusCode = 101;
                response.ErrorMessage = " invalid input";
            }

            string textById = DatabaseService.GetTextById(searchID);


            if(textById != null)
            {
                return textById;
            }
            else
            {
                response.StatusCode = 100;
                response.ErrorMessage = " no data found";
                return (response.StatusCode + response.ErrorMessage);
            }
        }
    }
}
