import { useGetPets } from "../../hooks/Pet/useGetPets";
import { useNavigate } from "react-router-dom";
import "../../css/PetList.css";
import { CreatePetButton } from "../../components/Pet/CreatePetButton";

export const PetList = () => {
  const { pets, loading, error } = useGetPets();
  const navigate = useNavigate();

  if (error) return <div>Error: {error}</div>;
  if (loading) return <div>Loading...</div>;

  if (pets.length === 0) {
    return (
      <div className="pet-empty">
        <div className="pet-empty-message">
          You don't have any pets registered.
        </div>
        <CreatePetButton />
      </div>
    );
  }

  return (
    <div className="pet-list">
      <div className="mb-3">
        <CreatePetButton />
      </div>

      {pets.map((pet) => (
        <div key={pet.petId} className="card pet-card">
          <img className="card-img-top" src="..." alt="Pet" />

          <div className="card-body">
            <h5 className="card-title">{pet.petName}</h5>

            <p className="card-text">
              BirthDate: {pet.birthDate}
              <br />
              Specie: {pet.specie}
            </p>

            <button
              type="button"
              className="btn btn-primary"
              onClick={() => navigate(`/pet/${pet.petId}`)}
            >
              Show expedient
            </button>
          </div>
        </div>
      ))}
    </div>
  );
};
