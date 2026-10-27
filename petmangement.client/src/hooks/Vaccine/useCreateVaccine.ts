import { useState } from "react";
import { vaccineApi } from "../../api/vaccine/vaccine.api";
import type { CreateVaccine } from "../../interfaces/vaccine.interface";

export const useCreateVaccine = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const createVaccine = async (vaccine: CreateVaccine) => {
    setLoading(true);
    setError(null);
    try {
      const response = await vaccineApi.createVaccine(vaccine);
      return response;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };

  return { createVaccine, loading, error };
};
