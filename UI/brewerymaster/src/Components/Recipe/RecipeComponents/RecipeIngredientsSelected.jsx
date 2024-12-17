import React, {Fragment, useState} from "react";

const RecipeIngredientsSelected = ({selectedIngredients}) => {  

  return (
    <div className="recipe-ingredients-selected_container">
      <h3 className="recipe-ingredients-selected_title">Selected Ingredients</h3>
      <table className="recipe-ingredients-selected_table">
        <thead>
          <tr>
            <th>Name</th>
            <th>Quantity</th>
          </tr>
        </thead>
        <tbody>
          {selectedIngredients.map((ingredient) => (
            <tr key={ingredient.id}>
              <td>{ingredient.name}</td>
              <td>{ingredient.quantity}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default RecipeIngredientsSelected;