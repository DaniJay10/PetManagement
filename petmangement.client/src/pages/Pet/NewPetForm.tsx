import { useParams } from "react-router-dom";
import { PetForm } from "../../components/Pet/PetForm";

export const NewPetForm = () => {
  const { petId } = useParams();

  return (
    <div>
      <PetForm petId={petId ? Number(petId) : undefined} />
    </div>
  );
};
