using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Services
{
    public class FermentingIngredientOrderService : IFermentingIngredientOrderService
    {
        private readonly ApplicationDbContext _context;
        public FermentingIngredientOrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FermentingIngredientOrderResponse>> GetFermentingIngredientOrders()
        {
            return await _context.FermentingIngredientsOrdered
                .Where(x => !x.IsRemoved)
                .Include(x => x.FermentingIngredientUnit)
                    .ThenInclude(x => x.Unit)
                .Include(x => x.FermentingIngredientUnit)
                    .ThenInclude(x => x.FermentingIngredient)
                .Select(ingredient => new FermentingIngredientOrderResponse()
                {
                    Id = ingredient.Id,
                    Name = ingredient.FermentingIngredientUnit.FermentingIngredient.Name,
                    TypeId = ingredient.FermentingIngredientUnit.FermentingIngredient.TypeId,
                    TypeName = ingredient.FermentingIngredientUnit.FermentingIngredient.Type.Name,
                    Percentage = ingredient.FermentingIngredientUnit.FermentingIngredient.Percentage,
                    Extraction = ingredient.FermentingIngredientUnit.FermentingIngredient.Extraction,
                    EBC = ingredient.FermentingIngredientUnit.FermentingIngredient.EBC,
                    OrderedDate = DateOnly.FromDateTime(ingredient.OrderedDate),
                    ExpectedDate = ingredient.ExpectedDate.HasValue ? DateOnly.FromDateTime(ingredient.ExpectedDate.Value) : null,
                    Unit = ingredient.FermentingIngredientUnit.Unit.Name,
                    IsCompleted = ingredient.IsCompleted,
                    Info = ingredient.Info,
                }).ToListAsync();
        }

        public async Task<FermentingIngredientOrderResponse?> GetFermentingIngredientOrderById(int id)
        {
            var ingredients = await GetFermentingIngredientOrders();

            return ingredients?.FirstOrDefault(x => x.Id == id);
        }

        public async Task<FermentingIngredientOrderResponse?> CreateFermentingIngredientOrder(FermentingIngredientOrderRequest request)
        {
            var ingredientOrderToCreate = new FermentingIngredientOrdered()
            {
                FermentingIngredientUnitId = request.FermentingIngredientUnitId,
                OrderedQuantity = request.Quantity,
                OrderedDate = DateTime.Now,
                ExpectedDate = request.ExpectedDate,
                Info = request.Info,
            };

            _context.FermentingIngredientsOrdered.Add(ingredientOrderToCreate);
            await _context.SaveChangesAsync();

            return await GetFermentingIngredientOrderById(ingredientOrderToCreate.Id);
        }

        public async Task<bool> CompleteFermentingIngredientOrder(int id)
        {
            var ingredientToComplete = await _context.FermentingIngredientsOrdered.FirstOrDefaultAsync(x => x.Id == id);

            if (ingredientToComplete is null)
                return false;

            ingredientToComplete.IsCompleted = true;

            _context.FermentingIngredientsOrdered.Update(ingredientToComplete);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteFermentingIngredientOrder(int id)
        {
            var ingredientToDelete = await _context.FermentingIngredientsOrdered.FirstOrDefaultAsync(x => x.Id == id);

            if (ingredientToDelete is null)
                return false;

            ingredientToDelete.IsRemoved = true;

            _context.FermentingIngredientsOrdered.Update(ingredientToDelete);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
