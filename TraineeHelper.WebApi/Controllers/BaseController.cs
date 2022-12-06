using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TraineeHelper.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => 
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    internal Guid TraineeId => !User.Identity.IsAuthenticated
        ? Guid.Empty
        : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
}
