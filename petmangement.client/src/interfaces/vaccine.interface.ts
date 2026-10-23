export interface Vaccine {
  vaccineId: number;
  petId: number;
  vaccineType: string;
  applicationData: string;
}

export interface CreateVaccine {
  petId: number;
  vaccineType: string;
  applicationData: string;
}
