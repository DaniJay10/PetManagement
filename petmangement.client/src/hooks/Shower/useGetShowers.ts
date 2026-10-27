import { useState, useEffect } from "react";
import type { Shower } from "../../interfaces/shower.interface";
import { showerApi } from "../../api/shower/shower.api";

export const useGetShowers = () => {
  const [showers, setShowers] = useState<Shower[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const getShowers = async () => {
    setLoading(true);
    setError(null);
    try {
      const data = await showerApi.getShowers();
      setShowers(data);
      return data;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    getShowers();
  }, []);

  return { showers, getShowers, loading, error };
};
