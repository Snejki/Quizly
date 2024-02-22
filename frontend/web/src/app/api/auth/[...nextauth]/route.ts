import { loginUserService } from "@/lib/auth/authService";
import NextAuth from "next-auth";
import CredentialsProvider from "next-auth/providers/credentials";

const credentialsProvider = CredentialsProvider({
  name: "Credentials",
  credentials: {
    login: { label: "Username", type: "text", placeholder: "jsmith" },
    password: { label: "Password", type: "password" },
  },
  async authorize(credentials, req) {
    if(credentials == null) {
      return null;
    }

    const response = await loginUserService(credentials);

    return { name: "ALBINOS", email: "ALEJAJCA@mail.com", id: "1231231"};
  },
});
1
const handler = NextAuth({
  providers: [credentialsProvider],
  pages: {
    signIn: "/auth/login",
  },
  callbacks: {
    async session(params) {
        console.log(params);

        return params.session;
    },

  },
});

export { handler as GET, handler as POST };
