import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "./recipe.css";

import RecipeForm from "./RecipeComponents/RecipeForm";
import RecipeTable from "./RecipeComponents/RecipeTable";
import { Button } from "react-bootstrap";

const Recipe = () => {
  const [isAddMode, setIsAddMode] = useState(false);

  const handleAddOnClick = () => {
    setIsAddMode(!isAddMode);
  };

  return (
    <div className="recipe_container">
      <Button
        className="recipe_modeSwitchButton"
        variant="dark"
        onClick={handleAddOnClick}
      >
        {isAddMode ? "Show all recipes" : "Add Recipe"}
      </Button>
      {isAddMode ? <RecipeForm setIsAddMode={setIsAddMode} /> : <RecipeTable />}
    </div>
  );
};

export default Recipe;
