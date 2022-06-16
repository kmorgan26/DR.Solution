using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DRApplication.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HardwareConfigController : ControllerBase
    {
        DapperRepository<HardwareConfig> _manager;

        public HardwareConfigController(DapperRepository<HardwareConfig> manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<ActionResult<APIListOfEntityResponse<HardwareConfig>>> Get()
        {
            try
            {
                var result = await _manager.GetAllAsync();
                return Ok(new APIListOfEntityResponse<HardwareConfig>()
                {
                    Success = true,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                // log exception here
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost("getwithfilter")]
        public async Task<ActionResult<PagedResponse<HardwareConfig>>> GetWithFilter([FromBody] QueryFilter<HardwareConfig> Filter)
        {
            try
            {
                var result = await _manager.GetAsync(Filter);
                return Ok(new PagedResponse<HardwareConfig>()
                {
                    Success = true,
                    Data = result.Data
                });
            }
            catch (Exception ex)
            {
                // log exception here
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<APIEntityResponse<HardwareConfig>>> GetById(int Id)
        {
            try
            {
                var result = await _manager.GetByIdAsync(Id);
                if (result != null)
                {
                    return Ok(new APIEntityResponse<HardwareConfig>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<HardwareConfig>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>() { "HardwareConfig Not Found" },
                        Data = new HardwareConfig() { Id = 0 }
                    });
                }
            }
            catch (Exception ex)
            {
                // log exception here
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<APIEntityResponse<HardwareConfig>>> Insert([FromBody] HardwareConfig HardwareConfig)
        {
            try
            {
                HardwareConfig.Id = 0; // Make sure you do this!
                var result = await _manager.InsertAsync(HardwareConfig);

                if (result != null)
                {
                    return Ok(new APIEntityResponse<HardwareConfig>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<HardwareConfig>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>() { "Could not find Hardware Config after adding it." },
                        Data = new HardwareConfig() { Id = 0 }
                    });
                }
            }
            catch (Exception ex)
            {
                // log exception here
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<APIEntityResponse<HardwareConfig>>> Update([FromBody] HardwareConfig HardwareConfig)
        {
            try
            {
                var result = await _manager.UpdateAsync(HardwareConfig);
                if (result != null)
                {
                    return Ok(new APIEntityResponse<HardwareConfig>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<HardwareConfig>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>() { "Could not find Hardware Config after updating it." },
                        Data = new HardwareConfig() { Id = 0 }
                    });
                }
            }
            catch (Exception ex)
            {
                // log exception here
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<bool>> Delete(int Id)
        {
            try
            {
                return await _manager.DeleteByIdAsync(Id);
            }
            catch (Exception ex)
            {
                // log exception here
                var msg = ex.Message;
                return StatusCode(500);
            }
        }
    }
}
