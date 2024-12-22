import React, { useState} from "react";
import 'bootstrap/dist/css/bootstrap.min.css'
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import "../../info.css"

import DynamicTable from '../../../Shared/TableComponents/DynamicTable';
import ModalUpdateItem from "../../../Shared/ModalComponents/ModalUpdateItem"
import { Button } from "react-bootstrap";
import modalFieldsProvider from "../../../Shared/ModalComponents/helpers/modalFieldsProvider";

import { useTranslation } from 'react-i18next';
const FermentingIngredients = () => {
  const { t } = useTranslation();

  const [ingredients, setIngredients] = useState([
    { 
      id: 1, 
      type: 'Grain', 
      name: 'Viking Pilsner malt', 
      quantity: 3, 
      percentage: 62.5, 
      extraction: 82, 
      ebc: 4 
    },
    { 
      id: 2, 
      type: 'Grain', 
      name: 'Strzegom Monachijski typ II', 
      quantity: 1, 
      percentage: 20.8, 
      extraction: 79, 
      ebc: 22 
    },
    { 
      id: 3, 
      type: 'Grain', 
      name: 'Strzegom Karmel 150', 
      quantity: 0.5, 
      percentage: 10.4, 
      extraction: 75, 
      ebc: 150 
    },
    { 
      id: 4, 
      type: 'Grain', 
      name: 'Oats, Flaked', 
      quantity: 0.3, 
      percentage: 6.3, 
      extraction: 80, 
      ebc: 2 
    }
  ]);

  const [show, setShow] = useState(false);
  const [isUpdateMode, setIsUpdateMode] = useState(false);
  const [modalData, setModalData] = useState([]);

  const handleDoubleClick = (item) =>{
    setIsUpdateMode(true);
    setShow(true);
    setModalData({ ...item });
  }

  const handleAddOnClick = () =>{
      setIsUpdateMode(false);
      setShow(true);
      setModalData(null);
  }

    return (
      <div className="Info_container">
        <ToastContainer />
        <DynamicTable
          tableKey=""
          tableTitle=""
          data={ingredients}
          handleDoubleClick={handleDoubleClick}
        />
        <ModalUpdateItem
          title="Info"
          show={show}
          setShow={setShow}
          fields={modalFieldsProvider(t).ingredientsModalFields}
          data={modalData}
          setData={setModalData}
          isUpdateMode={isUpdateMode}
        />
        <Button variant="dark" onClick={handleAddOnClick}>
          Add
        </Button>
      </div>
    );
}

export default FermentingIngredients;