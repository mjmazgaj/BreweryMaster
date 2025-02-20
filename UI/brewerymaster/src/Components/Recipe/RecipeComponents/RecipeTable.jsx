import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "../recipe.css";

import { useTranslation } from "react-i18next";
import { useNavigate } from "react-router-dom";

import { fetchData } from "../../Shared/api";

import DynamicTable from "../../Shared/TableComponents/DynamicTable";

const RecipeTable = () => {
  const { t } = useTranslation();
  const navigate = useNavigate();

  const [data, setData] = useState([]);

  const handleDoubleClick = (item) => {
    console.log("dziala");
    navigate(`/Recipe/${item.id}`);
  };

  useEffect(() => {
    fetchData("Recipe", setData);
  }, []);

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
