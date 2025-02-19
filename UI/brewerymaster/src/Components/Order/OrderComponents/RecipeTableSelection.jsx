import React, { useState, useEffect} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import 'react-toastify/dist/ReactToastify.css';
import '../order.css';

import {fetchData} from "../../Shared/api"

import DynamicTable from "../../Shared/TableComponents/DynamicTable";

const RecipeTableSelection = ({selectedRecipe, setSelectedRecipe}) => {

const [data, setData] = useState([]);

const handleDoubleClick = (item) =>{
    setSelectedRecipe((prevData)=>({...prevData, recipeId: item.id}));
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
            dataCategory="brewery"
            data={data}
            handleDoubleClick={handleDoubleClick}
          />
        )}
      </div>
    );
}

export default RecipeTableSelection;