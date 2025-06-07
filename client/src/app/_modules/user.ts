export type UserRole = 'User' | 'Vendor' | 'Admin';

export interface User {
  id: number;
  username: string;
  token: string;
  role: UserRole;
}