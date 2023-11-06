import axios from "axios";
import { LoginUserRequestDto, LoginUserResponseDto } from "./authDtos";

const basePath = `${process.env.API_BASE_URL}/auth/`;

export const loginUser = async (user: LoginUserRequestDto) => {
  return (await axios.post<LoginUserResponseDto>(`${basePath}/login`, user))
    .data;
};
