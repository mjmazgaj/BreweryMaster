import { useState, useEffect } from "react";
import { fetchData } from "../../../Shared/api";
import { useNavigate } from "react-router-dom";

import fieldsProvider from "./fieldsProvider";

import { useTranslation } from "react-i18next";
import { createPath } from "../../../Shared/helpers/useObjectHelper";

export const useRecipeTable = ({ setData }) => {
  const { t } = useTranslation();
  const navigate = useNavigate();

  const [beerStyles, setBeerStyles] = useState([]);
  const [recipeTypes, setRecipeTypes] = useState([]);

  const handleDoubleClick = (item) => {
    console.log("dziala");
    navigate(`/Recipe/${item.id}`);
  };

  const filterObject = {
    submitFunction: (data) => fillTable(data),
    buttons: [
      {
        isSubmit: true,
        label: t("button.filter"),
      },
    ],
    classNamePrefix: "recipe-filter",
  };

  const fillTable = (data) => {
    let query = {
      typeId: data?.typeId,
      beerStyleId: data?.beerStyleId,
      name: data?.name,
    };

    const path = createPath("Recipe", query);

    fetchData(path, setData);
  };

  const filterFields = {
    control: fieldsProvider(t).filterFields.control,
    dropdown: [
      {
        data: beerStyles,
        name: "beerStyleId",
        label: t("name.brewery.beerStyle"),
      },
      {
        data: recipeTypes,
        name: "typeId",
        label: t("name.brewery.type"),
      },
    ],
  };

  useEffect(() => {
    fetchData("Recipe", setData);
    fetchData("Recipe/BeerStyle/Dropdown", setBeerStyles);
    fetchData("Recipe/Type/DropDown", setRecipeTypes);
  }, []);

  return {
    handleDoubleClick,
    filterObject,
    filterFields,
  };
};
