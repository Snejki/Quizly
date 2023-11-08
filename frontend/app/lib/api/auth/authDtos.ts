export interface LoginUserRequestDto {
  login: string;
  password: string;
}

export interface LoginUserResponseDto {
  login: string;
  avatar: string;
  token: string;
}
