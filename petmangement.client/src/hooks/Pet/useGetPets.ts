import { useState, useEffect } from "react";
import { petApi } from "../../api/pet/pet.api";
import type { Pet } from "../../interfaces/pet.interface";

export const useGetPets = () => {
  const [pets, setPets] = useState<Pet[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const getPets = async () => {
    setLoading(true);
    setError(null);
    try {
      const data = await petApi.getPets();
      setPets(data);
      return data;
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error has occurred");
      return null;
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    getPets();
  }, []);

  return {
    pets,
    // getPets,
    loading,
    error,
  };
};
