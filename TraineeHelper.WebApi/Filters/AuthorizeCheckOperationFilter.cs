using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TraineeHelper.WebApi.Filters;

public class AuthorizeCheckOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        //var hasAuthorize =
        //  context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any()
        //  || context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

        //if (hasAuthorize)
        //{
        //    operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
        //    operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });
        
        if (!context.ApiDescription
            .ActionDescriptor
            .EndpointMetadata
            .OfType<AuthorizeAttribute>()
            .Any())
        {
            return;
        }

        operation.Security = new List<OpenApiSecurityRequirement>
        {
            new OpenApiSecurityRequirement
            {
                    [
                        new OpenApiSecurityScheme {Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "basic"}
                        }
                    ] = new[] {"api1"}
            }
        };

    }
}

