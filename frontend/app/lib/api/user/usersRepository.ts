import apiClient from "../apiClient";
import { CreateuserRequestDto } from "./userDtos";

const basePath = "api/users/auth";

export const createUser = async (user: CreateuserRequestDto) => {
  return (await apiClient.post<void>(basePath, user)).data;
};
