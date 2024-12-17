import React, {Fragment, useState} from "react";

import Ingredients from "../../Shared/Ingredients";

const InfoFirstStep = () => {  
  const [ingredients, setIngredients] = useState([
    { id: 1, name: 'Flour', quantity: 1000 },
    { id: 2, name: 'Sugar', quantity: 500 },
    { id: 3, name: 'Butter', quantity: 250 },
  ]);

  const handleAddIngredient = () => {
    console.log(ingredients);
  }

  return (
    <div style={{ display: "flex", padding: "20px" }}>
      <Ingredients
        ingredients={ingredients}
        handleAddIngredient={handleAddIngredient}
      />
    </div>
  );
};

export default InfoFirstStep;