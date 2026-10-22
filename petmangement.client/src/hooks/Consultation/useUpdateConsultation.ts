import { useState } from "react";
import { consultationApi } from "../../api/consultation/consultation.api";
import type { Createconsultation } from "../../interfaces/consultation.interface";

export const useUpdateConsultation = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const updateConsultation = async (
    consultationId: number,
    consultation: Createconsultation,
  ) => {
    setLoading(true);

    try {
      const response = await consultationApi.updateConsultation(
        consultationId,
        consultation,
      );
      return response;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };
  return { updateConsultation, loading, error };
};
