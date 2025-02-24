import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../order.css";

import { fetchData } from "../../Shared/api";
import { useTranslation } from "react-i18next";

import DynamicTable from "../../Shared/TableComponents/DynamicTable";

const RecipeTableSelection = ({
  selectedRecipe,
  setSelectedRecipe,
  setIsValid,
}) => {
  const { t } = useTranslation();
  const [data, setData] = useState([]);

  const handleDoubleClick = (item) => {
    setSelectedRecipe((prevData) => ({ ...prevData, recipeId: item.id, recipe: item.name }));
    setIsValid(true);
  };

  useEffect(() => {
    fetchData("Recipe", setData);
  }, []);

  return (
    <div className="recipe-table-selection_container">
      {selectedRecipe?.recipeId && (
        <div className="recipe-table-selection_item">
          <h3>Wybrano:</h3>
          <p>{selectedRecipe.recipe}</p>
        </div>
      )}
      {data && (
        <DynamicTable
          tableKey="recipes"
          tableTitle={t("name.general.recipes")}
          dataCategory="brewery"
          data={data}
          handleDoubleClick={handleDoubleClick}
        />
      )}
    </div>
  );
};

export default RecipeTableSelection;
