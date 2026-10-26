import { useGetPets } from "../../hooks/Pet/useGetPets";

export const PetList = () => {
  const { pets, getPets, loading, error } = useGetPets();

  if (error) return <div>Error: {error}</div>;
  if (loading) return <div>Cargando...</div>;
  if (!loading && pets.length === 0)
    return (
      <div>
        <div>Crea tu mascota</div>
        <button type="button" className="btn btn-primary btn-lg">
          Crear
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
              Specie: {pet.petWeight}
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
