import { useState, useEffect } from "react";
import type { Deworming } from "../../interfaces/deworming.interface";
import { dewormingApi } from "../../api/deworming/deworming.api";

export const useGetDewormings = () => {
  const [dewormings, setDewormings] = useState<Deworming[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const getDewormings = async () => {
    setLoading(true);
    setError(null);
    try {
      const data = await dewormingApi.getDewormings();
      setDewormings(data);
      return data;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    getDewormings();
  }, []);

  return { dewormings, getDewormings, loading, error };
};
