import type {
  CreateDeworming,
  UpdateDeworming,
} from "../../interfaces/deworming.interface";

const BASE_URL = "https://localhost:7279/api/deworming";

export const dewormingApi = {
  getDewormings: async () => {
    const response = await fetch(BASE_URL);
    if (!response.ok) {
      throw new Error("Failed retreiving data");
    }
    return response.json();
  },
  getDewormingById: async (id: number) => {
    const response = await fetch(`${BASE_URL}/${id}`);
    if (!response.ok) {
      throw new Error("Failed retreiving data");
    }
    return response.json();
  },
  createDeworming: async (deworming: CreateDeworming) => {
    const response = await fetch(`${BASE_URL}`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(deworming),
    });
    if (!response.ok) {
      throw new Error("Failed recording data");
    }
    return response.json();
  },
  updateDeworming: async (deworming: UpdateDeworming) => {
    const response = await fetch(`${BASE_URL}/${deworming.dewormingId}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(deworming),
    });
    if (!response.ok) {
      throw new Error("Failed updating data");
    }
    return response.json();
  },
  deleteDeworming: async (id: number) => {
    const response = await fetch(`${BASE_URL}/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) {
      throw new Error("Failed deleting data");
    }
    return response.json();
  },
};
