import React from "react";
import { Board } from "../models/Board";
import { Draggable } from "react-beautiful-dnd";

interface Props {
  board: Board;
  index: number;
}
const BoardCard: React.FC<Props> = ({ board, index }) => {
    const initial = board.title.charAt(0).toUpperCase();
  return (
    <Draggable draggableId={board.id} index={index}>
      {(provided) => (
        <div
          {...provided.draggableProps}
          {...provided.dragHandleProps}
          ref={provided.innerRef}
          className="bg-white rounded-2xl shadow-md hover:shadow-lg transition duration-300 p-6 cursor-pointer border border-gray-100 flex items-start gap-4"
        >
          <div className="flex-shrink-0 w-10 h-10 rounded-full border-[5px] border-gray-300 flex items-center justify-center">
            <span className="text-green-600 font-bold text-lg">{initial}</span>
          </div>
          <div>
            <h2 className="text-xl font-semibold text-gray-700">{board.title}</h2>
            <div className="text-xs text-gray-400 mt-2">
              Created on: {new Date(board.createdAt).toLocaleDateString()}
            </div>
          </div>
        </div>
      )}
    </Draggable>
    // <div className="bg-white rounded-2xl shadow-md hover:shadow-lg transition duration-300 p-6 cursor-pointer border border-gray-100 flex items-start gap-4">
    //   <div className="flex-shrink-0 w-10 h-10 rounded-full border-2 border-gray-300 flex items-center justify-center">
    //     <span className="text-green-600 font-bold text-lg">{initial}</span>
    //   </div>
    //   <div>
    //     <h2 className="text-xl font-semibold text-gray-700">{board.title}</h2>
    //     <div className="text-xs text-gray-400 mt-2">
    //       Created on: {new Date(board.createdAt).toLocaleDateString()}
    //     </div>
    //   </div>
    // </div>
  );
};

export default BoardCard;