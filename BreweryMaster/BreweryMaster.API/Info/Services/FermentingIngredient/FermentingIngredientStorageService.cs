using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Services
{
    public class FermentingIngredientStorageService : IFermentingIngredientStorageService
    {
        private readonly ApplicationDbContext _context;
        public FermentingIngredientStorageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FermentingIngredientStorageResponse?> GetFermentingIngredientStorageById(int id)
        {
            var storedIngridient = await _context.FermentingIngredientsStored
                            .Where(x => !x.IsRemoved)
                            .Include(x => x.FermentingIngredientUnit)
                            .FirstOrDefaultAsync(x => x.Id == id);

            return new FermentingIngredientStorageResponse()
            {
                Id = id,
                FermentingIngredientUnit = storedIngridient.FermentingIngredientUnit.Id,
                Info = storedIngridient.Info,
                StoredQuantity = storedIngridient.StoredQuantity
            };
        }

        public async Task<FermentingIngredientStorageResponse?> CreateFermentingIngredientStorage(FermentingIngredientStorageRequest request)
        {
            var ingredientStorageToCreate = new FermentingIngredientStored()
            {
                FermentingIngredientUnitId = request.FermentingIngredientUnitId,
                StoredQuantity = request.Quantity,
                Info = request.Info,
            };

            _context.FermentingIngredientsStored.Add(ingredientStorageToCreate);
            await _context.SaveChangesAsync();

            return await GetFermentingIngredientStorageById(ingredientStorageToCreate.Id);
        }
    }
}
