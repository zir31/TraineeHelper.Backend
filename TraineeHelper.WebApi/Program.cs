using System.Reflection;
using TraineeHelper.Application;
using TraineeHelper.Application.Common.Mappings;
using TraineeHelper.Application.Interfaces;
using TraineeHelper.Persistence;
using Microsoft.Extensions.Configuration;
using TraineeHelper.WebApi.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication;
using IdentityServer4.AccessTokenValidation;
using IdentityModel;
using TraineeHelper.WebApi.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(ILearningSessionsDbContext).Assembly));
});
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});
//builder.Services.AddAuthentication(options =>
//{
//    //options.DefaultAuthenticateScheme =
//    //    JwtBearerDefaults.AuthenticationScheme;
//    //options.DefaultChallengeScheme =
//    //    JwtBearerDefaults.AuthenticationScheme;
//    //options.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
//    //options.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
//    //options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
//})
builder.Services.AddAuthentication("Bearer")
    //.AddIdentityServerAuthentication("Bearer", options =>
    //{
    //    options.ApiName = "traneeHelper_api_swagger";
    //    options.Authority = "https://localhost:7177";
    //    options.RequireHttpsMetadata = false;
    //})
    .AddJwtBearer("Bearer", config =>
    {
        config.Authority = "https://localhost:7177";
        config.Audience = "traneeHelper_api_swagger";
        config.RequireHttpsMetadata = false;
        config.MapInboundClaims = false;
    });

//builder.Services.AddAuthorization();
//.AddJwtBearer("Bearer", options =>
//{
//    options.Authority = "https://localhost:44352";
//    options.Audience = "TraineeHelperWebAPI";
//    options.RequireHttpsMetadata = false;
//});
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Protected TraineeHelper Web API", Version = "v1" });

    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri("https://localhost:7177/connect/authorize"),
                TokenUrl = new Uri("https://localhost:7177/connect/token"),
                Scopes = new Dictionary<string, string>
            {
                {"traineeAPI", "Demo API - full access"}
            }
            }
        }
    });
    //options.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    //{
    //    Type = SecuritySchemeType.Http,
    //    Scheme = "basic"
    //});
    //options.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "oauth2"
    //            },
    //            Scheme = "oauth2",
    //            Name = "Bearer",
    //            In = ParameterLocation.Header
    //        },
    //        new List<string>()
    //    }
    //});
    options.OperationFilter<AuthorizeCheckOperationFilter>();
});

    


var app = builder.Build();
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<LearningSessionsDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {

    }
}

app.UseCastomExceptionHandler();
app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAll");
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger UI Demo");
    options.DocumentTitle = "Test Title";
    options.OAuthClientId("traneeHelper_api_swagger");
    //options.OAuthClientSecret("client_secret_swagger");
    options.OAuthUsePkce();
});


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapGet("/", () => "Hello World!");

app.Run();
