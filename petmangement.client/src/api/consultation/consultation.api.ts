import type {
  Createconsultation,
  Updateconsultation,
} from "../../interfaces/consultation.interface";

const BASE_URL = "https://localhost:7279/api/consultation";

export const consultationApi = {
  getConsultations: async () => {
    const response = await fetch(BASE_URL);
    if (!response.ok) {
      throw new Error("Failed retreiving data");
    }
    return response.json();
  },

  getConsultationById: async (id: number) => {
    const response = await fetch(`${BASE_URL}/${id}`);
    if (!response.ok) {
      throw new Error("Failed retreiving data");
    }
    return response.json();
  },

  createConsultation: async (consultation: Createconsultation) => {
    const response = await fetch(BASE_URL, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(consultation),
    });
    if (!response.ok) {
      throw new Error("Failed recording data");
    }
    return response.json();
  },

  updateConsultation: async (updateConsultation: Updateconsultation) => {
    const response = await fetch(
      `${BASE_URL}/${updateConsultation.consultationId}`,
      {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(updateConsultation),
      },
    );
    if (!response.ok) {
      throw new Error("Failed updtating data");
    }
    return response.json();
  },

  deleteConsultation: async (id: number) => {
    const response = await fetch(`${BASE_URL}/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) {
      throw new Error("Failed updtating data");
    }
    return response.json();
  },
};
