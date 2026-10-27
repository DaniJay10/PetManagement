import { useNavigate } from "react-router-dom";
import { useCreatePet } from "../../hooks/Pet/useCreatePet";
import { useUpdatePet } from "../../hooks/Pet/useUpdatePet";
import { useState, useEffect } from "react";
import { useGetPetById } from "../../hooks/Pet/useGetPetById";

interface Props {
  petId?: number;
}

export const PetForm = ({ petId }: Props) => {
  const isEditing = !!petId;
  const navigate = useNavigate();

  //? hook create
  const { createPet, loading: creating, error: createError } = useCreatePet();

  //? hook GetPetById
  const { pet, loading: getting, error: getError } = useGetPetById(petId || 0);
  //   //? hook update
  const { updatePet, loading: updating, error: updateError } = useUpdatePet();

  //Group of loadings and errors
  const loading = creating || updating;
  const error = createError || updateError || getError;

  // atributes of pet
  const [petName, setPetName] = useState("");
  const [specie, setSpecie] = useState("");
  const [breed, setBreed] = useState("");
  const [birthDate, setBirthDate] = useState("");
  const [petWeight, setPetWeight] = useState(0);
  const [petSize, setPetSize] = useState("");
  const [dewormingF, setDewormingF] = useState(0);

  //charge data if is update mode
  useEffect(() => {
    if (pet && isEditing) {
      setPetName(pet.petName);
      setSpecie(pet.specie);
      setBreed(pet.breed);
      setBirthDate(pet.birthDate.split("T")[0]);
      setPetWeight(pet.petWeight);
      setPetSize(pet.petSize);
      setDewormingF(pet.dewormingFrequency);
    }
  }, [pet, isEditing]);

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const pet = {
      petName: petName,
      specie: specie,
      breed: breed,
      birthDate: birthDate,
      petWeight: petWeight,
      petSize: petSize,
      dewormingFrequency: dewormingF,
    };

    let response;

    if (!isEditing) {
      response = await createPet(pet);
    } else {
      response = await updatePet({
        petId: petId!,
        ...pet,
      });
    }

    if (response) {
      navigate("/");
    }
  };

  //listas desplegables
  const sizes = ["S", "M", "L", "XL"];

  //?HTML
  return (
    <div className="form-container">
      <h2 className="form-title">
        {isEditing ? "Update Pet Information" : "Create Pet"}
      </h2>

      {error && <p className="error-message">{error}</p>}

      <form onSubmit={handleSubmit}>
        {/* Name */}
        <div className="form-group">
          <label className="form-label">Name</label>
          <div className="input-group">
            <input
              type="text"
              className="form-input"
              placeholder="Name"
              value={petName}
              onChange={(e) => setPetName(e.target.value)}
              required
            />
          </div>
        </div>

        {/*specie */}
        <div className="form-group">
          <label className="form-label">Specie</label>
          <input
            type="text"
            className="form-input"
            value={specie}
            onChange={(e) => setSpecie(e.target.value)}
            required
          />
        </div>

        {/*breed*/}
        <div className="form-group">
          <label className="form-label">breed</label>
          <input
            className="form-input"
            value={breed}
            onChange={(e) => setBreed(e.target.value)}
            required
          />
        </div>

        {/*birthDate */}
        <div className="form-group">
          <label className="form-label">BirthDate</label>
          <input
            type="date"
            className="form-input"
            value={birthDate}
            onChange={(e) => setBirthDate(e.target.value)}
            required
          />
        </div>

        {/*petWeight */}
        <div className="form-group">
          <label className="form-label">petWeight</label>
          <input
            type="number"
            min="0"
            step="any"
            value={petWeight}
            onChange={(e) => setPetWeight(Number(e.target.value))}
            required
          />
        </div>

        {/*petSize*/}
        <div className="form-group">
          <label className="form-label">Size</label>
          <select
            className="form-input"
            value={petSize}
            onChange={(e) => setPetSize(e.target.value)}
            required
          >
            <option value="">Seleccione size</option>
            {sizes.map((size) => (
              <option key={size} value={size}>
                {size}
              </option>
            ))}
          </select>
        </div>

        {/*dewormingF */}
        <div className="form-group">
          <label className="form-label">dewormingFrequency months</label>
          <input
            type="number"
            min="0"
            step="1"
            value={dewormingF}
            onChange={(e) => setDewormingF(Number(e.target.value))}
            required
          />
        </div>

        {/* Enviar */}
        <div className="button-group">
          <button
            type="submit"
            className="submit-btn"
            disabled={loading || getting}
          >
            {loading ? "Recording..." : isEditing ? "Update Pet" : "Record Pet"}
          </button>

          <button
            type="button"
            className="cancel-btn"
            onClick={() => navigate("/")}
          >
            Cancelar
          </button>
        </div>
      </form>
    </div>
  );
};
