import { useState } from "react";
import type { CreateDeworming } from "../../interfaces/deworming.interface";
import { dewormingApi } from "../../api/deworming/deworming.api";

export const useCreateDeworming = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const createDeworming = async (deworming: CreateDeworming) => {
    setLoading(true);
    try {
      const response = await dewormingApi.createDeworming(deworming);
      return response;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };

  return { createDeworming, loading, error };
};
