import React, {Fragment, useState} from "react";

const IngredientsModal = ({modalData, handleConfirmQuantity, setModalData}) => {  

  return (
    modalData && (
      <div
        style={{
          position: "fixed",
          top: "50%",
          left: "50%",
          transform: "translate(-50%, -50%)",
          backgroundColor: "white",
          padding: "20px",
          boxShadow: "0px 0px 10px rgba(0, 0, 0, 0.25)",
        }}
      >
        <h4>Add {modalData.name}</h4>
        <p>Available: {modalData.maxQuantity}</p>
        <input
          type="number"
          min="1"
          max={modalData.maxQuantity}
          placeholder="Quantity"
          id="quantityInput"
        />
        <div style={{ marginTop: "10px" }}>
          <button
            onClick={() => {
              const quantity = parseInt(
                document.getElementById("quantityInput").value,
                10
              );
              if (quantity > 0 && quantity <= modalData.maxQuantity) {
                handleConfirmQuantity(quantity);
              } else {
                alert("Invalid quantity");
              }
            }}
          >
            Confirm
          </button>
          <button
            style={{ marginLeft: "10px" }}
            onClick={() => setModalData(null)}
          >
            Cancel
          </button>
        </div>
      </div>
    )
  );
};

export default IngredientsModal;