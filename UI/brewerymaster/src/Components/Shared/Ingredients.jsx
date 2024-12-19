import React, {Fragment, useState} from "react";

import { useTranslation } from 'react-i18next';
import "./shared.css";

const Ingredients = ({ingredients, handleDoubleClick}) => {  
  const { t } = useTranslation();
  
  return (
    <div className="ingredients_container">
      <h3>{t("recipe.ingredientsAvailable")}</h3>
      <table className="ingredients_table">
        <thead>
          <tr>
            <th>{t("common.name")}</th>
            <th>{t("common.quantity")}</th>
          </tr>
        </thead>
        <tbody>
          {ingredients.map((ingredient) => (
            <tr
              key={ingredient.id}
              onDoubleClick={() => handleDoubleClick(ingredient)}
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