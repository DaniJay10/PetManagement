const BASE_URL = "https://localhost:7279/api/expedient";

export const expedientApi = {
  getExpedient: async (petId: number) => {
    const response = await fetch(`${BASE_URL}/${petId}`);
    if (!response.ok) {
      throw new Error("Failed on get Expedient");
    }
    return response.json();
  },
};
