import { useState } from "react";
import { consultationApi } from "../../api/consultation/consultation.api";
import type { Updateconsultation } from "../../interfaces/consultation.interface";

export const useUpdateConsultation = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const updateConsultation = async (consultation: Updateconsultation) => {
    setLoading(true);

    try {
      const response = await consultationApi.updateConsultation(consultation);
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
