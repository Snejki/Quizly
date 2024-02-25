import { loginUserService } from "@/lib/auth/authService";
import NextAuth from "next-auth/next";
import CredentialsProvider from "next-auth/providers/credentials";

const credentialsProvider = CredentialsProvider({
  name: "Credentials",
  credentials: {
    login: { label: "Username", type: "text", placeholder: "jsmith" },
    password: { label: "Password", type: "password" },
  },
  async authorize(credentials, req) {
    console.log(credentials);
    if (credentials == null) {
      return null;
    }

    try {
      const response = await loginUserService(credentials);
      return response;
    } catch (e) {
      console.log(e);
    }

    return null;
  },
});
1;
const handler = NextAuth({
  providers: [credentialsProvider],
  pages: {
    signIn: "/auth/login",
  },
  callbacks: {
    async jwt({ user, token }) {
      user && (token.user = user);
      return Promise.resolve(token);
    },
    async session(params) {
      console.log(params);
      if(params.trigger == "update") {
        console.log("from refresh token");
      }
      console.log(params);
      return {
        user: params.token.user,
        jwtToken: params.token.accessToken,
        refreshToken: params.token.refreshToken,
        expires: params.session.expires
      };
    },
  },
});

export { handler as GET, handler as POST };
