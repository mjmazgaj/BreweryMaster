import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../recipe.css";

import { useTranslation } from "react-i18next";

import DynamicTable from "../../Shared/TableComponents/DynamicTable";
import { useRecipeTable } from "./helpers/useRecipeTable";

const RecipeTable = () => {
  const { t } = useTranslation();

  const [data, setData] = useState([]);

  const {handleDoubleClick} = useRecipeTable({setData});

  return (
    <div className="recipe-table">
      {data && (
        <DynamicTable
          tableKey="recipes"
          tableTitle={t("name.brewery.recipes")}
          dataCategory="brewery"
          data={data}
          handleDoubleClick={handleDoubleClick}
        />
      )}
    </div>
  );
};

export default RecipeTable;
