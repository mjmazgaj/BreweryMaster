import React, { useEffect, useState } from 'react';
import { columnsFromBackend } from './KanbanData';

import Button from 'react-bootstrap/Button';

import {save} from './KanbanService'

import KanbanBoard from './KanbanBoard';

import "./kanban.css"

const Kanban = () => {
  const [columns, setColumns] = useState(columnsFromBackend);
  const [tasks, setTasks] = useState([]);
  const [errorMessage, setErrorMessage] = useState('');

  useEffect(() =>{
    if(columns){
      const resultList = [];

        for (const key in columns) {
        if (columns.hasOwnProperty(key)) {
          const obj = columns[key];
          const status = obj.status;
          obj.items.forEach(item => {
            const newItem = {
              taskId: item.id,
              status: status
            };
            resultList.push(newItem);
          });
        }
      }

      setTasks(resultList)
    }
  }, [columns]);

  const handleSave = async (e) => {
    e.preventDefault();
    try {
      // await save({ tasks });
      console.log(tasks)
    } catch (error) {
      setErrorMessage(error.response?.data?.message || 'Zapisanie nie powiodło się. Spróbuj ponownie.');
    }
  };

  return (
    <>
      <KanbanBoard columns={columns} setColumns={setColumns}/>
      <Button onClick={handleSave} variant="primary">Zapisz</Button>
      {errorMessage && <p className="text-danger">{errorMessage}</p>}
    </>
  );
};

export default Kanban;
