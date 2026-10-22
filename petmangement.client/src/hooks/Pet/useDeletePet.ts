import { useState } from "react";
import { petApi } from "../../api/pet/pet.api";

export const useDeletePet = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const deletePet = async (petId: number) => {
    setLoading(true);
    setError(null);

    try {
      const response = await petApi.deletePet(petId);
      return response;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
    } finally {
      setLoading(false);
    }
  };

  return { deletePet, loading, error };
};
