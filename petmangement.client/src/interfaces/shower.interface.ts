export interface Shower {
  showerId: number;
  petId: number;
  applicationDate: string;
}

export interface CreateShower {
  petId: number;
  applicationDate: string;
}
