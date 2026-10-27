import { useState } from "react";
import type { CreateShower } from "../../interfaces/shower.interface";
import { showerApi } from "../../api/shower/shower.api";

export const useCreateShower = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const createShower = async (shower: CreateShower) => {
    setLoading(true);
    setError(null);

    try {
      const response = await showerApi.createShower(shower);
      return response;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };

  return { createShower, loading, error };
};
