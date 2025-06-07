import { Guest } from './guest';

export interface GuestList {
  id: number;
  weddingId: number;
  guests: Guest[];
}