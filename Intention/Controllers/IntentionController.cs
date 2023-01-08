using Business;
using Business.Interface;
using DTO.Models;
using Gridify;
using Intention.Base;
using Intention.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Intention.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IntentionController : IntentionBaseController
{
    private readonly IIntentionService _intentionService;

    public IntentionController(IIntentionService intention,
    ServiceResponse<object> serviceResponse)
    {
        this._intentionService = intention;
        ServiceResponse = serviceResponse ?? throw new ArgumentNullException(nameof(serviceResponse));
    }

    [HttpGet(ApiRoutes.GetAll)]
    public async Task<IActionResult> GetAllIntentions([FromQuery] GridifyQuery query)
    {
        var response = await _intentionService.GetChallengesAsync(query, Token);
        return !response.Success ? (IActionResult)BadRequest(response) : Ok(response);
    }

    [HttpGet(ApiRoutes.Get)]
    public async Task<IActionResult> GetIntention([FromRoute] int id)
    {
        var response = await _intentionService.GetChallenge(id, Token);
        return !response.Success ? (IActionResult)BadRequest(response) : Ok(response);
    }


    [HttpPost(ApiRoutes.Save), DisableRequestSizeLimit]
    public async Task<IActionResult> PostIntention([FromBody] ChallengeDto dto)
    {
        var response = await _intentionService.AddChallenge(dto, Token);
        return !response.Success ? (IActionResult)BadRequest(response) : Ok(response);
    }


    [HttpPut(ApiRoutes.Update)]
    public async Task<IActionResult> UpdateIntention([FromRoute] int id, [FromBody] ChallengeDto dto)
    {
        var response = await _intentionService.UpdateChallenge(id, dto, Token);
        return !response.Success ? (IActionResult)BadRequest(response) : Ok(response);
    }


    [HttpDelete(ApiRoutes.Delete)]
    public async Task<IActionResult> DeleteIntention([FromRoute] int id)
    {
        var response = await _intentionService.DeleteChallenge(id, Token);
        return !response.Success ? (IActionResult)BadRequest(response) : Ok(response);
    }
}
