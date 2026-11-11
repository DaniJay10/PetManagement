import type { Expedient } from "../../interfaces/expedient.interface";

interface RecentActivityProps {
  expedient: Expedient;
}

interface Activity {
  id: number;
  title: string;
  description: string;
  date: string;
  type: string;
  icon: string;
}

export const RecentActivity = ({ expedient }: RecentActivityProps) => {
  const activities: Activity[] = [
    ...expedient.consultations.map((item) => ({
      id: item.consultationId,
      title: "Veterinary consultation",
      description: item.reason,
      date: item.consultationDate,
      type: "Consultation",
      icon: "bi bi-hospital",
    })),

    ...expedient.vaccines.map((item) => ({
      id: item.vaccineId,
      title: "Vaccine application",
      description: item.vaccineType,
      date: item.applicationData,
      type: "Vaccine",
      icon: "bi bi-eyedropper",
    })),

    ...expedient.dewormings.map((item) => ({
      id: item.dewormingId,
      title: "Deworming application",
      description: "Deworming registered",
      date: item.applicationDate,
      type: "Deworming",
      icon: "bi bi-capsule",
    })),

    ...expedient.showers.map((item) => ({
      id: item.showerId,
      title: "Shower application",
      description: "Shower registered",
      date: item.applicationDate,
      type: "Shower",
      icon: "bi bi-droplet",
    })),

    ...expedient.novelties.map((item) => ({
      id: item.noveltyId,
      title: "Novelty registered",
      description: item.description,
      date: item.noveltyDate,
      type: "Novelty",
      icon: "bi bi-clipboard2-pulse",
    })),
  ];

  const recentActivities = activities
    .sort((a, b) => new Date(b.date).getTime() - new Date(a.date).getTime())
    .slice(0, 5);

  return (
    <section className="mt-4 mb-4">
      <div className="mb-3">
        <h4 className="fw-bold mb-1">Recent Activity</h4>
        <p className="text-muted mb-0">
          Latest records registered for this pet
        </p>
      </div>

      <div className="card border-0 shadow-sm">
        <div className="card-body">
          {recentActivities.length === 0 ? (
            <p className="text-muted text-center mb-0 py-3">
              No activity registered yet.
            </p>
          ) : (
            <div className="d-flex flex-column gap-3">
              {recentActivities.map((activity, index) => (
                <div
                  key={`${activity.type}-${activity.id}`}
                  className="d-flex align-items-start gap-3"
                >
                  <div className="fs-4 text-primary">
                    <i className={activity.icon}></i>
                  </div>

                  <div className="flex-grow-1">
                    <div className="d-flex justify-content-between flex-wrap gap-1">
                      <strong>{activity.title}</strong>
                      <small className="text-muted">
                        {new Date(activity.date).toLocaleDateString()}
                      </small>
                    </div>

                    <p className="text-muted mb-0">{activity.description}</p>
                  </div>
                </div>
              ))}
            </div>
          )}
        </div>
      </div>
    </section>
  );
};
