import { useState, useEffect } from "react";
import { petApi } from "../../api/pet/pet.api";
import type { Pet } from "../../interfaces/pet.interface";

export const useGetPetById = (id: number) => {
  const [pet, setPet] = useState<Pet | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (!id) return;

    const chargePet = async () => {
      setLoading(true);
      try {
        const data = await petApi.getPetById(id);
        setPet(data);
      } catch (err) {
        setError(err instanceof Error ? err.message : "An error has occurred");
      } finally {
        setLoading(false);
      }
    };

    chargePet();
  }, [id]);

  return { pet, loading, error };
};
