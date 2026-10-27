import { useState, useEffect } from "react";
import type { Shower } from "../../interfaces/shower.interface";
import { showerApi } from "../../api/shower/shower.api";

export const useGetShoweById = (id: number) => {
  const [shower, setShower] = useState<Shower | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (!id) return;

    const chargeShower = async () => {
      setLoading(true);
      setError(null);
      try {
        const data = await showerApi.getShowerById(id);
        setShower(data);
        return data;
      } catch (err) {
        setError(err instanceof Error ? err.message : "An error has occurred");
        return null;
      } finally {
        setLoading(false);
      }
    };

    chargeShower();
  }, [id]);

  return { shower, loading, error };
};
