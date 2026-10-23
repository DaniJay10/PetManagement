import { useState } from "react";
import { noveltyApi } from "../../api/novelty/novelty.api";

export const useDeleteNovelty = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const deleteNovelty = async (id: number) => {
    setLoading(true);
    try {
      const response = await noveltyApi.deleteNovelty(id);
      return response;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };

  return { deleteNovelty, loading, error };
};
