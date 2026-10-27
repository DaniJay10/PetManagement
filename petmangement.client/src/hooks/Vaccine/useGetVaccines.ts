import { useState, useEffect } from "react";
import type { Vaccine } from "../../interfaces/vaccine.interface";
import { vaccineApi } from "../../api/vaccine/vaccine.api";

export const useGetVaccines = () => {
  const [vaccines, setVaccines] = useState<Vaccine[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const getVaccines = async () => {
    setLoading(false);
    setError(null);
    try {
      const data = await vaccineApi.getVaccines();
      setVaccines(data);
      return data;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    getVaccines();
  }, []);

  return { vaccines, getVaccines, loading, error };
};
