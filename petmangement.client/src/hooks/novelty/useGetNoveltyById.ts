import { useState, useEffect } from "react";
import type { Novelty } from "../../interfaces/novelty.interface";
import { noveltyApi } from "../../api/novelty/novelty.api";

export const useGetNoveltyById = (id: number) => {
  const [novelty, setNovelty] = useState<Novelty | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (!id) return;

    const chargeNovelty = async () => {
      setLoading(true);
      try {
        const data = await noveltyApi.GetNoveltyById(id);
        setNovelty(data);
        return data;
      } catch (err) {
        setError(err instanceof Error ? err.message : "An error has occurred");
        return null;
      } finally {
        setLoading(false);
      }
    };

    chargeNovelty();
  }, [id]);

  return { novelty, loading, error };
};
