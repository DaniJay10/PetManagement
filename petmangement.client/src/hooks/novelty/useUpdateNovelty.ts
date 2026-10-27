import { useState } from "react";
import type { UpdateNovelty } from "../../interfaces/novelty.interface";
import { noveltyApi } from "../../api/novelty/novelty.api";

export const useUpdateNovelty = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const updateNovelty = async (novelty: UpdateNovelty) => {
    setLoading(true);
    setError(null);
    try {
      const response = await noveltyApi.updateNovelty(novelty);
      return response;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };

  return { updateNovelty, loading, error };
};
