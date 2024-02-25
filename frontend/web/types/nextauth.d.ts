import 'next-auth'

declare module "next-auth" {
    interface Session extends DefaultSession {
      user?: User;
      jwtToken: string,
      refreshToken: string
    }

    interface User {
        id: string,
        login: string,
        avatarPath?: string,
      }
  }

  declare module 'next-auth/client' {
    export interface Session {
      uid: string
    }
  }