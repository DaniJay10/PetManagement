import type { Consultation } from "./consultation.interface";
import type { Deworming } from "./deworming.interface";
import type { Novelty } from "./novelty.interface";
import type { Pet } from "./pet.interface";
import type { Shower } from "./shower.interface";
import type { Vaccine } from "./vaccine.interface";

export interface Expedient {
  pet: Pet;
  consultations: Consultation[];
  dewormings: Deworming[];
  novelties: Novelty[];
  showers: Shower[];
  vaccines: Vaccine[];
}
