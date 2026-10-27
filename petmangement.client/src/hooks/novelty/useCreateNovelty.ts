import { useState } from "react";
import type { CreateNovelty } from "../../interfaces/novelty.interface";
import { noveltyApi } from "../../api/novelty/novelty.api";

export const useCreateNovelty = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const createNovelty = async (novelty: CreateNovelty) => {
    setLoading(true);
    setError(null);
    try {
      const response = await noveltyApi.createNovelty(novelty);
      return response;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };

  return { createNovelty, loading, error };
};
