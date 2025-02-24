import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../recipe.css";

import { useTranslation } from "react-i18next";

import DynamicTable from "../../Shared/TableComponents/DynamicTable";
import { useRecipeTable } from "./helpers/useRecipeTable";
import CustomForm from "../../Shared/CustomForm";

const RecipeTable = () => {
  const { t } = useTranslation();

  const [data, setData] = useState([]);
    const [filterData, setFilterData] = useState([]);

  const {handleDoubleClick, filterObject, filterFields} = useRecipeTable({setData});

  return (
    <div className="recipe-table">
    <CustomForm
      fields={filterFields}
      formCustomizationObject={filterObject}
      data={filterData}
      setData={setFilterData}
    />
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
