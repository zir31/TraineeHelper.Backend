using System.Reflection;
using TraineeHelper.Application;
using TraineeHelper.Application.Common.Mappings;
using TraineeHelper.Application.Interfaces;
using TraineeHelper.Persistence;
using Microsoft.Extensions.Configuration;
using TraineeHelper.WebApi.Middleware;

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
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapGet("/", () => "Hello World!");

app.Run();
