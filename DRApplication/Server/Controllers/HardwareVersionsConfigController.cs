using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models.ConfigurationModels;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DRApplication.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HardwareVersionsConfigController : ControllerBase
    {
        DapperRepository<HardwareVersionsConfig> _manager;

        public HardwareVersionsConfigController(DapperRepository<HardwareVersionsConfig> manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<ActionResult<APIListOfEntityResponse<HardwareVersionsConfig>>> Get()
        {
            try
            {
                var result = await _manager.GetAllAsync();
                return Ok(new APIListOfEntityResponse<HardwareVersionsConfig>()
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
        public async Task<ActionResult<APIListOfEntityResponse<HardwareVersionsConfig>>> GetWithFilter([FromBody] QueryFilter<HardwareVersionsConfig> Filter)
        {
            try
            {
                var result = await _manager.GetAsync(Filter);
                return Ok(new APIListOfEntityResponse<HardwareVersionsConfig>()
                {
                    Success = true,
                    Data = result.ToList()
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
        public async Task<ActionResult<APIEntityResponse<HardwareVersionsConfig>>> GetById(int Id)
        {
            try
            {
                var result = await _manager.GetByIdAsync(Id);
                if (result != null)
                {
                    return Ok(new APIEntityResponse<HardwareVersionsConfig>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<HardwareVersionsConfig>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>() { "Hardware Version/Config Not Found" },
                        Data = new HardwareVersionsConfig() { Id = 0 }
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
        public async Task<ActionResult<APIEntityResponse<HardwareVersionsConfig>>> Insert([FromBody] HardwareVersionsConfig HardwareVersionsConfig)
        {
            try
            {
                HardwareVersionsConfig.Id = 0; // Make sure you do this!
                var result = await _manager.InsertAsync(HardwareVersionsConfig);

                if (result != null)
                {
                    return Ok(new APIEntityResponse<HardwareVersionsConfig>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<HardwareVersionsConfig>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>() { "Could not find Hardware Version/Config after adding it." },
                        Data = new HardwareVersionsConfig() { Id = 0 }
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
        public async Task<ActionResult<APIEntityResponse<HardwareVersionsConfig>>> Update([FromBody] HardwareVersionsConfig HardwareVersionsConfig)
        {
            try
            {
                var result = await _manager.UpdateAsync(HardwareVersionsConfig);
                if (result != null)
                {
                    return Ok(new APIEntityResponse<HardwareVersionsConfig>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<HardwareVersionsConfig>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>() { "Could not find Hardware Version/Config after updating it." },
                        Data = new HardwareVersionsConfig() { Id = 0 }
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
