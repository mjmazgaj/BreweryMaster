using BreweryMaster.API.WorkModule.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

public class BaseTestController : IDisposable
{
    protected readonly HttpClient Client;
    protected readonly Mock<ITaskService> MockTaskService;
    private readonly WebApplicationFactory<Program> ApplicationFactory;

    public BaseTestController()
    {
        this.MockTaskService = new Mock<ITaskService>();

        this.ApplicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(
            builder => builder
            .UseEnvironment("integrationtests")
            .ConfigureTestServices(services =>
            {
                services.AddSingleton(this.MockTaskService.Object);

                services.AddAuthentication("TestAuth")
                    .AddScheme<TestAuthOptions, TestAuthHandler>("TestAuth", options => { });

                services.AddAuthorization(options =>
                {
                    options.AddPolicy("DefaultPolicy", policy => policy.RequireAuthenticatedUser());
                });

                services.Configure<MvcOptions>(options =>
                {
                    options.Filters.Add(new ValidateModelFilter());
                });
            })
        );

        this.Client = this.ApplicationFactory.CreateClient();
        this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("TestAuth");
    }

    public void Dispose()
    {
        Client.Dispose();
    }
}

public class ValidateModelFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}

public class TestAuthOptions : AuthenticationSchemeOptions { }

public class TestAuthHandler : AuthenticationHandler<TestAuthOptions>
{
    public TestAuthHandler(
        IOptionsMonitor<TestAuthOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder)
        : base(options, logger, encoder)
    { }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "123"),
            new Claim(ClaimTypes.Email, "test@test.test"),
            new Claim(ClaimTypes.Name, "Test User"),
            new Claim(ClaimTypes.Role, "brewer"),
            new Claim(ClaimTypes.Role, "customer"),
            new Claim(ClaimTypes.Role, "employee"),
            new Claim(ClaimTypes.Role, "employeeNotMobile"),
            new Claim(ClaimTypes.Role, "manager"),
            new Claim(ClaimTypes.Role, "supervisor")
        };

        var identity = new ClaimsIdentity(claims, "TestAuth");
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, "TestAuth");

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}
