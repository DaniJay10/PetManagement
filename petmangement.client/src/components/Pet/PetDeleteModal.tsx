import { useDeletePet } from "../../hooks/Pet/useDeletePet";

interface Props {
  onClose: () => void;
  petId: number;
  onDeleted: () => void;
}

export const PetDeleteModal = ({ onClose, petId, onDeleted }: Props) => {
  const { deletePet, loading, error } = useDeletePet();

  const handleDelete = async () => {
    const response = await deletePet(petId);

    if (response) {
      onDeleted();
      onClose();
    }
  };

  return (
    <div>
      <div className="modal show" style={{ display: "block" }}>
        <div className="modal-dialog">
          <div className="modal-content">
            <div className="modal-header">
              <h5 className="modal-title">Wait a minute!</h5>
            </div>

            <div className="modal-body">
              <p>Are you sure you want to delete this pet?</p>

              {error && <p className="text-danger">Error: {error}</p>}
            </div>

            <div className="modal-footer">
              <button
                type="button"
                className="btn btn-danger"
                onClick={handleDelete}
                disabled={loading}
              >
                {loading ? "Deleting..." : "Delete"}
              </button>

              <button
                type="button"
                className="btn btn-secondary"
                onClick={onClose}
                disabled={loading}
              >
                Return
              </button>
            </div>
          </div>
        </div>
      </div>

      <div className="modal-backdrop show"></div>
    </div>
  );
};
