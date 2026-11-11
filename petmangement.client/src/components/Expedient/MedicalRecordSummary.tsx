import type { Expedient } from "../../interfaces/expedient.interface";

interface MedicalRecordsSummaryProps {
  expedient: Expedient;
}

export const MedicalRecordsSummary = ({
  expedient,
}: MedicalRecordsSummaryProps) => {
  const records = [
    {
      title: "Consultations",
      count: expedient.consultations.length,
      icon: "bi bi-hospital",
    },
    {
      title: "Vaccines",
      count: expedient.vaccines.length,
      icon: "bi bi-eyedropper",
    },
    {
      title: "Dewormings",
      count: expedient.dewormings.length,
      icon: "bi bi-capsule",
    },
    {
      title: "Showers",
      count: expedient.showers.length,
      icon: "bi bi-droplet",
    },
    {
      title: "Novelties",
      count: expedient.novelties.length,
      icon: "bi bi-clipboard2-pulse",
    },
  ];

  return (
    <section className="mt-4">
      <div className="mb-3">
        <h4 className="fw-bold mb-1">Medical Records</h4>
        <p className="text-muted mb-0">
          Overview of your pet's medical records
        </p>
      </div>

      <div className="row g-3">
        {records.map((record) => (
          <div className="col-12 col-sm-6 col-lg-4" key={record.title}>
            <div className="card h-100 border-0 shadow-sm">
              <div className="card-body d-flex align-items-center justify-content-between">
                <div>
                  <p className="text-muted mb-2">{record.title}</p>
                  <h3 className="fw-bold mb-0">{record.count}</h3>
                  <small className="text-muted">Registered records</small>
                </div>

                <div className="fs-2 text-primary">
                  <i className={record.icon}></i>
                </div>
              </div>
            </div>
          </div>
        ))}
      </div>
    </section>
  );
};
