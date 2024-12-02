using BreweryMaster.API.Order.Models.Settings;
using BreweryMaster.API.Order.Services;
using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.User.Models;
using BreweryMaster.API.User.Services;
using BreweryMaster.API.Work.Models;
using BreweryMaster.API.Work.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<OrderSettings>(builder.Configuration.GetSection(nameof(OrderSettings)));

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BreweryMaster")));
builder.Services.AddDbContext<WorkDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BreweryMaster")));

builder.Services.AddScoped<IAddressService,AddressService>();
builder.Services.AddScoped<IProspectClientService, ProspectClientService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddAuthentication()
                .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddApiEndpoints();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapIdentityApi<ApplicationUser>();

app.UseCors("ReactPolicy");

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

app.UseAuthorization();

app.MapControllers();

app.Run();
