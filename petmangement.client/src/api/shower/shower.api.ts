import type { CreateShower } from "../../interfaces/shower.interface";

const BASE_URL = "https://localhost:7279/api/shower";

export const showerApi = {
  getShowers: async () => {
    const response = await fetch(BASE_URL);
    if (!response.ok) {
      throw new Error("Failed retreiving data");
    }
    return response.json();
  },
  getShowerById: async (id: number) => {
    const response = await fetch(`${BASE_URL}/${id}`);
    if (!response.ok) {
      throw new Error("Failed retreiving data");
    }
    return response.json();
  },
  createShower: async (shower: CreateShower) => {
    const response = await fetch(BASE_URL, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(shower),
    });
    if (!response.ok) {
      throw new Error("Failed recording data");
    }
    return response.json();
  },
  updateShower: async (id: number, shower: CreateShower) => {
    const response = await fetch(`${BASE_URL}/${id}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(shower),
    });
    if (!response.ok) {
      throw new Error("Failed updating data");
    }
    return response.json();
  },
  deleteShower: async (id: number) => {
    const response = await fetch(`${BASE_URL}/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) {
      throw new Error("Failed deleting data");
    }
    return response.json();
  },
};
