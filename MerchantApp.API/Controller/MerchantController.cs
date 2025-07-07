using MediatR;
using MerchantApp.Application.Common;
using MerchantApp.Application.CQRS.Commands;
using MerchantApp.Application.CQRS.Queries;
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
    [Authorize]
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
}