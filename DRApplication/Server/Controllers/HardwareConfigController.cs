using DRApplication.Server.Data;
using DRApplication.Shared.Models;
using DRApplication.Shared.Models.ConfigurationModels;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DRApplication.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HardwareConfigController : ControllerBase
    {
        RepositoryEF<HardwareConfig, FSTSSDatabaseContext> _manager;

        public HardwareConfigController(RepositoryEF<HardwareConfig, FSTSSDatabaseContext> manager)
        {
            _manager = manager;
        }

        // GET: api/<HardwareConfigController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var result = await _manager.GetAllAsync();

                return Ok(new PagedResponse<HardwareConfig>(result)
                {
                    Success = true,
                    Data = result
                });
            }
            catch (Exception)
            {
                //TODO: Log Exception
                return StatusCode(500);
            }
        }
    }
}
