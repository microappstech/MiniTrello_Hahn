"use client"

import { useState, useEffect } from "react"
import type { Board, Card, BoardList, CreateCardDto } from "../../models/types"
import { BoardListComponent } from "../../components/board-list"
import { BoardSelector } from "../../components/board-selector"
import { boardService } from "../../services/boardService"
import {
  DndContext,
  type DragEndEvent,
  type DragOverEvent,
  DragOverlay,
  type DragStartEvent,
  PointerSensor,
  useSensor,
  useSensors,
} from "@dnd-kit/core"
import { arrayMove } from "@dnd-kit/sortable"
import { CardItem } from "../../components/card-item"

export function KanbanBoard() {
  const [boards, setBoards] = useState<Board[]>([])
  const [selectedBoard, setSelectedBoard] = useState<Board | null>(null)
  const [activeCard, setActiveCard] = useState<Card | null>(null)
  const [loading, setLoading] = useState(true)

  const sensors = useSensors(
    useSensor(PointerSensor, {
      activationConstraint: {
        distance: 8,
      },
    }),
  )

  useEffect(() => {
    const loadBoards = async () => {
      try {
        setLoading(true)
        const data = await boardService.fetchBoards()
        setBoards(data)
        if (data.length > 0) {
          setSelectedBoard(data[0]) // Select first board by default
        }
      } catch (error) {
        console.error("Failed to load boards:", error)
      } finally {
        setLoading(false)
      }
    }

    loadBoards()
  }, [])

  const handleBoardSelect = (board: Board) => {
    setSelectedBoard(board)
  }

  const handleDragStart = (event: DragStartEvent) => {
    const { active } = event
    const card = findCard(active.id as string)
    setActiveCard(card??null)
  }

  const handleDragOver = (event: DragOverEvent) => {
    const { active, over } = event
    if (!over || !selectedBoard) return

    const activeId = active.id as string
    const overId = over.id as string

    const activeCard = findCard(activeId)
    const overCard = findCard(overId)

    if (!activeCard) return

    const activeList = findList(activeCard.listId)
    const overList = overCard ? findList(overCard.listId) : findList(overId)

    if (!activeList || !overList) return

    if (activeList.id !== overList.id) {
      setSelectedBoard((prev) => {
        if (!prev) return prev

        const newBoard = { ...prev }
        const newLists = newBoard.lists.map((list) => ({ ...list, cards: [...list.cards] }))

        const activeListIndex = newLists.findIndex((list) => list.id === activeList.id)
        const overListIndex = newLists.findIndex((list) => list.id === overList.id)

        const activeCardIndex = newLists[activeListIndex].cards.findIndex((card) => card.id === activeId)
        const overCardIndex = overCard ? newLists[overListIndex].cards.findIndex((card) => card.id === overId) : 0

        const [movedCard] = newLists[activeListIndex].cards.splice(activeCardIndex, 1)
        movedCard.listId = overList.id
        newLists[overListIndex].cards.splice(overCardIndex, 0, movedCard)

        return { ...newBoard, lists: newLists }
      })
    }
  }

  const handleDragEnd = async (event: DragEndEvent) => {
    const { active, over } = event
    setActiveCard(null)

    if (!over || !selectedBoard) return

    const activeId = active.id as string
    const overId = over.id as string

    const activeCard = findCard(activeId)
    const overCard = findCard(overId)

    if (!activeCard) return

    const activeList = findList(activeCard.listId)
    const overList = overCard ? findList(overCard.listId) : findList(overId)

    if (!activeList || !overList) return

    if (activeList.id === overList.id) {
      setSelectedBoard((prev) => {
        if (!prev) return prev

        const newBoard = { ...prev }
        const newLists = newBoard.lists.map((list) => ({ ...list, cards: [...list.cards] }))

        const listIndex = newLists.findIndex((list) => list.id === activeList.id)
        const activeIndex = newLists[listIndex].cards.findIndex((card) => card.id === activeId)
        const overIndex = newLists[listIndex].cards.findIndex((card) => card.id === overId)

        newLists[listIndex].cards = arrayMove(newLists[listIndex].cards, activeIndex, overIndex)

        return { ...newBoard, lists: newLists }
      })
    }



    if (selectedBoard) {
      try {
        await boardService.updateBoard(selectedBoard)
        setBoards((prev) => prev.map((board) => (board.id === selectedBoard.id ? selectedBoard : board)))
      } catch (error) {
        console.error("Failed to update board:", error)
      }
    }
  }

  const findCard = (cardId: string): Card | undefined => {
    if (!selectedBoard) return undefined

    for (const list of selectedBoard.lists) {
      const card = list.cards.find((card) => card.id === cardId)
      if (card) return card
    }
    return undefined
  }

  const findList = (listId: string): BoardList | undefined => {
    if (!selectedBoard) return undefined
    return selectedBoard.lists.find((list) => list.id === listId)
  }

  const handleAddCard = async (listId: string, title: string, description: string) => {
  if (!selectedBoard) return;

  const newCard: CreateCardDto = {
    title,
    description,
    listId,
  };

  try {
    await boardService.createCard(newCard);
    alert("Card created successfully");

    // Reset form
    // setTitle("");
    // setDescription("");

    // Update UI locally
    setSelectedBoard((prev) => {
      if (!prev) return prev;

      const updatedLists = prev.lists.map((list) => {
        if (list.id === listId) {
          return {
            ...list,
            cards: [...list.cards, { ...newCard }],
          };
        }
        return list;
      });

      const updatedBoard = { ...prev, lists: updatedLists };

      // Optionally persist the updated board to local storage or server
      boardService.updateBoard(updatedBoard).catch((error) => {
        console.error("Failed to update board:", error);
      });

      return updatedBoard;
    });
  } catch (error) {
    console.error("Create card error:", error);
    alert("Failed to create card");
  }
};
  
  if (loading) {
    return (
      <div className="flex items-center justify-center min-h-screen">
        <div className="animate-spin rounded-full h-32 w-32 border-t-2 border-b-2 border-blue-600"></div>
      </div>
    )
  }

  return (
    <div className="p-6">
      <BoardSelector boards={boards} selectedBoard={selectedBoard} onBoardSelect={handleBoardSelect} />

      {selectedBoard ? (
        <DndContext
          sensors={sensors}
          onDragStart={handleDragStart}
          onDragOver={handleDragOver}
          onDragEnd={handleDragEnd}
        >
          <div className="flex gap-6 overflow-x-auto pb-4">
            {selectedBoard.lists?.map((list) => (
              <BoardListComponent key={list.id} list={list} onAddCard={handleAddCard} />
            ))}
          </div>

          <DragOverlay>{activeCard ? <CardItem card={activeCard} /> : null}</DragOverlay>
        </DndContext>
      ) : (
        <div className="text-center py-12">
          <p className="text-gray-500">No boards available. Please create a board first.</p>
        </div>
      )}
    </div>
  )
}
