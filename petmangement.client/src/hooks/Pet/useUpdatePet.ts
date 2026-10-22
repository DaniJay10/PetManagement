import { useState } from "react";
import { petApi } from "../../api/pet/pet.api";
import type { CreatePet } from "../../interfaces/pet.interface";

export const useUpdatePet = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const updatePet = async (petId: number, data: CreatePet) => {
    setLoading(true);
    setError(null);

    try {
      const response = await petApi.updatePet(petId, data);
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
