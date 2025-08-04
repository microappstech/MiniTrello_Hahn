import React, { useEffect, useState } from "react";
import { Board } from "../../models/Board";
import { boardService } from "../../services/boardService";
import BoardCard from "../../components/BoardCard";
import { DragDropContext, Droppable, DropResult } from "react-beautiful-dnd";

const BoardsPage: React.FC = () => {
  const [boards, setBoards] = useState<Board[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const loadBoards = async () => {
      try {
        const data = await boardService.fetchBoards();
        setBoards(data);
      } catch (err) {
        setError("Failed to load boards.");
      } finally {
        setLoading(false);
      }
    };

    loadBoards();
  }, []);
 const handleDragEnd = (result: DropResult) => {
    if (!result.destination) return;
    const reordered = Array.from(boards);
    const [removed] = reordered.splice(result.source.index, 1);
    reordered.splice(result.destination.index, 0, removed);
    setBoards(reordered);
  };

  if (loading) return <div className="p-10 text-gray-600">Loading...</div>;
  if (error) return <div className="p-10 text-red-500">{error}</div>;

  return (
    <div className="min-h-screen bg-gray-50 py-10 px-6">
      <div className="max-w-7xl mx-auto">
        <h1 className="text-3xl font-bold text-gray-800 mb-6">Your Boards</h1>
        <DragDropContext onDragEnd={handleDragEnd}>
          <Droppable droppableId="board-list">
            {(provided) => (
              <div
                className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6"
                {...provided.droppableProps}
                ref={provided.innerRef}
              >
                {boards.map((board, index) => (
                  <BoardCard key={board.id} board={board} index={index} />
                ))}
                {provided.placeholder}
              </div>
            )}
          </Droppable>
        </DragDropContext>
      </div>
    </div>
  );
};

export default BoardsPage;
