import { useState } from "react";
import { consultationApi } from "../../api/consultation/consultation.api";

export const useDeleteConsultation = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const deleteConsultation = async (consultationId: number) => {
    setLoading(true);
    setError(null);
    try {
      const response = await consultationApi.deleteConsultation(consultationId);
      return response;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };

  return { deleteConsultation, loading, error };
};
