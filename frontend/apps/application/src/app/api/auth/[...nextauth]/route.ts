import type { NextApiRequest, NextApiResponse } from "next"
import NextAuth, { NextAuthOptions } from "next-auth"
import CredentialsProvider from "next-auth/providers/credentials"

// export default async function auth(req: NextApiRequest, res: NextApiResponse) {
//   // Do whatever you want here, before the request is passed down to `NextAuth`
//   return await NextAuth(req, res, {
//     providers: []
//   });
// }
const credentialProvider = CredentialsProvider({
    name: 'Credentials',
    credentials: {
        username: { label: "Username", type: "text", placeholder: "jsmith" },
        password: { label: "Password", type: "password" }
    },
    async authorize(credentials, req) {
        console.log(credentials);
        console.log('wtfffffffffffffff');
        return null;
    }
})

export const authOptions: NextAuthOptions = {
    debug: false,
    secret: process.env.NEXTAUTH_SECRET,
    providers: [credentialProvider],
    session: {
        strategy: "jwt",
    },
    pages: {
        signIn: '/auth/login'
    },
    callbacks: {
        
    }
};




const handler = NextAuth(authOptions);
export { handler as GET, handler as POST }