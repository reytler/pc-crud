using crudpcapi.Domains;
using crudpcapi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace crudpcapi.Controllers;

public abstract class BaseController : ControllerBase
{
    protected IServiceProvider _serviceProvider;

    public BaseController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [HttpGet("working")]
    public string Working()
    {
        return "working";
    }

    protected async Task<IActionResult> EncapsularChamadaDomain(Func<Task<IActionResult>> func)
    {
        try
        {
            return await func();
        } catch (NotFoundException e)
        {
            return NotFound(e.CompleteErroMessage());
        } catch (BadRequestException e)
        {
            return BadRequest(e.CompleteErroMessage());
        }catch (ForbiddenException e)
        {
            return StatusCode(403, e.CompleteErroMessage());
        }catch(ExternalApiException e)
        {
            return StatusCode(e.StatusCode, e.CompleteErroMessage());
        }catch(Exception e)
        {
            return StatusCode(500, e.CompleteErroMessage());
        }
    }
}
