using BreweryMaster.API.Info.Services;
using BreweryMaster.API.OrderModule.Services;
using BreweryMaster.API.Recipe.Services;
using BreweryMaster.API.User.Services;
using BreweryMaster.API.WorkModule.Services;

namespace BreweryMaster.API.Configuration.Helpers
{
    public static class DependencyInjectionRegistration
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.RegisterInfoDependencies();
            services.RegisterOrderDependencies();
            services.RegisterRecipeDependencies();
            services.RegisterUserDependencies();
            services.RegisterWorkDependencies();
        }

        private static void RegisterInfoDependencies(this IServiceCollection services)
        {
            services.AddScoped<IFermentingIngredientService, FermentingIngredientService>();
            services.AddScoped<IFermentingIngredientReservationService, FermentingIngredientReservationService>();
            services.AddScoped<IFermentingIngredientOrderService, FermentingIngredientOrderService>();
            services.AddScoped<IEntityService, EntityService>();
        }

        private static void RegisterOrderDependencies(this IServiceCollection services)
        {

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProspectClientService, ProspectClientService>();
            services.AddScoped<IProspectOrderService, ProspectOrderService>();
        }

        private static void RegisterRecipeDependencies(this IServiceCollection services)
        {

            services.AddScoped<IRecipeService, RecpieService>();
        }

        private static void RegisterUserDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAddressService, AddressService>();

        }

        private static void RegisterWorkDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();
        }
    }
}
