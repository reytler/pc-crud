using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crudpcapi.Controllers
{
    [Route("api/sujeito")]
    [ApiController]
    public class SujeitoController : BaseController
    {
        public SujeitoController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
