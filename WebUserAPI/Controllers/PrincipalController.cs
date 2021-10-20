using Domain;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebUserAPI.Model;
using WebUserAPI.Services;

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
        [Produces(typeof(WebUserAPI.Model.Principal))]
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

        [HttpPatch("{id}")]
        public IActionResult JoinToGroup(Guid id, [FromBody] PatchPrincipalCommand command)
        {
            command.Id = id;
            switch (command.Order)
            {
                case PrincipalPatchType.ChangeName:
                    principalService.UpdatePrincipal(command);
                    return Ok(id);
                case PrincipalPatchType.JoinToGroup:
                    principalService.PrincipalJoinsToGroup(command);
                    return Ok();
                case PrincipalPatchType.LeaveGroup:
                    principalService.PrincipalLeavesGroup(command);
                    return Ok();
                case PrincipalPatchType.AssignParty:
                    principalService.AssignParty(command);
                    return Ok();
            }
            return NotFound("set the order in your command");
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
