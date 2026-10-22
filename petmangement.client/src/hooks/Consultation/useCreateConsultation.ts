import { useState } from "react";
import type { Createconsultation } from "../../interfaces/consultation.interface";
import { consultationApi } from "../../api/consultation/consultation.api";

export const useCreateConsultation = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const createConsultation = async (consultation: Createconsultation) => {
    setLoading(true);

    try {
      const response = await consultationApi.createConsultation(consultation);
      return response;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };

  return { createConsultation, loading, error };
};
