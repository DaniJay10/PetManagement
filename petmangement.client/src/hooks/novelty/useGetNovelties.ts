import { useState, useEffect } from "react";
import type { Novelty } from "../../interfaces/novelty.interface";
import { noveltyApi } from "../../api/novelty/novelty.api";

export const useGetNovelties = () => {
  const [novelties, setNovelties] = useState<Novelty[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const GetNovelties = async () => {
    setLoading(true);
    try {
      const data = await noveltyApi.GetNovelties();
      +setNovelties(data);
      return data;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    GetNovelties();
  }, []);

  return { novelties, GetNovelties, loading, error };
};
