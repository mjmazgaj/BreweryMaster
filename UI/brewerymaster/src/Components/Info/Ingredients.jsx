import React, { useState} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import "./info.css"
import FermentingIngredients from "./Ingredients/InfoComponents/FermentingIngredients";

const Ingredients = () => {
    return (
      <div>
        <FermentingIngredients />
      </div>
    );
}

export default Ingredients;