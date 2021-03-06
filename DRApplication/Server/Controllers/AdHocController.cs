using Dapper;
using DRApplication.Shared.Requests;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DRApplication.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdHocController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AdHocController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("listofvms")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetAdHocResult([FromBody] AdhocRequest adhocRequest)
        {
            try
            {
                using var connection = new SqlConnection(_configuration.GetConnectionString("DRConnectionString"));
                string query = adhocRequest.Query;
                var parameters = adhocRequest.Parameters;
                var dbArgs = new DynamicParameters();
                foreach (var pair in parameters) dbArgs.Add(pair.Key, pair.Value);

                var deviceTypeVms = await connection.QueryAsync<dynamic>(query, dbArgs);
                return Ok(new APIListOfEntityResponse<dynamic>()
                {
                    Success = true,
                    Data = deviceTypeVms
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            

        }
    }
}
