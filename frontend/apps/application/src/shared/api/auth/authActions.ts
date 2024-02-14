import { LoginUserRequestDto, LoginUserResponseDto } from "./authDtos";
import apiClient from "../apiClient";

const basePath = `${process.env.API_BASE_URL}/auth`;

export const loginUser = async (user: LoginUserRequestDto) => {
  return (await apiClient.post<LoginUserResponseDto>(`${basePath}/login`, user))
    .data;
};
