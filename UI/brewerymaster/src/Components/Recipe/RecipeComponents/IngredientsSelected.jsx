import React, {Fragment, useState} from "react";

const IngredientsSelected = ({selectedIngredients}) => {  

  return (
    <div style={{ flex: 1 }}>
      <h3>Selected Ingredients</h3>
      <table border="1" width="100%">
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

export default IngredientsSelected;