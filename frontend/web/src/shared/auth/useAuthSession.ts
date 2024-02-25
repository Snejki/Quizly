import { getSession, useSession } from "next-auth/react";

export async function getAuthTokens() {
  const session = await getSession();

  return {
    jwt: session?.jwtToken,
    refreshToken: session?.refreshToken
  }
}


export const useAuthSession = () => {
  const { data, status } = useSession();
  console.log(data);

  return {
    isAuthenticated: status == "authenticated",
    user: {
      id: data?.user?.id,
      login: data?.user?.login,
      avatarPath: data?.user?.avatarPath,
    },
  };
};
