import { useState, useEffect } from "react";
import type { Vaccine } from "../../interfaces/vaccine.interface";
import { vaccineApi } from "../../api/vaccine/vaccine.api";

export const useGetVaccineById = (id: number) => {
  const [vaccine, setVaccine] = useState<Vaccine | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (!id) return;

    const chargeVaccine = async () => {
      setLoading(true);

      try {
        const data = await vaccineApi.getVaccineById(id);
        setVaccine(data);
        return data;
      } catch (err) {
        setError(err instanceof Error ? err.message : "An error has occurred");
        return null;
      } finally {
        setLoading(false);
      }
    };

    chargeVaccine();
  }, [id]);

  return { vaccine, loading, error };
};
