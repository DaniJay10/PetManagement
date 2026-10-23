import type { CreatePet, UpdatePet } from "../../interfaces/pet.interface";

const BASE_URL = "https://localhost:7279/api/pet";

export const petApi = {
  getPets: async () => {
    const response = await fetch(BASE_URL);
    if (!response.ok) {
      throw new Error("Error al obtener las mascotas");
    }
    return response.json();
  },

  getPetById: async (id: number) => {
    const response = await fetch(`${BASE_URL}/${id}`);
    if (!response.ok) {
      throw new Error("Error al obtener la mascota");
    }
    return response.json();
  },

  createPet: async (pet: CreatePet) => {
    const response = await fetch(BASE_URL, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(pet),
    });
    if (!response.ok) {
      throw new Error("Error al crear la mascota");
    }
    return response.json();
  },

  updatePet: async (updatedPet: UpdatePet) => {
    const response = await fetch(`${BASE_URL}/${updatedPet.petId}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(updatedPet),
    });
    if (!response.ok) {
      throw new Error("Error al actualizar la mascota");
    }
    return response.json();
  },

  deletePet: async (id: number) => {
    const response = await fetch(`${BASE_URL}/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) {
      throw new Error("Error al eliminar la mascota");
    }
    return response.json();
  },
};
