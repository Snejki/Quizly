export interface LoginUserRequestDto {
  login: string;
  password: string;
}

export interface LoginUserResponseDto {
  id: string;
  avatar: string;
  token: string;
}
