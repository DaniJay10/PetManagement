import { useGetPets } from "../../hooks/Pet/useGetPets";
import { useNavigate } from "react-router-dom";

export const PetList = () => {
  const { pets, getPets, loading, error } = useGetPets();
  const navigate = useNavigate();

  if (error) return <div>Error: {error}</div>;
  if (loading) return <div>Cargando...</div>;
  if (!loading && pets.length === 0)
    return (
      <div>
        <div>No tienes ninguna mascota registrada</div>
        <button
          type="button"
          className="btn btn-primary btn-lg"
          onClick={() => navigate("/petform")}
        >
          Crear Mascota
        </button>
      </div>
    );

  return (
    <div>
      {pets.map((pet) => (
        <div key={pet.petId} className="card" style={{ width: "18rem" }}>
          <img className="card-img-top" src="..." alt="Mascota" />

          <div className="card-body">
            <h5 className="card-title">{pet.petName}</h5>

            <p className="card-text">
              BirhDate: {pet.birthDate}
              <br />
              Specie: {pet.specie}
            </p>

            <button type="button" className="btn btn-primary">
              Ver expediente
            </button>
          </div>
        </div>
      ))}
    </div>
  );
};
