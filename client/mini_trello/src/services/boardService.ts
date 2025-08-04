import { Board } from "../models/types";


// Mock service - replace with actual API calls
class BoardService {
  private mockBoards: Board[] = [
    {
      id: "1",
      title: "Project Management Board",
      createdAt: "2024-01-15T10:00:00Z",
      lists: [
        {
          id: "list-1",
          title: "To Do",
          boardId: "1",
          cards: [
            {
              id: "card-1",
              title: "Design Homepage",
              description: "Create wireframes and mockups for the homepage",
              listId: "list-1",
            },
            {
              id: "card-2",
              title: "Setup Database",
              description: "Configure PostgreSQL database with initial schema",
              listId: "list-1",
            },
          ],
        },
        {
          id: "list-2",
          title: "In Progress",
          boardId: "1",
          cards: [
            {
              id: "card-4",
              title: "API Development",
              description: "Build REST API endpoints for user management",
              listId: "list-2",
            },
          ],
        },
        {
          id: "list-3",
          title: "Done",
          boardId: "1",
          cards: [
            {
              id: "card-7",
              title: "Project Setup",
              description: "Initialize project structure and dependencies",
              listId: "list-3",
            },
          ],
        },
      ],
    },
    {
      id: "2",
      title: "Marketing Campaign",
      createdAt: "2024-01-20T14:30:00Z",
      lists: [
        {
          id: "list-4",
          title: "Planning",
          boardId: "2",
          cards: [
            {
              id: "card-10",
              title: "Market Research",
              description: "Analyze target audience and competitors",
              listId: "list-4",
            },
            {
              id: "card-11",
              title: "Content Strategy",
              description: "Plan content calendar and messaging",
              listId: "list-4",
            },
          ],
        },
        {
          id: "list-5",
          title: "Execution",
          boardId: "2",
          cards: [
            {
              id: "card-12",
              title: "Social Media Posts",
              description: "Create and schedule social media content",
              listId: "list-5",
            },
          ],
        },
        {
          id: "list-6",
          title: "Review",
          boardId: "2",
          cards: [],
        },
      ],
    },
    {
      id: "3",
      title: "Bug Tracking",
      createdAt: "2024-01-25T09:15:00Z",
      lists: [
        {
          id: "list-7",
          title: "Reported",
          boardId: "3",
          cards: [
            {
              id: "card-13",
              title: "Login Issue",
              description: "Users unable to login with Google OAuth",
              listId: "list-7",
            },
            {
              id: "card-14",
              title: "Mobile Responsive",
              description: "Header not displaying correctly on mobile",
              listId: "list-7",
            },
          ],
        },
        {
          id: "list-8",
          title: "In Progress",
          boardId: "3",
          cards: [
            {
              id: "card-15",
              title: "Database Connection",
              description: "Fix intermittent database connection issues",
              listId: "list-8",
            },
          ],
        },
        {
          id: "list-9",
          title: "Fixed",
          boardId: "3",
          cards: [
            {
              id: "card-16",
              title: "CSS Layout Bug",
              description: "Fixed sidebar overlap issue",
              listId: "list-9",
            },
          ],
        },
      ],
    },
  ]

  
  // async fetchBoards(): Promise<Board[]> {
  //   // const response = await fetch(API_URL);
  //   // if (!response.ok) {
  //   //   throw new Error("Failed to fetch boards");
  //   // }
  //   // return response.json();
  //   return new Promise((resolve) => {
  //     setTimeout(() => resolve(mockBoards), 500);
  //   });

  async fetchBoards(): Promise<Board[]> {
    // Simulate API delay
    await new Promise((resolve) => setTimeout(resolve, 500))

    // In a real application, this would be an API call:
    // const response = await fetch('/api/boards')
    // return response.json()

    return this.mockBoards
  }

  async fetchBoardById(id: string): Promise<Board | null> {
    await new Promise((resolve) => setTimeout(resolve, 300))
    return this.mockBoards.find((board) => board.id === id) || null
  }

  async updateBoard(board: Board): Promise<Board> {
    await new Promise((resolve) => setTimeout(resolve, 200))

    const index = this.mockBoards.findIndex((b) => b.id === board.id)
    if (index !== -1) {
      this.mockBoards[index] = board
    }

    return board
  }
}

export const boardService = new BoardService()

