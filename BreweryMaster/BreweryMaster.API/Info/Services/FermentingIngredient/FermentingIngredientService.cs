using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Info.Services;
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

        public async Task<IEnumerable<FermentingIngredientSummaryResponse>> GetFermentingIngredientSummary(FermentingIngredientFilterRequest? request)
        {
            return await _context.FermentingIngredientUnits
                .Where(x =>
                    !x.IsRemoved &&
                    (request == null || request.Name == null || x.FermentingIngredient.Name.Contains(request.Name)) &&
                    (request == null || request.UnitId == null || x.UnitId == request.UnitId) &&
                    (request == null || request.TypeId == null || x.FermentingIngredient.TypeId == request.TypeId))
                .Select(ingredient => new FermentingIngredientSummaryResponse()
                {
                    Id = ingredient.Id,
                    TypeId = ingredient.FermentingIngredient.TypeId,
                    TypeName = ingredient.FermentingIngredient.Type.Name,
                    Name = ingredient.FermentingIngredient.Name,
                    Extraction = ingredient.FermentingIngredient.Extraction,
                    EBC = ingredient.FermentingIngredient.EBC,
                    Percentage = ingredient.FermentingIngredient.Percentage,
                    ReservedQuantity = ingredient.FermentingIngredientsReserved.Any() ?
                                        ingredient.FermentingIngredientsReserved.Sum(x => x.ReservedQuantity) : 0,
                    OrderedQuantity = ingredient.FermentingIngredientsOrdered.Any() ?
                                        ingredient.FermentingIngredientsOrdered.Sum(x => x.OrderedQuantity) : 0,
                    StoredQuantity = ingredient.FermentingIngredientsStored.Any() ?
                                        ingredient.FermentingIngredientsStored.Sum(x => x.StoredQuantity) : 0,
                    Unit = ingredient.Unit.Name,
                    Info = ingredient.FermentingIngredient.Info,
                }).ToListAsync();
        }

        public async Task<FermentingIngredientSummaryResponse?> GetFermentingIngredientSummaryByIdAsync(int id)
        {
            var ingredients = await GetFermentingIngredientSummary(null);

            return ingredients?.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<FermentingIngredientUnitResponse>?> GetFermentingIngredientUnitAsync()
        {
            return await _context.FermentingIngredientUnits
                .Select(x => new FermentingIngredientUnitResponse()
                {
                    Id = x.Id,
                    TypeName = x.FermentingIngredient.Type.Name,
                    Name = x.FermentingIngredient.Name,
                    Extraction = x.FermentingIngredient.Extraction,
                    EBC = x.FermentingIngredient.EBC,
                    Percentage = x.FermentingIngredient.Percentage,
                    Unit = x.Unit.Name,
                    Info = x.FermentingIngredient.Info
                }).ToListAsync();
        }

        public async Task<IEnumerable<int>?> GetFermentingIngredientUnitsById(int fermentingIngredientUnitId)
        {
            var usedUnits = await _context.FermentingIngredientUnits
                                .Include(x => x.FermentingIngredient)
                                .ThenInclude(x => x.FermentingIngredientUnits)
                                .SingleOrDefaultAsync(x => x.Id == fermentingIngredientUnitId);

            return usedUnits?
                .FermentingIngredient
                .FermentingIngredientUnits
                .Where(x => !x.IsRemoved)
                .Select(x => x.UnitId);
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
                        FermentingIngredientId = ingredientToCreate.Id,
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

        public async Task<bool> UpdateFermentingIngredientAsync(int id, FermentingIngredientUpdateRequest request)
        {
            var ingredientToUpdate = await _context.FermentingIngredientUnits
                                                .Include(x => x.FermentingIngredient)
                                                .FirstOrDefaultAsync(x => x.Id == id);

            if (ingredientToUpdate is null)
                return false;

            ingredientToUpdate.FermentingIngredient.Name = request.Name;
            ingredientToUpdate.FermentingIngredient.TypeId = request.TypeId;
            ingredientToUpdate.FermentingIngredient.Percentage = request.Percentage;
            ingredientToUpdate.FermentingIngredient.Extraction = request.Extraction;
            ingredientToUpdate.FermentingIngredient.EBC = request.EBC;
            ingredientToUpdate.FermentingIngredient.Info = request.Info;

            _context.FermentingIngredientUnits.Update(ingredientToUpdate);

            await _context.SaveChangesAsync();

            var fermentingIngredient = await _context.FermentingIngredientUnits
                                           .Include(x => x.FermentingIngredient)
                                           .ThenInclude(x => x.FermentingIngredientUnits)
                                           .SingleOrDefaultAsync(x => x.Id == id);
            var allSavedUnits = fermentingIngredient?.FermentingIngredient
                                       .FermentingIngredientUnits
                                       .Select(x => x.UnitId);

            var unitsToRestore = fermentingIngredient?.FermentingIngredient
                                       .FermentingIngredientUnits
                                       .Where(x => x.IsRemoved)
                                       .Select(x => x.UnitId)
                                       .Where(x => request.Units.Contains(x));

            if (allSavedUnits is not null)
            {
                var fermentingIngredientUnitsToCreate = request.Units.Where(x => !allSavedUnits.Any(y => y == x))
                                            .Select(x => new FermentingIngredientUnit()
                                            {
                                                FermentingIngredientId = ingredientToUpdate.FermentingIngredientId,
                                                UnitId = x,
                                            });

                _context.FermentingIngredientUnits.AddRange(fermentingIngredientUnitsToCreate);
                await _context.SaveChangesAsync();
            }

            if (unitsToRestore is not null)
            {
                foreach (int unit in unitsToRestore)
                {
                    var ingredientUnit = await _context.FermentingIngredientUnits
                                            .FirstOrDefaultAsync(x => x.FermentingIngredientId == ingredientToUpdate.FermentingIngredientId && x.UnitId == unit);
                    if (ingredientUnit is not null)
                    {
                        ingredientUnit.IsRemoved = false;
                        _context.FermentingIngredientUnits.Update(ingredientUnit);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return true;
        }

        public async Task<bool> DeleteFermentingIngredientUnitById(int id)
        {
            var ingredient = await _context.FermentingIngredientUnits.FirstOrDefaultAsync(x => x.Id == id);

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
    }
}
