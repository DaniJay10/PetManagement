import { useState } from "react";
import type { UpdateDeworming } from "../../interfaces/deworming.interface";
import { dewormingApi } from "../../api/deworming/deworming.api";

export const useUpdateDeworming = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const updateDeworming = async (deworming: UpdateDeworming) => {
    setLoading(true);
    setError(null);
    try {
      const response = await dewormingApi.updateDeworming(deworming);
      return response;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };
  return { updateDeworming, loading, error };
};
