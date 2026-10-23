export interface Pet {
  petId: number;
  petName: string;
  specie: string;
  breed: string;
  birthDate: string;
  petWeight: number;
  petSize: string;
  dewormingFrecuency: number;
}

export interface CreatePet {
  petName: string;
  specie: string;
  breed: string;
  birthDate: string;
  petWeight: number;
  petSize: string;
  dewormingFrecuency: number;
}

export interface UpdatePet {
  petId: number;
  petName: string;
  specie: string;
  breed: string;
  birthDate: string;
  petWeight: number;
  petSize: string;
  dewormingFrecuency: number;
}
