using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Info.Services.Interfaces;
using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Services
{
    public class FermentingIngredientService : IFermentingIngredientService
    {
        private readonly ApplicationDbContext _context;
        public FermentingIngredientService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<FermentingIngredient> CreateFermentingIngredientAsync(FermentingIngredientRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var ingredientToCreate = new FermentingIngredient()
                {
                    Name = request.Name,
                    TypeId = request.TypeId,
                    Percentage = request.Percentage,
                    Extraction = request.Extraction,
                    EBC = request.EBC,
                    Info = request.Info,
                };

                _context.FermentingIngredients.Add(ingredientToCreate);
                await _context.SaveChangesAsync();

                var fermentingIngredientUnitsToCreate = request.Units
                    .Select(x => new FermentingIngredientUnit()
                    {
                        FermentingIngredient = null!,
                        FermentingIngredientId = ingredientToCreate.Id,
                        Unit = null!,
                        UnitId = x,
                    });

                _context.FermentingIngredientUnits.AddRange(fermentingIngredientUnitsToCreate);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return ingredientToCreate;

            }
            catch (Exception)
            {
                await transaction.RollbackAsync();

                throw;
            }
        }

        public async Task<IEnumerable<FermentingIngredientResponse>> GetFermentingIngredientsAsync()
        {
            var dbIngredients = await _context.FermentingIngredients
                .Where(x => !x.IsRemoved)
                .ToListAsync();
            var dbIngredientTypes = await _context.FermentingIngredientTypes.ToDictionaryAsync(x => x.Id, x => x.Name);

            var ingredients = dbIngredients.Select(x => new FermentingIngredientResponse()
            {
                Id = x.Id,
                Name = x.Name,
                TypeName = dbIngredientTypes.ContainsKey(x.TypeId) ? dbIngredientTypes[x.TypeId] : string.Empty,
                EBC = x.EBC,
                Extraction = x.Extraction,
                Percentage = x.Percentage,
                Info = x.Info,
            });

            return ingredients;
        }

        public async Task<FermentingIngredientResponse?> GetFermentingIngredientByIdAsync(int id)
        {
            var ingredients = await GetFermentingIngredientsAsync();

            return ingredients?.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<FermentingIngredientSummaryResponse>> GetFermentingIngredientSummary()
        {
            var ingredients = await _context.FermentingIngredientUnits
                .Include(x => x.FermentingIngredient)
                .Include(x => x.Unit)
                .Where(x => !x.IsRemoved)
                .ToListAsync();

            var dbIngredientTypes = await _context.FermentingIngredientTypes.ToDictionaryAsync(x => x.Id, x => x.Name);

            var ingredientsReserve = await _context.FermentingIngredientsReserved
                .GroupBy(x => x.FermentingIngredientUnitId)
                .ToDictionaryAsync(x => x.Key, x => x.Sum(y => y.ReservedQuantity));

            var ingredientsOrdered = await _context.FermentingIngredientsOrdered
                .GroupBy(x => x.FermentingIngredientUnitId)
                .ToDictionaryAsync(x => x.Key, x => x.Sum(y => y.OrderedQuantity));

            var ingredientsStored = await _context.FermentingIngredientsStored
                .GroupBy(x => x.FermentingIngredientUnitId)
                .ToDictionaryAsync(x => x.Key, x => x.Sum(y => y.StoredQuantity));

            var result = ingredients.Select(ingredient => new FermentingIngredientSummaryResponse()
            {
                Id = ingredient.Id,
                TypeId = ingredient.FermentingIngredient.TypeId,
                TypeName = dbIngredientTypes.ContainsKey(ingredient.FermentingIngredient.TypeId) ?
                            dbIngredientTypes[ingredient.FermentingIngredient.TypeId] : 
                            "",
                Name = ingredient.FermentingIngredient.Name,
                Extraction = ingredient.FermentingIngredient.Extraction,
                EBC = ingredient.FermentingIngredient.EBC,
                Percentage = ingredient.FermentingIngredient.Percentage,
                ReservedQuantity = ingredientsReserve.ContainsKey(ingredient.Id) ? ingredientsReserve[ingredient.Id] : 0,
                OrderedQuantity = ingredientsOrdered.ContainsKey(ingredient.Id) ? ingredientsOrdered[ingredient.Id] : 0,
                StoredQuantity = ingredientsStored.ContainsKey(ingredient.Id) ? ingredientsStored[ingredient.Id] : 0,
                Unit = ingredient.Unit.Name,
                Info = ingredient.FermentingIngredient.Info,
            });

            return result;
        }

        public Task<FermentingIngredientSummaryResponse?> GetFermentingIngredientSummaryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FermentingIngredientUnitResponse>?> GetFermentingIngredientUnitsByIdAsync(int fermentingIngredientUnitId)
        {
            var id = _context.FermentingIngredientUnits
                .Include(x => x.FermentingIngredient)
                .FirstOrDefault(x => x.Id == fermentingIngredientUnitId)?.FermentingIngredientId;

            var ingredientUnits = await _context.FermentingIngredientUnits
                .Where(x => !x.IsRemoved && x.FermentingIngredientId == id)
                .Select(x => x.UnitId)
                .ToListAsync();

            return _context.Units
                .Select(x => new FermentingIngredientUnitResponse()
                {
                    Id = x.Id,
                    Name = x.Name,
                    isUsed = ingredientUnits.Contains(x.Id)
                });
        }

        public async Task<IEnumerable<FermentingIngredientTypeEntityResponse>> GetFermentingIngredientTypesAsync()
        {
            return await _context.FermentingIngredientTypes.Select(x =>
            new FermentingIngredientTypeEntityResponse()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
        }

        public async Task<bool> UpdateFermentingIngredientAsync(int id, FermentingIngredientUpdateRequest request)
        {
            if (id != request.Id)
                return false;

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FermentingIngredientExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        public async Task<bool> DeleteFermentingIngredientByIdAsync(int id)
        {
            var ingredient = await _context.FermentingIngredients.FirstOrDefaultAsync(x => x.Id == id);

            if (ingredient == null || ingredient.IsRemoved)
            {
                return false;
            }

            ingredient.IsRemoved = true;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        private bool FermentingIngredientExists(int id)
        {
            return _context.FermentingIngredients.Any(x => x.Id == id && !x.IsRemoved);
        }
    }
}
