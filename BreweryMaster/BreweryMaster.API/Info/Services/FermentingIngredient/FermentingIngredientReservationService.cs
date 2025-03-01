using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Services
{
    public class FermentingIngredientReservationService : IFermentingIngredientReservationService
    {
        private readonly ApplicationDbContext _context;
        public FermentingIngredientReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FermentingIngredientReservationResponse>> GetFermentingIngredientReservations()
        {
            return await _context.FermentingIngredientsReserved
                .Where(x => !x.IsRemoved)
                .Include(x => x.Order)
                .Include(x => x.FermentingIngredientUnit)
                    .ThenInclude(x => x.Unit)
                .Include(x => x.FermentingIngredientUnit)
                    .ThenInclude(x => x.FermentingIngredient)
                .Select(ingredient => new FermentingIngredientReservationResponse()
                {
                    Id = ingredient.Id,
                    Name = ingredient.FermentingIngredientUnit.FermentingIngredient.Name,
                    TypeId = ingredient.FermentingIngredientUnit.FermentingIngredient.TypeId,
                    TypeName = ingredient.FermentingIngredientUnit.FermentingIngredient.Type.Name,
                    Percentage = ingredient.FermentingIngredientUnit.FermentingIngredient.Percentage,
                    Extraction = ingredient.FermentingIngredientUnit.FermentingIngredient.Extraction,
                    EBC = ingredient.FermentingIngredientUnit.FermentingIngredient.EBC,
                    OrderId = ingredient.OrderId,
                    OrderName = ingredient.Order != null ? ingredient.Order.Id.ToString() : string.Empty,
                    ReservationDate = DateOnly.FromDateTime(ingredient.ReservationDate),
                    Quantity = ingredient.ReservedQuantity,
                    Unit = ingredient.FermentingIngredientUnit.Unit.Name,
                    Info = ingredient.Info,
                    IsCompleted = ingredient.IsCompleted,
                }).ToListAsync();
        }

        public async Task<FermentingIngredientReservationResponse?> GetFermentingIngredientReservationById(int id)
        {
            var ingredients = await GetFermentingIngredientReservations();

            return ingredients?.FirstOrDefault(x => x.Id == id);
        }

        public async Task<FermentingIngredientReservationResponse?> CreateFermentingIngredientReservation(FermentingIngredientReserveRequest request)
        {
            var ingredientReservationToCreate = new FermentingIngredientReserved()
            {
                FermentingIngredientUnitId = request.FermentingIngredientUnitId,
                ReservedQuantity = request.Quantity,
                ReservationDate = DateTime.Now,
                OrderId = request.OrderId,
                Info = request.Info,
            };

            _context.FermentingIngredientsReserved.Add(ingredientReservationToCreate);

            await _context.SaveChangesAsync();

            return await GetFermentingIngredientReservationById(ingredientReservationToCreate.Id);
        }

        public async Task<bool> UpdateFermentingIngredientReservation(int id, FermentingIngredientQuantityUpdateRequest request)
        {
            var ingredientToUpdate = await _context.FermentingIngredientsReserved.FirstOrDefaultAsync(x => x.Id == id);

            if (ingredientToUpdate is null)
                return false;

            ingredientToUpdate.ReservedQuantity = request.Quantity ?? ingredientToUpdate.ReservedQuantity;
            ingredientToUpdate.Info = request.Info ?? ingredientToUpdate.Info;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CompleteFermentingIngredientReservation(int id)
        {
            var fermentingIngredientsToComplete = await _context.FermentingIngredientsReserved.FirstOrDefaultAsync(x => x.Id == id);

            if (fermentingIngredientsToComplete is null)
                return false;

            fermentingIngredientsToComplete.IsCompleted = true;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteFermentingIngredientReservation(int id)
        {
            var fermentingIngredientsToDelete = await _context.FermentingIngredientsReserved.FirstOrDefaultAsync(x => x.Id == id);

            if (fermentingIngredientsToDelete is null)
                return false;

            fermentingIngredientsToDelete.IsRemoved = true;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
