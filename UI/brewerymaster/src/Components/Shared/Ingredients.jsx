import React, {Fragment, useState} from "react";

import "./shared.css";

const Ingredients = ({ingredients, handleAddIngredient}) => {  
  return (
    <div className="ingredients_container">
      <h3>Available Ingredients</h3>
      <table className="ingredients_table">
        <thead>
          <tr>
            <th>Name</th>
            <th>Quantity</th>
          </tr>
        </thead>
        <tbody>
          {ingredients.map((ingredient) => (
            <tr
              key={ingredient.id}
              onDoubleClick={() => handleAddIngredient(ingredient)}
              style={{ cursor: "pointer" }}
            >
              <td>{ingredient.name}</td>
              <td>{ingredient.quantity}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Ingredients;