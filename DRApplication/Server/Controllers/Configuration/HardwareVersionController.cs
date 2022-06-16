using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DRApplication.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HardwareVersionController : ControllerBase
    {
        DapperRepository<HardwareVersion> _manager;

        public HardwareVersionController(DapperRepository<HardwareVersion> manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<ActionResult<APIListOfEntityResponse<HardwareVersion>>> Get()
        {
            try
            {
                var result = await _manager.GetAllAsync();
                return Ok(new APIListOfEntityResponse<HardwareVersion>()
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
        public async Task<ActionResult<PagedResponse<HardwareVersion>>> GetWithFilter([FromBody] QueryFilter<HardwareVersion> Filter)
        {
            try
            {
                var result = await _manager.GetAsync(Filter);
                return Ok(new PagedResponse<HardwareVersion>()
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
        public async Task<ActionResult<APIEntityResponse<HardwareVersion>>> GetById(int Id)
        {
            try
            {
                var result = await _manager.GetByIdAsync(Id);
                if (result != null)
                {
                    return Ok(new APIEntityResponse<HardwareVersion>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<HardwareVersion>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>() { "Hardware Version Not Found" },
                        Data = new HardwareVersion() { Id = 0 }
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
        public async Task<ActionResult<APIEntityResponse<HardwareVersion>>> Insert([FromBody] HardwareVersion HardwareVersion)
        {
            try
            {
                HardwareVersion.Id = 0; // Make sure you do this!
                var result = await _manager.InsertAsync(HardwareVersion);

                if (result != null)
                {
                    return Ok(new APIEntityResponse<HardwareVersion>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<HardwareVersion>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>() { "Could not find Hardware Version after adding it." },
                        Data = new HardwareVersion() { Id = 0 }
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
        public async Task<ActionResult<APIEntityResponse<HardwareVersion>>> Update([FromBody] HardwareVersion HardwareVersion)
        {
            try
            {
                var result = await _manager.UpdateAsync(HardwareVersion);
                if (result != null)
                {
                    return Ok(new APIEntityResponse<HardwareVersion>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<HardwareVersion>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>() { "Could not find Hardware Version after updating it." },
                        Data = new HardwareVersion() { Id = 0 }
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
