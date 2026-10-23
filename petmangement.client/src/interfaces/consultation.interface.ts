export interface consultation {
  consultationId: number;
  petId: number;
  consultationDate: string;
  reason: string;
  diagnosis: string;
  notes: string;
}

export interface Createconsultation {
  petId: number;
  consultationDate: string;
  reason: string;
  diagnosis: string;
  notes: string;
}

export interface Updateconsultation {
  consultationId: number;
  petId: number;
  consultationDate: string;
  reason: string;
  diagnosis: string;
  notes: string;
}
