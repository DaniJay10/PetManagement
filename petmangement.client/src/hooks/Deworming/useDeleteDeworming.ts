import { useState } from "react";
import { dewormingApi } from "../../api/deworming/deworming.api";

export const useDeleteDeworming = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const deleteDeworming = async (id: number) => {
    setLoading(true);
    setError(null);
    try {
      const response = await dewormingApi.deleteDeworming(id);
      return response;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };

  return { deleteDeworming, loading, error };
};
