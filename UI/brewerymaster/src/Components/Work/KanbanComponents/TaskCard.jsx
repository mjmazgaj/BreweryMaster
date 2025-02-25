import React from "react";

import { Draggable } from "react-beautiful-dnd";
import { CiEdit, CiCircleRemove } from "react-icons/ci";

import { useTaskCard } from "./helpers/useTaskCard";

const TaskCard = ({ item, index, setShowEditModal, setShowDeleteModal, setModalData }) => {
  const { handleEditClick, handleRemoveClick } = useTaskCard({
    setShowEditModal,
    setShowDeleteModal,
    setModalData,
  });

  return (
    <Draggable key={item.id} draggableId={`${item.id}`} index={index}>
      {(provided) => (
        <div
          className="task"
          ref={provided.innerRef}
          {...provided.draggableProps}
          {...provided.dragHandleProps}
        >
          <div className="task-header">
            <p>{item.id}</p>
            <div className="task-icons">
              <CiEdit onClick={() => handleEditClick(item)} />
              <CiCircleRemove onClick={() => handleRemoveClick(item)} />
            </div>
          </div>
          <div className="task-information">
            <p>{item.title}</p>
            <p>{item.ownerName}</p>
            <p>{item.summary}</p>
            <div className="task-information-secondary-details">
              <p>
                <span>
                  {new Date(item.dueDate).toLocaleDateString("en-us", {
                    month: "short",
                    day: "2-digit",
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
