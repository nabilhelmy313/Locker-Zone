export interface GetLockerDto {
  id:string;
  number: number;
  price: number;
  fromDay: string;
  toDay: string;
  description: string | null;
}
