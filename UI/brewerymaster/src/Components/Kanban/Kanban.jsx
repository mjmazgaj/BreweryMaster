import React, { useState } from 'react';
import { columnsFromBackend } from './KanbanData';
import { DragDropContext, Droppable } from 'react-beautiful-dnd';
import TaskCard from './TaskCard';
import "./kanban.css"
import {handleOnDragEnd} from "./KanbanFunctions"

const Kanban = () => {
  const [columns, setColumns] = useState(columnsFromBackend);

  return (
    <DragDropContext
      onDragEnd={(result) => handleOnDragEnd(result, columns, setColumns)}
    >
      <div className='task-container'>
        <div className='task-column'>
          {Object.entries(columns).map(([columnId, column], index) => {
            return (
              <Droppable key={columnId} droppableId={columnId}>
                {(provided) => (
                  <div className='task-list'
                    ref={provided.innerRef}
                    {...provided.droppableProps}
                  >
                    <div className='title'>{column.title}</div>
                    {column.items.map((item, index) => (
                      <TaskCard key={item} item={item} index={index} />
                    ))}
                    {provided.placeholder}
                  </div>
                )}
              </Droppable>
            );
          })}
        </div>
      </div>
    </DragDropContext>
  );
};

export default Kanban;
