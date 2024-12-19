import React, {Fragment, useState} from "react";

import Ingredients from "../../Shared/Ingredients";

const InfoFirstStep = () => {  
  const [ingredients, setIngredients] = useState([
    { id: 1, name: 'Flour', quantity: 1000 },
    { id: 2, name: 'Sugar', quantity: 500 },
    { id: 3, name: 'Butter', quantity: 250 },
  ]);

  const handleDoubleClick = () => {
    console.log(ingredients);
  }

  return (
    <div style={{ display: "flex", padding: "20px" }}>
      <Ingredients
        ingredients={ingredients}
        handleDoubleClick={handleDoubleClick}
      />
    </div>
  );
};

export default InfoFirstStep;