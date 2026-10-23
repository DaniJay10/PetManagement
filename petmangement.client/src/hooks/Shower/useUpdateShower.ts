import { useState } from "react";
import type { CreateShower } from "../../interfaces/shower.interface";
import { showerApi } from "../../api/shower/shower.api";

export const useUpdateShower = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const updateShower = async (id: number, shower: CreateShower) => {
    setLoading(true);

    try {
      const response = await showerApi.updateShower(id, shower);
      return response;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };
  return { updateShower, loading, error };
};
