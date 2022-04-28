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

        // GET: /<HardwareConfigController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var result = await _manager.dbSet
                    .Include(i => i.DeviceType)
                    .AsNoTracking()
                    .ToListAsync();

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

        // GET /<HardwareConfigController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByHardwareConfigId(int id)
        {
            try
            {
                var result = await _manager.dbSet
                    .Where(x => x.Id == id)
                    .Include(i => i.DeviceType)
                    .FirstOrDefaultAsync();

                if (result != null)
                {
                    return Ok(new Response<HardwareConfig>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new Response<HardwareConfig>()
                    {
                        Success = false,
                        ErrorMessage = new List<string>() { "HardwareConfig Not Found" },
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
        public async Task<IActionResult> PostAsync([FromBody] HardwareConfig item)
        {
            try
            {
                await _manager.AddAsync(item);
                var result = await _manager.dbSet
                    .Where(i => i.Id == item.Id)
                    .FirstOrDefaultAsync();

                if (result != null)
                {
                    return Ok(new Response<HardwareConfig>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new Response<HardwareConfig>()
                    {
                        Success = false,
                        ErrorMessage = new List<string>() { "Could not find the Hardware Config After Adding it. " },
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
        public async Task<IActionResult> Update([FromBody] HardwareConfig hardwareConfig)
        {
            try
            {
                await _manager.UpdateAsync(hardwareConfig);

                var result = await _manager.dbSet
                    .Where(i => i.Id == hardwareConfig.Id)
                    .FirstOrDefaultAsync();

                if (result != null)
                {
                    return Ok(new Response<HardwareConfig>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new Response<HardwareConfig>()
                    {
                        Success = false,
                        ErrorMessage = new List<string>() { "Could not find the Poc after updating it" },
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

        // DELETE api/<DeviceTypeController>/5
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
