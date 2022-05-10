using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models.ConfigurationModels;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DRApplication.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HardwareSystemController : ControllerBase
    {
        DapperRepository<HardwareSystem> _manager;

        public HardwareSystemController(DapperRepository<HardwareSystem> manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<ActionResult<APIListOfEntityResponse<HardwareSystem>>> Get()
        {
            try
            {
                var result = await _manager.GetAllAsync();
                return Ok(new APIListOfEntityResponse<HardwareSystem>()
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
        public async Task<ActionResult<PagedResponse<HardwareSystem>>> GetWithFilter([FromBody] QueryFilter<HardwareSystem> Filter)
        {
            try
            {
                var result = await _manager.GetAsync(Filter);
                return Ok(new APIListOfEntityResponse<HardwareSystem>()
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
        public async Task<ActionResult<APIEntityResponse<HardwareSystem>>> GetById(int Id)
        {
            try
            {
                var result = await _manager.GetByIdAsync(Id);
                if (result != null)
                {
                    return Ok(new APIEntityResponse<HardwareSystem>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<HardwareSystem>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>() { "Hardware System Not Found" },
                        Data = new HardwareSystem() { Id = 0 }
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
        public async Task<ActionResult<APIEntityResponse<HardwareSystem>>> Insert([FromBody] HardwareSystem HardwareSystem)
        {
            try
            {
                HardwareSystem.Id = 0; // Make sure you do this!
                var result = await _manager.InsertAsync(HardwareSystem);

                if (result != null)
                {
                    return Ok(new APIEntityResponse<HardwareSystem>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<HardwareSystem>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>() { "Could not find Hardware System after adding it." },
                        Data = new HardwareSystem() { Id = 0 }
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
        public async Task<ActionResult<APIEntityResponse<HardwareSystem>>> Update([FromBody] HardwareSystem HardwareSystem)
        {
            try
            {
                var result = await _manager.UpdateAsync(HardwareSystem);
                if (result != null)
                {
                    return Ok(new APIEntityResponse<HardwareSystem>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<HardwareSystem>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>() { "Could not find Hardware System after updating it." },
                        Data = new HardwareSystem() { Id = 0 }
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
