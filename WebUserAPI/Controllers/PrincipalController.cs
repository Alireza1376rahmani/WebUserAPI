using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserAPI.Domain;
using WebUserAPI.Model;

namespace WebUserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrincipalController : ControllerBase
    {

        private readonly ILogger<PrincipalController> _logger;
        private readonly IPrincipalService principalService;

        public PrincipalController(ILogger<PrincipalController> logger, IPrincipalService principalService)
        {
            _logger = logger;
            this.principalService = principalService;
        }

        [HttpGet]
        public IEnumerable<Principal> Get()
        {
            return principalService.GetAllPrincipals();
        }

        [HttpPost]
        public void Create([FromBody] CreatePrincipalCommand command) 
        {
            
        }
    }
}
