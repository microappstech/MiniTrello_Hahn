export interface Board {
  id: string
  title: string
  createdAt: string
  lists: BoardList[]
}

export interface Card {
  id: string
  title: string
  description?: string
  listId: string
}

export interface BoardList {
  id: string
  title: string
  boardId: string
  cards: Card[]
}
