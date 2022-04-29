using DRApplication.Server.Data;
using DRApplication.Shared.Models;
using DRApplication.Shared.Models.DeviceModels;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DRApplication.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        RepositoryEF<Device, FSTSSDatabaseContext> _manager;

        public DeviceController(RepositoryEF<Device, FSTSSDatabaseContext> manager)
        {
            _manager = manager;
        }

        // GET: /<DeviceController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var result = await _manager.dbSet
                    .Include(i => i.DeviceType)
                    .AsNoTracking()
                    .ToListAsync();

                return Ok(new PagedResponse<Device>(result)
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

        // GET /<DeviceController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByDeviceId(int id)
        {
            try
            {
                var result = await _manager.dbSet
                    .Where(x => x.Id == id)
                    .Include(i => i.DeviceType)
                    .FirstOrDefaultAsync();

                if (result != null)
                {
                    return Ok(new Response<Device>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new Response<Device>()
                    {
                        Success = false,
                        ErrorMessage = new List<string>() { "Device Not Found" },
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

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Device item)
        {
            try
            {
                await _manager.AddAsync(item);
                var result = await _manager.dbSet
                    .Where(i => i.Id == item.Id)
                    .FirstOrDefaultAsync();

                if (result != null)
                {
                    return Ok(new Response<Device>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new Response<Device>()
                    {
                        Success = false,
                        ErrorMessage = new List<string>() { "Could not find the Device After Adding it. " },
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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Device device)
        {
            try
            {
                await _manager.UpdateAsync(device);

                var result = await _manager.dbSet
                    .Where(i => i.Id == device.Id)
                    .FirstOrDefaultAsync();

                if (result != null)
                {
                    return Ok(new Response<Device>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new Response<Device>()
                    {
                        Success = false,
                        ErrorMessage = new List<string>() { "Could not find the Device after updating it" },
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

        // DELETE api/<DeviceController>/5
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
