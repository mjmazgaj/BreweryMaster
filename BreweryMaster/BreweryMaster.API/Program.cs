using BreweryMaster.API.Configuration.Helpers;
using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.User.Models.Users.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<OrderSettings>(builder.Configuration.GetSection(nameof(OrderSettings)));

builder.Services.AddDbContextWithOptions(builder.Configuration.GetConnectionString("BreweryMaster"));

builder.Services.RegisterDependencies();

builder.Services.AddAuthentication()
                .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCoreWithOptions();

builder.Services.AddCorsWithOptions();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGenWithOptions();

builder.Services.AddHttpContextAccessor();

Log.Logger = ConfigurationHelper.GetLogger();

builder.Host.UseSerilog();

var app = builder.Build();
app.UseCors("ReactPolicy");

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseExceptionHandlerWithOptions();

app.MapIdentityApi<ApplicationUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
