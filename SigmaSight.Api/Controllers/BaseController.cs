using SigmaSight.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SigmaSight.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IEnvironmentService EnvironmentService;
        
        public BaseController()
        { }

        public BaseController(IEnvironmentService environmentService)
        {
            EnvironmentService = environmentService;
        }

    }
}
