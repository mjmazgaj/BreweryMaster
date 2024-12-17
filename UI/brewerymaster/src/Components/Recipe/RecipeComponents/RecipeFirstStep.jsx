import React, {Fragment, useState} from "react";

import IngredientsAvailable from "../../Shared/IngredientsAvailable";
import IngredientsSelected from "./IngredientsSelected";
import IngredientsModal from "./IngredientsModal";

const RecipeFirstStep = () => {  
  const [ingredients, setIngredients] = useState([
    { id: 1, name: 'Flour', quantity: 1000 },
    { id: 2, name: 'Sugar', quantity: 500 },
    { id: 3, name: 'Butter', quantity: 250 },
  ]);

  const [selectedIngredients, setSelectedIngredients] = useState([]);
  const [modalData, setModalData] = useState(null);

  const handleAddIngredient = (ingredient) => {
    setModalData({
      id: ingredient.id,
      name: ingredient.name,
      maxQuantity: ingredient.quantity,
    });
  };

  const handleConfirmQuantity = (quantity) => {
    if (!modalData) return;

    const updatedIngredients = ingredients.map((item) =>
      item.id === modalData.id
        ? { ...item, quantity: item.quantity - quantity }
        : item
    );

    const existingSelected = selectedIngredients.find(
      (item) => item.id === modalData.id
    );

    let updatedSelected;
    if (existingSelected) {
      updatedSelected = selectedIngredients.map((item) =>
        item.id === modalData.id
          ? { ...item, quantity: item.quantity + quantity }
          : item
      );
    } else {
      updatedSelected = [
        ...selectedIngredients,
        { id: modalData.id, name: modalData.name, quantity },
      ];
    }

    setIngredients(updatedIngredients);
    setSelectedIngredients(updatedSelected);
    setModalData(null);
  };

  return (
    <div style={{ display: "flex", padding: "20px" }}>
      <IngredientsAvailable
        ingredients={ingredients}
        handleAddIngredient={handleAddIngredient}
      />
      <IngredientsSelected selectedIngredients={selectedIngredients} />
      <IngredientsModal
        modalData={modalData}
        handleConfirmQuantity={handleConfirmQuantity}
        setModalData={setModalData}
      />
    </div>
  );
};

export default RecipeFirstStep;