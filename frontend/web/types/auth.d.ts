import "next-auth";

declare module "next-auth" {
  interface User {
    id: string,
    login: string,
    avatarPath?: string,
    accessToken: string,
    refreshToken: string,
  }
}