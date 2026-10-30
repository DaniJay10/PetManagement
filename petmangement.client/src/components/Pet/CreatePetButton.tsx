import { useNavigate } from "react-router-dom";

export const CreatePetButton = () => {
  const navigate = useNavigate();
  return (
    <div className="pet-empty">
      <div className="pet-empty-message">You don't have pets registers</div>

      <button
        type="button"
        className="pet-create-button"
        onClick={() => navigate("/petform")}
      >
        Create Pet
      </button>
    </div>
  );
};
