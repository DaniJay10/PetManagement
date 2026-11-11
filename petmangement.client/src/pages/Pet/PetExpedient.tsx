import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { PetDeleteModal } from "../../components/Pet/PetDeleteModal";
import { useExpedient } from "../../hooks/Expedient/useExpedient";

export const PetExpedient = () => {
  const { petId } = useParams();
  const id = Number(petId);
  const [viewModal, setViewModal] = useState(false);
  const navigate = useNavigate();

  const { expedient, getExpedient, loading, error } = useExpedient();

  useEffect(() => {
    if (Number.isInteger(id) && id > 0) {
      getExpedient(id);
    }
  }, [id]);

  return (
    <div className="container mt-4">
      {viewModal && Number.isInteger(id) && id > 0 && (
        <PetDeleteModal
          onClose={() => setViewModal(false)}
          petId={id}
          onDeleted={() => navigate("/")}
        />
      )}

      {loading ? (
        <p>Loading expedient...</p>
      ) : error ? (
        <div className="alert alert-danger" role="alert">
          {error}
        </div>
      ) : expedient ? (
        <>
          <div className="card shadow-sm mb-4">
            <div className="card-body">
              <div className="d-flex justify-content-between align-items-start mb-3">
                <div>
                  <h2 className="fw-bold mb-1">{expedient.pet.petName}</h2>
                  <p className="text-muted mb-0">
                    {expedient.pet.specie} - {expedient.pet.breed}
                  </p>
                </div>
              </div>

              <hr />

              <div className="row g-3">
                <div className="col-md-6">
                  <strong>Birth date:</strong>
                  <p>{expedient.pet.birthDate}</p>
                </div>

                <div className="col-md-6">
                  <strong>Weight:</strong>
                  <p>{expedient.pet.petWeight} kg</p>
                </div>

                <div className="col-md-6">
                  <strong>Size:</strong>
                  <p>{expedient.pet.petSize}</p>
                </div>

                <div className="col-md-6">
                  <strong>Deworming frequency:</strong>
                  <p>{expedient.pet.dewormingFrequency} months</p>
                </div>
              </div>
            </div>
          </div>

          {/* Update */}
          <button
            className="btn btn-sm btn-primary me-2"
            onClick={() =>
              navigate(`/petform/${id}`, {
                state: { from: `/pet/${id}` },
              })
            }
          >
            <i className="bi bi-pencil-fill"></i>
            Update
          </button>

          {/* delete */}
          <button
            className="btn btn-sm btn-danger"
            onClick={() => setViewModal(true)}
          >
            <i className="bi bi-trash3-fill"></i>
            Delete
          </button>
        </>
      ) : (
        <p>No expedient information available.</p>
      )}
    </div>
  );
};
