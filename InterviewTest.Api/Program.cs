using InterviewTest.Api.Middlewares;
using InterviewTest.Core;
using InterviewTest.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureLayer();
builder.Services.AddCoreLayer();

builder.Services.AddControllers();

var app = builder.Build();
app.UseExceptionHandlingMiddleware();
app.UseRouting();

app.MapControllers();

app.Run();