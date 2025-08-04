import { Board } from "../models/Board";

const mockBoards: Board[] = [
  {
    id: "b3f9d4e2-7c1a-4f23-9d0e-5f9a8c2d1e7b",
    title: "Project Alpha",
    createdAt: "2025-08-01T10:15:30Z",
    "color":"red"
  },
  {
    id: "d9a1f6c0-2e58-4b4f-8a30-1f2c9b7e5d4f",
    title: "Marketing Roadmap",
    createdAt: "2025-08-02T14:20:00Z",
    "color":"green"
  },
  {
    id: "f1e2d3c4-b5a6-7d8e-9f00-112233445566",
    title: "Release Planning",
    createdAt: "2025-08-03T08:00:00Z",
    "color":"orange"
  },
];


const API_URL = "http://localhost:3000/";
export const boardService = {
  async fetchBoards(): Promise<Board[]> {
    // const response = await fetch(API_URL);
    // if (!response.ok) {
    //   throw new Error("Failed to fetch boards");
    // }
    // return response.json();
    return new Promise((resolve) => {
      setTimeout(() => resolve(mockBoards), 500);
    });
  },
};
