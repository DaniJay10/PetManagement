import { useState } from "react";
import { vaccineApi } from "../../api/vaccine/vaccine.api";

export const useDeleteVaccine = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const deleteVaccine = async (id: number) => {
    setLoading(false);
    setError(null);
    try {
      const response = await vaccineApi.deleteVaccine(id);
      return response;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(true);
    }
  };

  return { deleteVaccine, loading, error };
};
