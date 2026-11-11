import { useNavigate } from "react-router-dom";

export const CreatePetButton = () => {
  const navigate = useNavigate();

  return (
    <button
      type="button"
      className="btn btn-primary"
      onClick={() => navigate("/petform")}
    >
      Create Pet
    </button>
  );
};
