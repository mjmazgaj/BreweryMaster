﻿using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Info.Services.Interfaces;
using BreweryMaster.API.SharedModule.Models;
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
            var ingredientToCreate = new FermentingIngredient()
            {
                Name = request.Name,
                TypeId = (int)request.Type,
                EBC = request.EBC,
                Extraction = request.Extraction,
                Percentage = request.Percentage,
                Info = request.Info,
            };

            _context.FermentingIngredients.Add(ingredientToCreate);
            await _context.SaveChangesAsync();

            return ingredientToCreate;
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

        public async Task<IEnumerable<FermentingIngredientUnitResponse>> GetFermentingIngredientUnitsAsync()
        {
            var dbIngredients = await _context.FermentingIngredientUnits
                .Include(x=>x.FermentingIngredient)
                .Include(x=>x.Unit)
                .Where(x => !x.IsRemoved)
                .ToListAsync();

            var ingredients = dbIngredients.Select(x => new FermentingIngredientUnitResponse()
            {
                Id = x.Id,
                FermentingIngredient = x.FermentingIngredient,
                Unit = x.Unit
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
            var ingredients = await GetFermentingIngredientUnitsAsync();
            var dbIngredientTypes = await _context.FermentingIngredientTypes.ToDictionaryAsync(x => x.Id, x => x.Name);

            var orderedData = await _context.FermentingIngredientOrderedList.ToListAsync();

            //ToDO
            var reservedData = Helpers.DataProvider.GetReserved(ingredients);
            var storedData = Helpers.DataProvider.GetStored(ingredients);

            var ingredientsReserve = reservedData
                .GroupBy(x => x.FermentingIngredientUnitId)
                .ToDictionary(x => x.Key, x => x.Sum(y => y.ReservedQuantity));

            var ingredientsOrdered = orderedData
                .GroupBy(x => x.FermentingIngredientUnitId)
                .ToDictionary(x => x.Key, x => x.Sum(y => y.OrderedQuantity));

            var ingredientsStored = storedData
                .GroupBy(x => x.FermentingIngredientUnitId)
                .ToDictionary(x => x.Key, x => x.Sum(y => y.StoredQuantity));

            var result = ingredients.Select(ingredient => new FermentingIngredientSummaryResponse()
            {
                Id = ingredient.Id,
                FermentingIngredient = ingredient.FermentingIngredient,
                Unit = ingredient.Unit,
                TypeName = dbIngredientTypes.ContainsKey(ingredient.FermentingIngredient.TypeId) ? dbIngredientTypes[ingredient.FermentingIngredient.TypeId] : string.Empty,
                ReservedQuantity = ingredientsReserve.ContainsKey(ingredient.FermentingIngredient.Id) ? ingredientsReserve[ingredient.FermentingIngredient.Id] : 0,
                OrderedQuantity = ingredientsOrdered.ContainsKey(ingredient.FermentingIngredient.Id) ? ingredientsOrdered[ingredient.FermentingIngredient.Id] : 0,
                StoredQuantity = ingredientsStored.ContainsKey(ingredient.FermentingIngredient.Id) ? ingredientsStored[ingredient.FermentingIngredient.Id] : 0,
            });

            return result;
        }

        public Task<FermentingIngredientSummaryResponse?> GetFermentingIngredientSummaryByIdAsync(int id)
        {
            throw new NotImplementedException();
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