import { useState, useEffect } from "react";
import type { consultation } from "../../interfaces/consultation.interface";
import { consultationApi } from "../../api/consultation/consultation.api";

export const useGetConsultations = () => {
  const [consultations, setConsultations] = useState<consultation[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const getConsultations = async () => {
    setLoading(true);

    try {
      const data = await consultationApi.getConsultations();
      setConsultations(data);
      return data;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    getConsultations();
  }, []);

  return { getConsultations, consultations, loading, error };
};
