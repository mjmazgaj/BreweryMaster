import { useState, useEffect } from "react";
import { fetchData } from "../../../Shared/api";
import { useNavigate } from "react-router-dom";

import { useTranslation } from "react-i18next";
export const useRecipeTable = ({ setData }) => {
  const { t } = useTranslation();
    const navigate = useNavigate();

  const handleDoubleClick = (item) => {
    console.log("dziala");
    navigate(`/Recipe/${item.id}`);
  };

  useEffect(() => {
    fetchData("Recipe", setData);
  }, []);

  
  return {
    handleDoubleClick,
  };
};
