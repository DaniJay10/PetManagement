import { useState } from "react";
import { expedientApi } from "../../api/expedient/expedient.api";
import type { Expedient } from "../../interfaces/expedient.interface";

export const useExpedient = () => {
  const [expedient, setExpedient] = useState<Expedient | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const getExpedient = async (petId: number) => {
    setLoading(true);
    setError(null);
    try {
      const data: Expedient = await expedientApi.getExpedient(petId);
      setExpedient(data);
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
    } finally {
      setLoading(false);
    }
  };

  return {
    expedient,
    getExpedient,
    loading,
    error,
  };
};
