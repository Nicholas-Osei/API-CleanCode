using System;
using Core_Application_Domain.CQRS.Command;
using Core_Application_Domain.CQRS.Query;
using Core_Application_Domain.Model;
using Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace LearnNico_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IMediator mediator;
        public PlayerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await mediator.Send(new GetAllPlayersQuery()));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetPlayer(int id)
        {
            return Ok(await mediator.Send(new GetPlayerByIdQuery() { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer([FromBody] Player player)
        {
   
            return Created("", await mediator.Send(new AddPlayerCommand() { PlayerToAdd = player }));
        }
        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePlayer(int id,[FromBody] GetAllPlayersVM player)
        {
            
            return Ok(await mediator.Send(new UpdatePlayerCommand() { PlayerToUpdate = player,ID=id}));
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePlayer(int id)
        {

            return Ok(await mediator.Send(new DeletePlayerCommand() {Id = id }));
        }
    }
}

