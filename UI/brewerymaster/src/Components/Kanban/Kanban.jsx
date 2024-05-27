import React, { useState } from 'react';
import { columnsFromBackend } from './KanbanData';

import KanbanBoard from './KanbanBoard';
import "./kanban.css"
import {handleOnDragEnd} from "./KanbanFunctions"

const Kanban = () => {
  const [columns, setColumns] = useState(columnsFromBackend);

  return (
    <>
      <KanbanBoard columns={columns} setColumns={setColumns}/>
    </>
  );
};

export default Kanban;
