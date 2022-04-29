using DRApplication.Server.Data;
using DRApplication.Shared.Models;
using DRApplication.Shared.Models.DeviceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DRApplication.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MaintainerController : ControllerBase
    {
        EFRepository<Maintainer, FSTSSDatabaseContext> _maintainerManager;

        public MaintainerController(EFRepository<Maintainer, FSTSSDatabaseContext> maintainerManager)
        {
            _maintainerManager = maintainerManager;
        }
        [HttpGet]
        public async Task<ActionResult<APIListOfEntityResponse<Maintainer>>> Get()
        {
            try
            {
                var result = await _maintainerManager.GetAllAsync();
                return Ok(new APIListOfEntityResponse<Maintainer>()
                {
                    Success = true,
                    Data = result
                });
            }
            catch (Exception)
            {
                return StatusCode(500);
                throw;
            }
        }

        [HttpPost("getwithfilter")]
        public async Task<ActionResult<APIListOfEntityResponse<Maintainer>>> GetWithFilter([FromBody] QueryFilter<Maintainer> Filter)
        {
            try
            {
                var result = await _maintainerManager.GetAsync(Filter);
                return Ok(new APIListOfEntityResponse<Maintainer>()
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

        [HttpGet("{Id}")]
        public async Task<ActionResult<APIEntityResponse<Maintainer>>> GetById(int Id)
        {
            try
            {
                var result = await _maintainerManager.GetByIdAsync(Id);
                if (result != null)
                {
                    return Ok(new APIEntityResponse<Maintainer>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<Maintainer>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>() { "Maintainer Not Found" },
                        Data = null
                    });
                }
            }
            catch (Exception ex)
            {
                // log exception here
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<APIEntityResponse<Maintainer>>> Insert([FromBody] Maintainer maintainer)
        {
            try
            {
                maintainer.Id = 0; // Make sure you do this!
                var result = await _maintainerManager.InsertAsync(maintainer);
                if (result != null)
                {
                    return Ok(new APIEntityResponse<Maintainer>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<Maintainer>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>(){ "Could not find maintainer after adding it." },
                        Data = null
                    });
                }
            }
            catch (Exception ex)
            {
                // log exception here
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<APIEntityResponse<Maintainer>>>
         Update([FromBody] Maintainer maintainer)
        {
            try
            {
                var result = await _maintainerManager.UpdateAsync(maintainer);
                if (result != null)
                {
                    return Ok(new APIEntityResponse<Maintainer>()
                    {
                        Success = true,
                        Data = result
                    });
                }
                else
                {
                    return Ok(new APIEntityResponse<Maintainer>()
                    {
                        Success = false,
                        ErrorMessages = new List<string>(){ "Could not find maintainer after updating it." },
                        Data = null
                    });
                }
            }
            catch (Exception ex)
            {
                // log exception here
                return StatusCode(500);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<bool>> Delete(int Id)
        {
            try
            {
                return await _maintainerManager.DeleteByIdAsync(Id);
            }
            catch (Exception ex)
            {
                // log exception here
                var msg = ex.Message;
                return StatusCode(500);
            }
        }

        [HttpGet("deleteall")]
        public async Task<ActionResult> DeleteAll()
        {
            try
            {
                await _maintainerManager.DeleteAllAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                // log exception here
                return StatusCode(500);
            }
        }

    }
}
