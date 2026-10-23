import { useState } from "react";
import { petApi } from "../../api/pet/pet.api";
import type { UpdatePet } from "../../interfaces/pet.interface";

export const useUpdatePet = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const updatePet = async (data: UpdatePet) => {
    setLoading(true);
    setError(null);

    try {
      const response = await petApi.updatePet(data);
      return response;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };
  return { updatePet, loading, error };
};
