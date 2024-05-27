import React from 'react';
import { Draggable } from 'react-beautiful-dnd';

const TaskCard = ({ item, index }) => {
  console.log(item)
  return (
    <Draggable key={item.id} draggableId={item.id} index={index}>
      {(provided) => (
        <div
          ref={provided.innerRef}
          {...provided.draggableProps}
          {...provided.dragHandleProps}
        >
          <div className='task-information'>
            <p>{item.Task}</p>
            <div className="task-information-secondary-details">
              <p>
                <span>
                  {new Date(item.Due_Date).toLocaleDateString('en-us', {
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