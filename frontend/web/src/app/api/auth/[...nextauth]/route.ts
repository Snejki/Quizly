import NextAuth from "next-auth";
import CredentialsProvider from "next-auth/providers/credentials";

const credentialsProvider = CredentialsProvider({
  name: "Credentials",
  credentials: {
    username: { label: "Username", type: "text", placeholder: "jsmith" },
    password: { label: "Password", type: "password" },
  },
  async authorize(credentials, req) {
    return {
      ...credentials
    };
  },
});

const handler = NextAuth({
  providers: [credentialsProvider],
  pages: {
    signIn: "/auth/login"
  }
});

export { handler as GET, handler as POST };
