export interface Board {
  id: string
  name: string
  createdAt: string
  lists: BoardList[]
}
export interface CreateCardDto {
  title: string;
  description: string;
  listId: string;
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
