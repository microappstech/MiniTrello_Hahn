"use client"

import type { Card } from "../models/types"
import { useSortable } from "@dnd-kit/sortable"
import { CSS } from "@dnd-kit/utilities"
import { GripVertical } from "lucide-react"

interface CardItemProps {
  card: Card
}

export function CardItem({ card }: CardItemProps) {
  const { attributes, listeners, setNodeRef, transform, transition, isDragging } = useSortable({
    id: card.id,
  })

  const style = {
    transform: CSS.Transform.toString(transform),
    transition,
  }

  return (
    <div
      ref={setNodeRef}
      style={style}
      {...attributes}
      className={`bg-white rounded-lg shadow-sm border border-gray-200 p-3 mb-2 cursor-pointer hover:shadow-md transition-shadow ${
        isDragging ? "opacity-50" : ""
      }`}
    >
      <div className="flex items-start justify-between">
        <div className="flex-1">
          <h4 className="font-medium text-gray-900 mb-1">{card.title}</h4>
          {card.description && <p className="text-sm text-gray-600 line-clamp-2">{card.description}</p>}
        </div>
        <div {...listeners} className="ml-2 p-1 hover:bg-gray-100 rounded cursor-grab active:cursor-grabbing">
          <GripVertical className="h-4 w-4 text-gray-400" />
        </div>
      </div>
    </div>
  )
}
