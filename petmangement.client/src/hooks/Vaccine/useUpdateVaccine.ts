import { useState } from "react";
import { vaccineApi } from "../../api/vaccine/vaccine.api";
import type { UpdateVaccine } from "../../interfaces/vaccine.interface";

export const useUpdateVaccine = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const updateVaccine = async (vaccine: UpdateVaccine) => {
    setLoading(false);
    setError(null);
    try {
      const response = await vaccineApi.updateVaccine(vaccine);
      return response;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };

  return { updateVaccine, loading, error };
};
