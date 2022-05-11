using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models.ConfigurationModels;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DRApplication.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SoftwareSystemController : ControllerBase
    {
        DapperRepository<SoftwareSystem> _manager;

        public SoftwareSystemController(DapperRepository<SoftwareSystem> manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<ActionResult<APIListOfEntityResponse<SoftwareSystem>>> Get()
        {
            try
            {
                var result = await _manager.GetAllAsync();
                return Ok(new APIListOfEntityResponse<SoftwareSystem>()
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
        public async Task<ActionResult<PagedResponse<SoftwareSystem>>> GetWithFilter([FromBody] QueryFilter<SoftwareSystem> Filter)
        {
            try
            {
                var result = await _manager.GetAsync(Filter);
                return Ok(new PagedResponse<SoftwareSystem>()
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
        public async Task<ActionResult<APIEntityResponse<SoftwareSystem>>> GetById(int Id)
        {
            try
            {
                var result = await _manager.GetByIdAsync(Id);
                if (result != null)
                {
                    return Ok(new APIEntityResponse<SoftwareSystem>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<SoftwareSystem>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>() { "Software System Not Found" },
                        Data = new SoftwareSystem() { Id = 0 }
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
        public async Task<ActionResult<APIEntityResponse<SoftwareSystem>>> Insert([FromBody] SoftwareSystem softwareSystem)
        {
            try
            {
                softwareSystem.Id = 0; // Make sure you do this!
                var result = await _manager.InsertAsync(softwareSystem);

                if (result != null)
                {
                    return Ok(new APIEntityResponse<SoftwareSystem>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<SoftwareSystem>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>() { "Could not find Software System after adding it." },
                        Data = new SoftwareSystem() { Id = 0 }
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
        public async Task<ActionResult<APIEntityResponse<SoftwareSystem>>> Update([FromBody] SoftwareSystem softwareSystem)
        {
            try
            {
                var result = await _manager.UpdateAsync(softwareSystem);
                if (result != null)
                {
                    return Ok(new APIEntityResponse<SoftwareSystem>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<SoftwareSystem>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>() { "Could not find Software System after updating it." },
                        Data = new SoftwareSystem() { Id = 0 }
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
