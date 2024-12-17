import React, {Fragment, useState} from "react";

const IngredientsAvailable = ({ingredients, handleAddIngredient}) => {  

  return (
    <div style={{ flex: 1, marginRight: "20px" }}>
      <h3>Available Ingredients</h3>
      <table border="1" width="100%">
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

export default IngredientsAvailable;