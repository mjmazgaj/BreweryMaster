﻿using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a stored fermenting ingredient in the database. 
    /// </summary>
    public class FermentingIngredientStored : FermentingIngredientQuantity
    {
        /// <summary>
        /// The stored quantity
        /// </summary>
        [Precision(9, 3)]
        public decimal StoredQuantity { get; set; }
    }
}
