using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleFinance.Application.Commands.WalletCommands;
using SimpleFinance.Application.DTO;
using SimpleFinance.Application.Queries.WalletQueries;

namespace SimpleFinance.Api.Controllers;

public class WalletController : BaseController
{
    [HttpGet("{id:guid}")]  
    public async Task<ActionResult<WalletDto>> Get([FromRoute] GetWallet query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WalletDto>>> Get([FromQuery] SearchWallet query)
    {
        var result = await Mediator.Send(query);

        return OkOrNotFound(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateWallet command)
    {
        await Mediator.Send(command);

        return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
    }

    [HttpPut("{objectId:guid}/items")]
    public async Task<IActionResult> Put([FromBody] AddWalletItem command)
    {
        await Mediator.Send(command);

        return Ok();
    }
}
