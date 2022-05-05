using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models.DeviceModels;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DRApplication.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeviceTypeController : ControllerBase
    {
        DapperRepository<DeviceType> _manager;

        public DeviceTypeController(DapperRepository<DeviceType> manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<ActionResult<APIListOfEntityResponse<DeviceType>>> Get()
        {
            try
            {
                var result = await _manager.GetAllAsync();
                return Ok(new APIListOfEntityResponse<DeviceType>()
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
        public async Task<ActionResult<APIListOfEntityResponse<DeviceType>>> GetWithFilter([FromBody] QueryFilter<DeviceType> Filter)
        {
            try
            {
                var result = await _manager.GetAsync(Filter);
                return Ok(new APIListOfEntityResponse<DeviceType>()
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
        public async Task<ActionResult<APIEntityResponse<DeviceType>>> GetById(int Id)
        {
            try
            {
                var result = await _manager.GetByIdAsync(Id);
                if (result != null)
                {
                    return Ok(new APIEntityResponse<DeviceType>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<DeviceType>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>() { "Customer Not Found" },
                        Data = new DeviceType() { Id = 0 }
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
        public async Task<ActionResult<APIEntityResponse<DeviceType>>> Insert([FromBody] DeviceType DeviceType)
        {
            try
            {
                DeviceType.Id = 0; // Make sure you do this!
                var result = await _manager.InsertAsync(DeviceType);

                if (result != null)
                {
                    return Ok(new APIEntityResponse<DeviceType>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<DeviceType>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>(){ "Could not find Device Type after adding it." },
                        Data = new DeviceType() { Id = 0 }
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
        public async Task<ActionResult<APIEntityResponse<DeviceType>>> Update([FromBody] DeviceType DeviceType)
        {
            try
            {
                var result = await _manager.UpdateAsync(DeviceType);
                if (result != null)
                {
                    return Ok(new APIEntityResponse<DeviceType>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<DeviceType>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>(){ "Could not find customer after updating it." },
                        Data = new DeviceType() { Id= 0 }
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
