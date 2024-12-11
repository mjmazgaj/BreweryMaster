import React, { useState} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import RecipeForm from './RecipeComponents/RecipeForm';

const Recipe = () => {

    return (
      <div className="Recipe_container">
        <ToastContainer />
        <RecipeForm />
      </div>
    );
}

export default Recipe;