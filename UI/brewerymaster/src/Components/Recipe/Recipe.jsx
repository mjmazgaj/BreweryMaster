import React, { useState} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import './recipe.css';

import RecipeForm from './RecipeComponents/RecipeForm';
import RecipeTable from './RecipeComponents/RecipeTable';
import { Button } from "react-bootstrap";

const Recipe = () => {
  const [isAddMode, setIsAddMode] = useState(false);

  const [selectedRecipe, setSelectedRecipe] = useState({});

  const handleAddOnClick = () => {
    setIsAddMode(!isAddMode);
  };

  return (
    <div className="recipe_container">
      <ToastContainer />
      <Button
        className="recipe_modeSwitchButton"
        variant="dark"
        onClick={handleAddOnClick}
      >
        {isAddMode ? "Show all recipes" : "Add Recipe"}
      </Button>
      {isAddMode ? (
        <RecipeForm />
      ) : (
        <RecipeTable
          selectedRecipe={selectedRecipe}
          setSelectedRecipe={setSelectedRecipe}
        />
      )}
    </div>
  );
}

export default Recipe;