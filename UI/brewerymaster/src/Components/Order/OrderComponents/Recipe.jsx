import React, { useState} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import 'react-toastify/dist/ReactToastify.css';

import RecipeTable from "../../Recipe/RecipeComponents/RecipeTable";
import { Card } from "react-bootstrap";

const Recipe = ({selectedRecipe, setSelectedRecipe}) => {

    return (
      <div className="order-recipe_container">
        {selectedRecipe.name && (
          <Card>
            <Card.Header>
            <h2>Selected recipe:</h2>
            <p>{selectedRecipe.name}</p>
            </Card.Header>
          </Card>
        )}
        <RecipeTable
          selectedRecipe={selectedRecipe}
          setSelectedRecipe={setSelectedRecipe}
        />
      </div>
    );
}

export default Recipe;