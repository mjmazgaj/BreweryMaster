using BreweryMaster.API.User.Services;
using BreweryMaster.API.WorkModule.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Net.Http.Headers;

public class BaseTestController : IDisposable
{
    protected readonly HttpClient Client;
    protected readonly Mock<ITaskService> MockTaskService;
    protected readonly Mock<IUserService> MockUserService;
    protected readonly Mock<IAddressService> MockAddressService;
    private readonly WebApplicationFactory<Program> ApplicationFactory;

    public BaseTestController()
    {
        this.MockTaskService = new Mock<ITaskService>();
        this.MockUserService = new Mock<IUserService>();
        this.MockAddressService = new Mock<IAddressService>();

        this.ApplicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(
            builder => builder
            .UseEnvironment("integrationtests")
            .ConfigureTestServices(services =>
            {
                services.AddSingleton(this.MockTaskService.Object);
                services.AddSingleton(this.MockUserService.Object);
                services.AddSingleton(this.MockAddressService.Object);

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
