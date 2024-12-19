import React from "react";

import { useTranslation } from 'react-i18next';

import DynamicTable from "../../Shared/DynamicTable";
import RecipeIngredientsModal from "./RecipeIngredientsModal";

import { useRecipeIngredients } from "./helpers/useRecipeIngredients";

const RecipeIngredients = () => { 
  const { t } = useTranslation();

  const {
    ingredients,
    selectedIngredients,
    handleDoubleClick,
    modalData,
    handleConfirmQuantity,
    setModalData,
  } = useRecipeIngredients();

  return (
    <div className="recipe-ingredients_container">
      <DynamicTable
        tableKey="ingredientsAvailable"
        tableTitle={t("recipe.ingredientsAvailable")}
        data={ingredients}
        handleDoubleClick={handleDoubleClick}
      />
      <DynamicTable
        tableKey="ingredientsAvailable"
        tableTitle={t("recipe.ingredientsAvailable")}
        data={selectedIngredients}
        handleDoubleClick={() => {}}
      />
      <RecipeIngredientsModal
        modalData={modalData}
        handleConfirmQuantity={handleConfirmQuantity}
        setModalData={setModalData}
      />
    </div>
  );
};

export default RecipeIngredients;