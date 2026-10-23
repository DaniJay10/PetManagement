import { useState, useEffect } from "react";
import type { Deworming } from "../../interfaces/deworming.interface";
import { dewormingApi } from "../../api/deworming/deworming.api";

export const useGetDewormingById = (id: number) => {
  const [deworming, setDeworming] = useState<Deworming | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (!id) return;

    const chargeDeworming = async () => {
      setLoading(true);

      try {
        const data = await dewormingApi.getDewormingById(id);
        setDeworming(data);
        return data;
      } catch (err) {
        setError(err instanceof Error ? err.message : "An error has occurred");
        return null;
      } finally {
        setLoading(false);
      }
    };

    chargeDeworming();
  }, [id]);

  return { deworming, loading, error };
};
