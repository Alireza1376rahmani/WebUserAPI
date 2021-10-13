using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
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
        public IActionResult Get()
        {
            var principals = principalService.GetAllPrincipals();
            if (principals.Count == 0) return NotFound();
            return Ok(principals);
        }

        [HttpGet("{id}")]
        [Produces(typeof(Principal))]
        public IActionResult Get(Guid id)
        {
            var command = new ReadPrincipalCommand { Id = id };
            var principal = principalService.GetPrincipalById(command);
            if (principal == null) return NotFound();
            return Ok(principal);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePrincipalCommand command)
        {
            var guid = principalService.CreatePrincipal(command);
            return Ok(guid);
        }

        [HttpPut("join")]
        public IActionResult Update([FromBody] PrincipalJoinsToGroupCommand command)
        {
            principalService.PrincipalJoinsToGroup(command);
            return Ok();
        }

        [HttpPut("leave")]
        public IActionResult Update([FromBody] PrincipalLeavesGroupCommand command)
        {
            principalService.PrincipalJoinsToGroup(command);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdatePrincipalCommand command)
        {
            principalService.UpdatePrincipal(command);
            return Ok(command.Id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var command = new DeletePrincipalCommand { Id = id };
            principalService.DeletePrincipal(command);
            return Ok();
        }

    }
}
