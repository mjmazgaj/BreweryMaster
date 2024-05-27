import React from 'react';

import { Draggable } from 'react-beautiful-dnd';
import { CiEdit , CiCircleRemove, CiCircleInfo  } from "react-icons/ci";

const TaskCard = ({ item, index }) => {

  const handleEditClick = (id) => {
    console.log(`edit ${id}`);
  };

  const handleRemoveClick = (id) => {
    console.log(`remove ${id}`);
  };

  const handleDetailClick = (id) => {
    console.log(`detail ${id}`);
  };

  return (
    <Draggable key={item.id} draggableId={item.id} index={index}>
      {(provided) => (
        <div className='task'
          ref={provided.innerRef}
          {...provided.draggableProps}
          {...provided.dragHandleProps}
        >
          <div className='task-header'>
            <p>{item.id}</p>
              <div className='task-icons'>
                <CiCircleInfo  onClick={() => handleDetailClick(item.id)}/>
                <CiEdit onClick={() => handleEditClick(item.id)}/>
                <CiCircleRemove  onClick={() => handleRemoveClick(item.id)}/>
              </div>
            </div>
          <div className='task-information'>
            <p>{item.Task}</p>
            <p>{item.Owner}</p>
            <div className="task-information-secondary-details">
              <p>
                <span>
                  {new Date(item.DueDate).toLocaleDateString('en-us', {
                    month: 'short',
                    day: '2-digit',
                  })}
                </span>
              </p>
            </div>
          </div>
        </div>
      )}
    </Draggable>
  );
};

export default TaskCard;