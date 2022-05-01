using DRApplication.Server.Data;
using DRApplication.Shared.Models;
using DRApplication.Shared.Models.DeviceModels;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DRApplication.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeviceTypeController : ControllerBase
    {
        EFRepository<DeviceType, FSTSSDatabaseContext> _manager;

        public DeviceTypeController(EFRepository<DeviceType, FSTSSDatabaseContext> manager)
        {
            _manager = manager;
        }

        // GET: /<DeviceTypeController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var result = await _manager.dbSet
                    //.Include(i => i.Maintainer)
                    .AsNoTracking()
                    .ToListAsync();

                return Ok(new PagedResponse<DeviceType>(result)
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
                var msg = ex.Message;
                return StatusCode(500);
            }
        }

        // GET /<DeviceTypeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByMaintainerId(int id)
        {
            try
            {
                var result = await _manager.dbSet
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (result != null)
                {
                    return Ok(new Response<DeviceType>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new Response<DeviceType>()
                    {
                        Success = false,
                        ErrorMessage = new List<string>() { "Device Type Not Found" },
                        Data = null
                    });
                }
            }
            catch (Exception)
            {
                //TODO: Log the exception
                return StatusCode(500);
            }
        }

        // POST /<DeviceTypeController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DeviceType deviceType)
        {
            try
            {
                await _manager.InsertAsync(deviceType);
                var result = await _manager.dbSet
                    .Where(i => i.Id == deviceType.Id)
                    .FirstOrDefaultAsync();

                if (result != null)
                {
                    return Ok(new Response<DeviceType>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new Response<DeviceType>()
                    {
                        Success = false,
                        ErrorMessage = new List<string>() { "Could not find the Device Type After Adding it. " },
                        Data = null
                    });
                }
            }
            catch (Exception)
            {
                //TODO: Log the exception
                return StatusCode(500);
            }
        }

        // PUT /<DeviceTypeController>/5
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DeviceType deviceType)
        {
            try
            {
                await _manager.UpdateAsync(deviceType);

                var result = await _manager.dbSet
                    .Where(i => i.Id == deviceType.Id)
                    .FirstOrDefaultAsync();

                if (result != null)
                {
                    return Ok(new Response<DeviceType>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new Response<DeviceType>()
                    {
                        Success = false,
                        ErrorMessage = new List<string>() { "Could not find the Device Type after updating it" },
                        Data = null
                    });
                }
            }
            catch (Exception)
            {
                // TODO: Log it
                return StatusCode(500);
            }
        }

        // DELETE /<DeviceTypeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var list = await _manager.dbSet
                    .Where(i => i.Id == id)
                    .ToListAsync();

                if (list != null)
                {
                    var item = list.First();
                    var success = await _manager.DeleteAsync(item);
                    if (success)
                        return NoContent();
                    else
                        return StatusCode(500);
                }
                else
                    return StatusCode(500);
            }
            catch (Exception)
            {
                // TODO: Log it
                return StatusCode(500);
                throw;
            }
        }
    }
}
