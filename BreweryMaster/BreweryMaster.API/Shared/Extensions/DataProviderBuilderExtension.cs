using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Info.Models.DB.Yeast;
using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Recipe.Models.DB;
using BreweryMaster.API.Shared.Helpers;
using BreweryMaster.API.User.Models.DB;
using BreweryMaster.API.Work.Models.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Shared.Extensions
{
    public static class DataProviderBuilderExtension
    {

        /// <summary>
        /// Add independent entities
        /// </summary>
        public static void AddIndependentEntities(this ModelBuilder builder)
        {
            //Item entites
            builder.Entity<UnitEntity>().HasData(EntityDataProvider.GetUnitEntity());
            builder.Entity<TaskStatusEntity>().HasData(EntityDataProvider.GetTaskStatusEntities());
            builder.Entity<IdentityRole>().HasData(EntityDataProvider.GetIdentityRoles());
            builder.Entity<AddressTypeEntity>().HasData(EntityDataProvider.GetAddressTypes());
            builder.Entity<MaterialType>().HasData(EntityDataProvider.GetMaterialTypes());
            builder.Entity<OrderStatus>().HasData(EntityDataProvider.GetOrderStatuses());

            //Recipe entites
            builder.Entity<RecipeTypeEntity>().HasData(RecipeDataProvider.GetRecipeTypeEntity());
            builder.Entity<BeerStyleEntity>().HasData(RecipeDataProvider.GetBeerStyleEntity());

            //Fermenting ingredient entites
            builder.Entity<FermentingIngredientTypeEntity>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientTypeEntity());

            //Yeast entites
            builder.Entity<YeastForm>().HasData(YeastDataProvider.GetYeastForm());
            builder.Entity<YeastType>().HasData(YeastDataProvider.GetYeastType());
        }

        /// <summary>
        /// Add entites dependent on independent entities
        /// </summary>
        public static void AddEntitiesSimpleDepend(this ModelBuilder builder)
        {
            //Dependent on Item entities
            builder.Entity<Container>().HasData(ItemDataProvider.GetContainers());
            builder.Entity<Info.Models.ContainerPrice>().HasData(ItemDataProvider.GetContainerPrices());
            builder.Entity<Info.Models.BeerPrice>().HasData(ItemDataProvider.GetBeerPrices());

            //Dependent on Recipe entites
            builder.Entity<Recipe.Models.DB.Recipe>().HasData(RecipeDataProvider.GetRecpies());

            //Dependent on fermenting ingredient entites
            builder.Entity<FermentingIngredient>().HasData(FermentingIngredientDataProvider.GetFermentingIngredient());

            //Dependent on yeast entites
            builder.Entity<Yeast>().HasData(YeastDataProvider.GetYeasts());
        }

        /// <summary>
        /// Add prospect order entites
        /// </summary>
        public static void AddProspectOrderEntities(this ModelBuilder builder)
        {
            builder.Entity<ProspectCompanyClient>().HasData(OrderDataProvider.GetProspectCompanyClients());
            builder.Entity<ProspectIndyvidualClient>().HasData(OrderDataProvider.GetProspectIndyvidualClients());
            builder.Entity<ProspectOrder>().HasData(OrderDataProvider.GetProspectOrders());
        }

        /// <summary>
        /// Add fermenting ingredient entites
        /// </summary>
        public static void AddFermentingIngredientEntities(this ModelBuilder builder)
        {
            //Dependent on UnitEntity and FermentingIngredient
            builder.Entity<FermentingIngredientUnit>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientUnit());

            //Dependent on FermentingIngredientUnit
            builder.Entity<FermentingIngredientOrdered>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientOrdered());
            builder.Entity<FermentingIngredientReserved>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientReserved());
            builder.Entity<FermentingIngredientStored>().HasData(FermentingIngredientDataProvider.GetFermentingIngredientStored());
        }

        /// <summary>
        /// Add yeast entites
        /// </summary>
        public static void AddYeastEntities(this ModelBuilder builder)
        {
            //Dependent on UnitEntity and Yeast
            builder.Entity<YeastUnit>().HasData(YeastDataProvider.GetYeastUnit());

            //Dependent on UnitEntity
            builder.Entity<YeastOrdered>().HasData(YeastDataProvider.GetYeastOrdered());
            builder.Entity<YeastReserved>().HasData(YeastDataProvider.GetYeastReserved());
            builder.Entity<YeastStored>().HasData(YeastDataProvider.GetYeastStored());
        }

        /// <summary>
        /// Add recipe entites
        /// </summary>
        public static void AddRecipeEntities(this ModelBuilder builder)
        {
            //Dependent on FermentingIngredient
            builder.Entity<RecipeFermentingIngredient>().HasData(RecipeDataProvider.GetRecipeFermentingIngredient());
        }
    }
}
