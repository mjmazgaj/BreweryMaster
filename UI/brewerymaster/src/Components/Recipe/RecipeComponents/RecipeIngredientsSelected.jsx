import React, {Fragment, useState} from "react";

import { useTranslation } from 'react-i18next';

const RecipeIngredientsSelected = ({selectedIngredients}) => { 
  const { t } = useTranslation(); 

  return (
    <div className="recipe-ingredients-selected_container">
      <h3 className="recipe-ingredients-selected_title">{t("recipe.ingredientsSelected")}</h3>
      <table className="recipe-ingredients-selected_table">
        <thead>
          <tr>
            <th>{t("common.name")}</th>
            <th>{t("common.quantity")}</th>
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