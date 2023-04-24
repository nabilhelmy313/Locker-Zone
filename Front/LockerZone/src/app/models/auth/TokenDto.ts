export interface TokenDto {
  token: string;
  expiration: string;
  currentUser: ApplicationUserDto;
  isActive: boolean;
}
export interface ApplicationUserDto {
  userName: string | null;
  fullName: string | null;
  roleName: string;
  profilePicture: string | null;
}
