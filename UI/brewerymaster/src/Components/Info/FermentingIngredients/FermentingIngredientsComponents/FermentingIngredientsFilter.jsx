import React, { useState } from "react";
import { Button, Form } from "react-bootstrap";

import { useFermentingIngredientsFilter } from "./helpers/useFermentingIngredientsFilter";
import FormControls from "../../../Shared/FormControls";
import DropDownIndex from "../../../Shared/DropDownIndex";

const FermentingIngredientsFilter = ({ fields, setTableData }) => {
  const [filterData, setFilterData] = useState({});
  const [isValid, setIsValid] = useState(true);

  const { handleSelectChange, handleSubmit } = useFermentingIngredientsFilter({
    setFilterData,
    filterData,
    setTableData,
  });

  const renderDropdowns = () =>
    fields?.dropdown && (
      <div className="modal-form_dropdown-container">
        {fields.dropdown.map((dropdownObject, index) => (
          <DropDownIndex
            key={index}
            id={"modal-form_dropdown"}
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
      <FormControls
        fields={fields.control}
        data={filterData}
        setData={setFilterData}
        isReadOnly={false}
        setIsValid={setIsValid}
      />
      {renderDropdowns()}
      <Button type="submit" variant="dark" disabled={!isValid}>
        Jeb
      </Button>
    </Form>
  );
};

export default FermentingIngredientsFilter;
