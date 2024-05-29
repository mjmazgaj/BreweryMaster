import React, { useEffect, useState } from 'react';
import Button from 'react-bootstrap/Button';
import KanbanBoard from './KanbanBoard';
import './kanban.css';

import {fetchDataByOwnerId} from './api';

const Kanban = () => {
  const [columns, setColumns] = useState(null);
  const [tasks, setTasks] = useState([]);
  const [errorMessage, setErrorMessage] = useState('');

useEffect(() => {
  const getData = () => {
    fetchDataByOwnerId(1)
    .then((result) => setColumns(result))
    .catch((error) => console.log(error));
  };
  getData()
}, [])

  useEffect(() => {
    if (columns) {
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

      setTasks(resultList);
    }
  }, [columns]);

  const handleSave = async (e) => {
    e.preventDefault();
    try {
      // await save({ tasks });
      console.log(tasks);
    } catch (error) {
      setErrorMessage(error.response?.data?.message || 'Zapisanie nie powiodło się. Spróbuj ponownie.');
    }
  };

  return (
    <>
      {columns ? (
        <>
          <KanbanBoard columns={columns} setColumns={setColumns} />
          <Button onClick={handleSave} variant="primary">Zapisz</Button>
        </>
      ) : (
        <p>Loading...</p>
      )}
      {errorMessage && <p className="text-danger">{errorMessage}</p>}
    </>
  );
};

export default Kanban;
