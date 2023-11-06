import apiClient from "../apiClient";
import { CreateuserRequestDto } from "./userDtos";

const basePath = `${process.env.API_BASE_URL}`;

export const createUser = async (user: CreateuserRequestDto) => {
  return (await apiClient.post<void>(basePath, user)).data;
};
