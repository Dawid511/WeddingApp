export interface Guest {
  id: number;
  guestListId: number;
  fullName: string;
  email?: string;
  phoneNumber?: string;
  count: number;
  notes?: string;
  status: string; // "Invited" itd.
  editing?: boolean; // do UI
}