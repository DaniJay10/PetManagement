export interface Novelty {
  noveltyId: number;
  petId: number;
  noveltyDate: string;
  description: string;
}

export interface CreateNovelty {
  petId: number;
  noveltyDate: string;
  description: string;
}

export interface UpdateNovelty {
  noveltyId: number;
  petId: number;
  noveltyDate: string;
  description: string;
}
