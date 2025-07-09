using MediatR;
using MerchantApp.Application.Common;
using MerchantApp.Application.CQRS.Commands;
using MerchantApp.Application.CQRS.Queries;
using MerchantApp.Application.CQRS.Wrapper;
using MerchantApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MerchantApp.API.Controller;


[ApiController]
[Route("api/merchants")]
public class MerchantController(IMediator mediator) : BaseControllerV1
{
    private readonly IMediator _mediator = mediator;
    // [Authorize]
    [HttpGet]
    [ProducesResponseType<ApiResponse<List<Merchant>>>(200)]
    [SwaggerOperation(Summary = "Merchants", Description = "Get all merchants")]
    public async Task<IActionResult> GetAllMerchants()
    {
        ApiResponse<List<Merchant>> result = await _mediator.Send(new GetAllMerchantsQuery());
        return HandleResponse(result);
    }

    [HttpPost]
    [ProducesResponseType<ApiResponse<Merchant>>(201)]
    [ProducesResponseType<ApiResponse<string>>(400)]
    [SwaggerOperation(Summary = "Create Merchant", Description = "Creates a new merchant")]
    public async Task<IActionResult> CreateMerchant([FromBody] CreateMerchantCommand command)
    {
        ApiResponse<Merchant> result = await _mediator.Send(command);
        return HandleResponse(result);
    }


    [HttpGet("{id}")]
    [ProducesResponseType<ApiResponse<Merchant>>(200)]
    [ProducesResponseType<ApiResponse<string>>(400)]
    [SwaggerOperation(Summary = "Get Merchant By Id", Description = "Gets a merchant based on merchant id")]
    public async Task<IActionResult> GetMerchantById(string id)
    {
        var query = new GetMerchantByIdQuery { Id = id };

        ApiResponse<Merchant> result = await _mediator.Send(query);
        return HandleResponse(result);
    }


    [HttpDelete("{id}")]
    [ProducesResponseType<ApiResponse<string>>(200)]
    [ProducesResponseType<ApiResponse<string>>(400)]
    [SwaggerOperation(Summary = "Delete Merchant", Description = "Delete merchant based on merchant id")]
    public async Task<IActionResult> DeleteMerchant(string id)
    {
        var query = new DeleteMerchantCommand(id);

        ApiResponse<string> result = await _mediator.Send(query);
        return HandleResponse(result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType<ApiResponse<Merchant>>(200)]
    [ProducesResponseType<ApiResponse<string>>(400)]
    [SwaggerOperation(Summary = "Update Merchant", Description = "Update merchant details")]
    public async Task<IActionResult> UpdateMerchant(string id, [FromBody] UpdateMerchantCommand command)
    {
        var result = await _mediator.Send(new MerchantUpdateWrapper(id, command));
        return HandleResponse(result);
    }
}