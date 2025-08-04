"use client"


import type { BoardList } from "../models/types"
import { CardItem } from "./card-item"
import { useDroppable } from "@dnd-kit/core"
import { SortableContext, verticalListSortingStrategy } from "@dnd-kit/sortable"
import { Plus } from "lucide-react"

interface BoardListProps {
  list: BoardList
}

export function BoardListComponent({ list }: BoardListProps) {
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


      <button className="w-full mt-2 p-2 text-gray-500 hover:text-gray-700 hover:bg-gray-100 rounded-lg transition-colors flex items-center justify-center gap-2">
        <Plus className="h-4 w-4" />
        Add a card
      </button>
    </div>
  )
}
