using BreweryMaster.API.Info.Services;
using BreweryMaster.API.Recipe.Services;
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
    protected readonly Mock<IRecipeService> MockRecipeService;
    protected readonly Mock<IOrderService> MockOrderService;
    protected readonly Mock<IEntityService> MockEntityService;
    protected readonly Mock<IFermentingIngredientService> MockFermentingIngredientService;
    protected readonly Mock<IFermentingIngredientOrderService> MockFermentingIngredientOrderService;
    protected readonly Mock<IFermentingIngredientReservationService> MockFermentingIngredientReservationService;
    protected readonly Mock<IFermentingIngredientStorageService> MockFermentingIngredientStorageService;
    protected readonly Mock<IProspectOrderService> MockProspectOrderService;
    protected readonly Mock<IProspectClientService> MockProspectClientService;

    private readonly WebApplicationFactory<Program> ApplicationFactory;

    public BaseTestController()
    {
        this.MockTaskService = new Mock<ITaskService>();
        this.MockUserService = new Mock<IUserService>();
        this.MockAddressService = new Mock<IAddressService>();
        this.MockRecipeService = new Mock<IRecipeService>();
        this.MockOrderService = new Mock<IOrderService>();
        this.MockEntityService = new Mock<IEntityService>();
        this.MockFermentingIngredientService = new Mock<IFermentingIngredientService>();
        this.MockFermentingIngredientOrderService = new Mock<IFermentingIngredientOrderService>();
        this.MockFermentingIngredientReservationService = new Mock<IFermentingIngredientReservationService>();
        this.MockFermentingIngredientStorageService = new Mock<IFermentingIngredientStorageService>();
        this.MockProspectOrderService = new Mock<IProspectOrderService>();
        this.MockProspectClientService = new Mock<IProspectClientService>();

        this.ApplicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(
            builder => builder
            .UseEnvironment("integrationtests")
            .ConfigureTestServices(services =>
            {
                services.AddSingleton(this.MockTaskService.Object);
                services.AddSingleton(this.MockUserService.Object);
                services.AddSingleton(this.MockAddressService.Object);
                services.AddSingleton(this.MockRecipeService.Object);
                services.AddSingleton(this.MockOrderService.Object);
                services.AddSingleton(this.MockEntityService.Object);
                services.AddSingleton(this.MockFermentingIngredientService.Object);
                services.AddSingleton(this.MockFermentingIngredientOrderService.Object);
                services.AddSingleton(this.MockFermentingIngredientReservationService.Object);
                services.AddSingleton(this.MockFermentingIngredientStorageService.Object);
                services.AddSingleton(this.MockProspectOrderService.Object);
                services.AddSingleton(this.MockProspectClientService.Object);

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
