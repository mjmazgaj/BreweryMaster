import React, {Fragment, useState} from "react";
import { Form } from "react-bootstrap";
const RecipeSummary = ({
  recipeSummaryData,
  setRecipeSummaryData,
}) => {
  const handleInputChange = (e) => {
    const { id, value } = e.target;
    setRecipeSummaryData((prevData) => ({
      ...prevData,
      [id]: value,
    }));
  };

  return (
    <div className="recipe-summary_container">
      <Form.Label>BLG scale</Form.Label>
      <Form.Control
        id="blgScale"
        type="number"
        min={0}
        max={100}
        placeholder="BLG"
        value={recipeSummaryData.blgScale}
        onChange={handleInputChange}
      />
      <Form.Label>IBU scale</Form.Label>
      <Form.Control
        id="ibuScale"
        type="number"
        min={0}
        max={1000}
        placeholder="IBU"
        value={recipeSummaryData.ibuScale}
        onChange={handleInputChange}
      />
      <Form.Label>ABV scale</Form.Label>
      <Form.Control
        id="abvScale"
        type="number"
        min={0}
        max={100}
        placeholder="ABV"
        value={recipeSummaryData.abvScale}
        onChange={handleInputChange}
      />
      <Form.Label>SRM scale</Form.Label>
      <Form.Control
        id="srmScale"
        type="number"
        min={0}
        max={100}
        placeholder="SRM"
        value={recipeSummaryData.srmScale}
        onChange={handleInputChange}
      />
      <Form.Label>Type</Form.Label>
      <Form.Control
        id="type"
        type="text"
        placeholder="type"
        value={recipeSummaryData.type}
        onChange={handleInputChange}
      />
      <Form.Label>Style</Form.Label>
      <Form.Control
        id="style"
        type="text"
        placeholder="style"
        value={recipeSummaryData.style}
        onChange={handleInputChange}
      />
    </div>
  );
};

export default RecipeSummary;