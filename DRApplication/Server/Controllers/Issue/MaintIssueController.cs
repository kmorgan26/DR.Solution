using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
namespace DRApplication.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class MaintIssueController : ControllerBase
{
    DapperRepository<MaintIssue> _manager;

    public MaintIssueController(DapperRepository<MaintIssue> manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<ActionResult<APIListOfEntityResponse<MaintIssue>>> Get()
    {
        try
        {
            var result = await _manager.GetAllAsync();
            return Ok(new APIListOfEntityResponse<MaintIssue>()
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
    public async Task<ActionResult<PagedResponse<MaintIssue>>> GetWithFilter([FromBody] QueryFilter<MaintIssue> Filter)
    {
        try
        {
            var result = await _manager.GetAsync(Filter);

            var response = new PagedResponse<MaintIssue>()
            {
                Success = true,
                Data = result.Data,
                TotalRecords = result.TotalRecords,
                PageSize = result.PageSize,
                TotalPages = result.TotalPages,
                PageNumber = result.PageNumber,
                PreviousPage = result.PreviousPage,
                NextPage = result.NextPage
            };

            return Ok(response);

        }
        catch (Exception ex)
        {
            // log exception here
            Console.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<APIEntityResponse<MaintIssue>>> GetById(int Id)
    {
        try
        {
            var result = await _manager.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(new APIEntityResponse<MaintIssue>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<MaintIssue>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Maint Issue Not Found" },
                    Data = new MaintIssue() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<MaintIssue>>> Insert([FromBody] MaintIssue MaintIssue)
    {
        try
        {
            MaintIssue.Id = 0; // Make sure you do this!
            var result = await _manager.InsertAsync(MaintIssue);

            if (result != null)
            {
                return Ok(new APIEntityResponse<MaintIssue>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<MaintIssue>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find Maint Issue after adding it." },
                    Data = new MaintIssue() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<MaintIssue>>> Update([FromBody] MaintIssue MaintIssue)
    {
        try
        {
            var result = await _manager.UpdateAsync(MaintIssue);
            if (result != null)
            {
                return Ok(new APIEntityResponse<MaintIssue>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<MaintIssue>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find Maint Issue after updating it." },
                    Data = new MaintIssue() { Id = 0 }
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
