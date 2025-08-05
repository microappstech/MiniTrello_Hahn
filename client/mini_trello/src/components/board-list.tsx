"use client"


import type { BoardList } from "../models/types"
import { CardItem } from "./card-item"
import { useDroppable } from "@dnd-kit/core"
import { SortableContext, verticalListSortingStrategy } from "@dnd-kit/sortable"
import { Plus, X } from "lucide-react"
import { useState } from "react"
import { Button } from "./ui/button"

interface BoardListProps {
  list: BoardList,
    onAddCard: (listId: string, title: string, description: string) => void

}

export function BoardListComponent({ list , onAddCard}: BoardListProps) 
{
    const [isAddingCard, setIsAddingCard] = useState(false)
  const [newCardTitle, setNewCardTitle] = useState("")
  const [newCardDescription, setNewCardDescription] = useState("")

  const { setNodeRef } = useDroppable({
    id: list.id,
  })
  return (
    <div className="bg-gray-50 rounded-lg p-4 w-80 flex-shrink-0">
      <div className="flex items-center justify-between mb-4">
        <h3 className="font-semibold text-gray-800">{list.title}</h3>
        <span className="bg-gray-200 text-gray-600 text-xs px-2 py-1 rounded-full">{list.cards?.length}</span>
      </div>

      {list.cards && list.cards.length > 0 && (
        <div ref={setNodeRef} className="min-h-[200px]">
          <SortableContext
            items={list.cards.map((card) => card.id)}
            strategy={verticalListSortingStrategy}
          >
            {list.cards.map((card) => (
              <CardItem key={card.id} card={card} />
            ))}
          </SortableContext>
        </div>
      )}

{isAddingCard ? (
        <div className="bg-white rounded-lg border border-gray-200 p-3 mt-2">
          <input
            type="text"
            placeholder="Enter card title..."
            value={newCardTitle}
            onChange={(e) => setNewCardTitle(e.target.value)}
            className="w-full p-2 text-sm border border-gray-300 rounded mb-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
            autoFocus
          />
          <textarea
            placeholder="Enter description (optional)..."
            value={newCardDescription}
            onChange={(e) => setNewCardDescription(e.target.value)}
            className="w-full p-2 text-sm border border-gray-300 rounded mb-3 resize-none focus:outline-none focus:ring-2 focus:ring-blue-500"
            rows={2}
          />
          <div className="flex gap-2">
            <Button
              onClick={() => {
                if (newCardTitle.trim()) {
                  onAddCard(list.id, newCardTitle.trim(), newCardDescription.trim())
                  setNewCardTitle("")
                  setNewCardDescription("")
                  setIsAddingCard(false)
                }
              }}
              size="sm"
              disabled={!newCardTitle.trim()}
            >
              Add Card
            </Button>
            <Button
              onClick={() => {
                setIsAddingCard(false)
                setNewCardTitle("")
                setNewCardDescription("")
              }}
              variant="outline"
              size="sm"
            >
              <X className="h-4 w-4" />
            </Button>
          </div>
        </div>
      ) : (
        <button
          onClick={() => setIsAddingCard(true)}
          className="w-full mt-2 p-2 text-gray-500 hover:text-gray-700 hover:bg-gray-100 rounded-lg transition-colors flex items-center justify-center gap-2"
        >
          <Plus className="h-4 w-4" />
          Add a card
        </button>
      )}
    </div>
  )
}
