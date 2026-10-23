import { useState } from "react";
import { showerApi } from "../../api/shower/shower.api";

export const useDeleteShower = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const deleteShower = async (id: number) => {
    setLoading(true);

    try {
      const response = await showerApi.deleteShower(id);
      return response;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };

  return { deleteShower, loading, error };
};
