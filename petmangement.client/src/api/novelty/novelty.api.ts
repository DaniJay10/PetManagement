import type {
  CreateNovelty,
  UpdateNovelty,
} from "../../interfaces/novelty.interface";

const BASE_URL = "https://localhost:7279/api/novelty";

export const noveltyApi = {
  GetNovelties: async () => {
    const response = await fetch(BASE_URL);
    if (!response.ok) {
      throw new Error("Failed retreiving data");
    }
    return response.json();
  },
  GetNoveltyById: async (id: number) => {
    const response = await fetch(`${BASE_URL}/${id}`);
    if (!response.ok) {
      throw new Error("Failed retreiving data");
    }
    return response.json();
  },
  createNovelty: async (novelty: CreateNovelty) => {
    const response = await fetch(BASE_URL, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(novelty),
    });
    if (!response.ok) {
      throw new Error("Failed recording data");
    }
    return response.json();
  },
  updateNovelty: async (novelty: UpdateNovelty) => {
    const response = await fetch(`${BASE_URL}/${novelty.noveltyId}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(novelty),
    });
    if (!response.ok) {
      throw new Error("Failed updating data");
    }
    return response.json();
  },
  deleteNovelty: async (id: number) => {
    const response = await fetch(`${BASE_URL}/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) {
      throw new Error("Failed deleting data");
    }
    return response.json();
  },
};
