import React, { useState } from "react";
import { Button, Form } from "react-bootstrap";

import { useFermentingIngredientsFilter } from "./helpers/useFermentingIngredientsFilter";
import FormControls from "../../../Shared/FormControls";
import DropDownIndex from "../../../Shared/DropDownIndex";

import { useTranslation } from "react-i18next";
const FermentingIngredientsFilter = ({ fields, setTableData }) => {
  const { t } = useTranslation();
  const [filterData, setFilterData] = useState({});
  const [isValid, setIsValid] = useState(true);

  const { handleSelectChange, handleSubmit, handleClear } =
    useFermentingIngredientsFilter({
      setFilterData,
      filterData,
      setTableData,
    });

  const renderDropdowns = () =>
    fields?.dropdown && (
      <div className="filter-form_dropdown-container">
        {fields.dropdown.map((dropdownObject, index) => (
          <DropDownIndex
            key={index}
            id={"filter-form_dropdown"}
            data={dropdownObject.data}
            selectedOption={filterData[dropdownObject.name]}
            setSelectedOption={(e) =>
              handleSelectChange(e, dropdownObject.name)
            }
            isReadOnly={false}
            label={dropdownObject.label}
          />
        ))}
      </div>
    );

  return (
    <Form onSubmit={(event) => handleSubmit(event)}>
      <div className="filter-form_container">
        <div className="filter-form_control-container">
          <FormControls
            fields={fields.control}
            data={filterData}
            setData={setFilterData}
            isReadOnly={false}
            setIsValid={setIsValid}
          />
        </div>
        {renderDropdowns()}
      </div>
      <div className="filter-button_container">
        <Button type="submit" variant="dark" disabled={!isValid}>
          {t("button.filter")}
        </Button>
        <Button variant="dark" onClick={handleClear}>
          {t("button.clear")}
        </Button>
      </div>
    </Form>
  );
};

export default FermentingIngredientsFilter;
