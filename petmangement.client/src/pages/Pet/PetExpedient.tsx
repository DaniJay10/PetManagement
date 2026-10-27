import { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { PetDeleteModal } from "../../components/Pet/PetDeleteModal";

export const PetExpedient = () => {
  const { petId } = useParams();
  const id = Number(petId);
  const [viewModal, setViewModal] = useState(false);
  const navigate = useNavigate();

  return (
    <div className="container mt-4">
      {viewModal && Number.isInteger(id) && id > 0 && (
        <PetDeleteModal
          onClose={() => setViewModal(false)}
          petId={id}
          onDeleted={() => navigate("/")}
        />
      )}
      <div>Expedient of pet</div>
      <button
        className="btn btn-sm btn-primary me-2"
        onClick={() => navigate(`/petform/${id}`)}
      >
        <i className="bi bi-pencil-fill"></i>
        Update
      </button>
      <button
        className="btn btn-sm btn-danger"
        onClick={() => {
          setViewModal(true);
        }}
      >
        <i className="bi bi-trash3-fill"></i>Delete
      </button>
    </div>
  );
};
