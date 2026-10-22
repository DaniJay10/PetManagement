import { useState, useEffect } from "react";
import type { consultation } from "../../interfaces/consultation.interface";
import { consultationApi } from "../../api/consultation/consultation.api";

export const useGetConsultationById = (id: number) => {
  const [consultation, setConsultation] = useState<consultation | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (!id) return;

    const chargeConsultation = async () => {
      setLoading(true);

      try {
        const data = await consultationApi.getConsultationById(id);
        setConsultation(data);
        return data;
      } catch (err) {
        setError(err instanceof Error ? err.message : "An error has occurred");
        return null;
      } finally {
        setLoading(false);
      }
    };

    chargeConsultation();
  }, [id]);

  return { consultation, loading, error };
};
