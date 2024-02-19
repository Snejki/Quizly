"use client";

import { Inter } from "next/font/google";
import "./globals.css";
import { AppRouterCacheProvider } from "@mui/material-nextjs/v13-appRouter";
import { SessionProvider } from "next-auth/react";
import NavBar from "@/shared/ui/navbar/NavBar";
const inter = Inter({ subsets: ["latin"] });

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body className={inter.className}>
        <SessionProvider>
          <NavBar />
          <AppRouterCacheProvider>{children}</AppRouterCacheProvider>
        </SessionProvider>
      </body>
    </html>
  );
}
