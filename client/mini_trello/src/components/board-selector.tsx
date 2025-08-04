"use client"

import type { Board } from "../models/types"
import { Calendar, ChevronDown, Import } from "lucide-react"
import { DropdownMenu , DropdownMenuContent, DropdownMenuItem, DropdownMenuTrigger } from "@radix-ui/react-dropdown-menu"
// import { DropdownMenu, DropdownMenuContent, DropdownMenuItem, DropdownMenuTrigger } from "@/components/ui/dropdown-menu"

import { Button } from "./ui/button"

interface BoardSelectorProps {
  boards: Board[]
  selectedBoard: Board | null
  onBoardSelect: (board: Board) => void
}

export function BoardSelector({ boards, selectedBoard, onBoardSelect }: BoardSelectorProps) {
  return (
    <div className="flex items-center gap-4 mb-6">
      <div>
        <h1 className="text-2xl font-bold text-gray-900">{selectedBoard ? selectedBoard.name : "Select a Board"}</h1>
        {selectedBoard && (
          <p className="text-gray-600 flex items-center gap-1">
            <Calendar className="h-4 w-4" />
            Created on {new Date(selectedBoard.createdAt).toLocaleDateString()}
          </p>
        )}
      </div>

      <DropdownMenu>
        <DropdownMenuTrigger asChild>
          <Button variant="outline" className="ml-auto bg-transparent">
            Switch Board
            <ChevronDown className="ml-2 h-4 w-4" />
          </Button>
        </DropdownMenuTrigger>
        <DropdownMenuContent align="end" className="w-64">
          {boards.map((board) => (
            <DropdownMenuItem
              key={board.id}
              onClick={() => onBoardSelect(board)}
              className="flex flex-col items-start p-3"
            >
              <div className="font-medium">{board.name}</div>
              <div className="text-sm text-gray-500">
                {board.lists?.length} lists • {board.lists?.reduce((acc, list) => acc + list.cards?.length, 0)} cards
              </div>
            </DropdownMenuItem>
          ))}
        </DropdownMenuContent>
      </DropdownMenu>
    </div>
  )
}
