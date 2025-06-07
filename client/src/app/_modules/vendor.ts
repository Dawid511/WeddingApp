 export interface Vendor {
  id: number;
  appUserId: number,
  category: string;
  companyName: string;
  description?: string;
  websiteUrl?: string;
  phone?: string;
  email?: string;
}