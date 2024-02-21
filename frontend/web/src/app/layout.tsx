"use client";

import { Inter } from "next/font/google";
import "./globals.css";
import { AppRouterCacheProvider } from "@mui/material-nextjs/v13-appRouter";
import { SessionProvider } from "next-auth/react";
import NavBar from "@/shared/ui/navbar/NavBar";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import SnackbarNotificationProvider from "@/shared/notifications/SnackBarNotifications";
const inter = Inter({ subsets: ["latin"] });

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  const client = new QueryClient();

  return (
    <html lang="en">
      <body className={inter.className}>
        <SnackbarNotificationProvider>
          <QueryClientProvider client={client}>
            <SessionProvider>
              <NavBar />
              <AppRouterCacheProvider>{children}</AppRouterCacheProvider>
            </SessionProvider>
          </QueryClientProvider>
        </SnackbarNotificationProvider>
      </body>
    </html>
  );
}
