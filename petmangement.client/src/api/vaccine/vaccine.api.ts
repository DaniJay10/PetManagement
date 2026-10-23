import type {
  CreateVaccine,
  UpdateVaccine,
} from "../../interfaces/vaccine.interface";

const BASE_URL = "https://localhost:7279/api/vaccine";

export const vaccineApi = {
  getVaccines: async () => {
    const response = await fetch(BASE_URL);
    if (!response.ok) {
      throw new Error("Failed retreiving data");
    }
    return response.json();
  },
  getVaccineById: async (id: number) => {
    const response = await fetch(`${BASE_URL}/${id}`);
    if (!response.ok) {
      throw new Error("Failed retreiving data");
    }
    return response.json();
  },
  createVaccine: async (vaccine: CreateVaccine) => {
    const response = await fetch(BASE_URL, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(vaccine),
    });
    if (!response.ok) {
      throw new Error("Failed recording data");
    }
    return response.json();
  },
  updateVaccine: async (vaccine: UpdateVaccine) => {
    const response = await fetch(`${BASE_URL}/${vaccine.vaccineId}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(vaccine),
    });
    if (!response.ok) {
      throw new Error("Failed updating data");
    }
    return response.json();
  },
  deleteVaccine: async (id: number) => {
    const response = await fetch(`${BASE_URL}/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) {
      throw new Error("Failed deleting data");
    }
    return response.json();
  },
};
