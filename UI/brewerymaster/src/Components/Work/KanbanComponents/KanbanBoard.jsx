import React from "react";
import { DragDropContext, Droppable } from "react-beautiful-dnd";
import TaskCard from "./TaskCard";
import "../kanban.css";
import { handleOnDragEnd } from "./KanbanFunctions";
import { useTranslation } from "react-i18next";

const KanbanBoard = ({
  columns,
  setColumns,
  setShowEditModal,
  setShowDeleteModal,
  setModalData,
}) => {
  const { t } = useTranslation();

  const columnNames = {
    1: t("status.todo"),
    2: t("status.inProgress"),
    3: t("status.done"),
  };

  return (
    <DragDropContext
      onDragEnd={(result) => handleOnDragEnd(result, columns, setColumns)}
    >
      <div className="kanban-board_container">
        <div className="kanban-board-column_container">
          {Object.entries(columns).map(([columnId, column], index) => {
            return (
              <Droppable key={columnId} droppableId={columnId}>
                {(provided) => (
                  <div
                    className="kanban-board-column"
                    ref={provided.innerRef}
                    {...provided.droppableProps}
                  >
                    <div className="kanban-board-column_title">
                      {columnNames[column.status]}
                    </div>
                    {column.items?.map((item, index) => (
                      <TaskCard
                        key={index}
                        item={item}
                        index={index}
                        setShowEditModal={setShowEditModal}
                        setShowDeleteModal={setShowDeleteModal}
                        setModalData={setModalData}
                      />
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

export default KanbanBoard;
