﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUserAPI.Model;
using WebUserAPI.Services;

namespace WebUserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PartyController : ControllerBase
    {
        private readonly IPartyService partyService;

        public PartyController(IPartyService partyService)
        {
            this.partyService = partyService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var parties = partyService.GetAllParties();
            if (parties.Count == 0)
                return NotFound();
            return Ok(parties);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id, [FromBody] ReadPartyCommand command)
        {
            command.Id = id;
            return Ok(partyService.GetPartyById(command));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePartyCommand command)
        {
            return Ok(partyService.CreateParty(command));
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateName(Guid id,[FromBody] PatchPartyCommand command)
        {
            command.Id = id;
            partyService.UpdatePartyName(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Replace(Guid id, [FromBody] PutPartyCommand command)
        {
            command.Id = id;
            partyService.Update(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id , [FromBody] DeletePartyCommand command)
        {
            command.Id = id;
            partyService.DeleteParty(command);
            return Ok();
        }
    }
}