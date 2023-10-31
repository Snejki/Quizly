import apiClient from '../apiClient';

interface LoginRequestDto {
  userName: string;
  password: string;
}

interface LoginRequestResponseDto {
  id: string;
  name: string;
}

export default class UserRepository {
  static async login(model: LoginRequestDto) {
    return (await apiClient.post<LoginRequestResponseDto>('', model)).data;
  }
}
