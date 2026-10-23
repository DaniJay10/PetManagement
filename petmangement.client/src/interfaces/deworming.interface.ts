export interface Deworming {
  dewormingId: number;
  petId: number;
  applicationDate: string;
}

export interface CreateDeworming {
  petId: number;
  applicationDate: string;
}

export interface UpdateDeworming {
  dewormingId: number;
  petId: number;
  applicationDate: string;
}
