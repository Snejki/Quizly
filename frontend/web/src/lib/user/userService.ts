import { backendClient } from "../api/backendClient";

interface RegisterUserRequest {
  email: string;
  login: string;
  password: string;
  confirmPassword: string;
}

interface RegisterUserResponse {}

export const registerUserService = async (req: RegisterUserRequest) => {
  return await backendClient.post<RegisterUserResponse>("api/user/register", req);
};

