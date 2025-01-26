import React, { useState, useEffect} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import '../recipe.css';

import { Button } from "react-bootstrap";

import {fetchData} from "../../Shared/api"

import DynamicTable from "../../Shared/TableComponents/DynamicTable";

const RecipeTable = ({selectedRecipe, setSelectedRecipe}) => {

const [data, setData] = useState([]);

const handleDoubleClick = (item) =>{
    console.log("dziala");
    setSelectedRecipe(item);
}

  useEffect(() => {
    fetchData("Recipe", setData);
  }, []);

    return (
      <div className="recipe-table">
        {data && (
          <DynamicTable
            tableKey="recipes"
            tableTitle="Recipies"
            data={data}
            handleDoubleClick={handleDoubleClick}
          />
        )}
      </div>
    );
}

export default RecipeTable;