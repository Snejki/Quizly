"use client";
import { useSession } from 'next-auth/react'

const useAuthSession = () => {
  const session = useSession();

  return { isAuthenticated: session.status == 'authenticated' };
}

export default useAuthSession