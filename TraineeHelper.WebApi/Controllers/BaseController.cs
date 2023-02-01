using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TraineeHelper.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BaseController : ControllerBase
{
    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }
    //TODO Change to concrete 
    protected IMediator _mediator;

    // TODO validate
    internal Guid TraineeId => !User.Identity??= 
        ? Guid.Empty
        //: Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        //TODO change this placeholder
        : Guid.Parse(User.FindFirstValue("sub"));
}
