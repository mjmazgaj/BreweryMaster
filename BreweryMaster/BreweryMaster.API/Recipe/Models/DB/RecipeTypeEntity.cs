namespace BreweryMaster.API.Recipe.Models.DB
{
    /// <summary>
    /// Represents a recipe type entity in the database.
    /// </summary>
    public class RecipeTypeEntity
    {
        /// <summary>
        /// The unique identifier for the recipe type.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the recipe type.
        /// </summary>
        public required string Name { get; set; }
    }
}
