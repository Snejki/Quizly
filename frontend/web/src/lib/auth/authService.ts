import { backendClient } from "../api/backendClient"


export interface LoginUserRequest {
    login: string,
    password: string
}

export interface LoginUserResponse {
    id: string,
    accessToken: string,
    refreshToken: string,
    login: string,
    avatarPath?: string
}

export const loginUserService = async (req: LoginUserRequest) : Promise<LoginUserResponse> => {
    return (await backendClient.post("api/auth/login", req)).data;
}