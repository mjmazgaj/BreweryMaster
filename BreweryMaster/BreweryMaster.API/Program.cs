using BreweryMaster.API.Configuration.Helpers;
using BreweryMaster.API.Configuration.Models;
using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.User.Models.Users.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<OrderSettings>(builder.Configuration.GetSection(nameof(OrderSettings)));
builder.Services.Configure<WorkSettings>(builder.Configuration.GetSection(nameof(WorkSettings)));

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

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseExceptionHandlerWithOptions();

app.MapIdentityApi<ApplicationUser>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ReactPolicy");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();

//Added for test purposes
public partial class Program { }