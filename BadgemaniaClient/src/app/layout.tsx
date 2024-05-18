import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.css";
import Refresher from "@/components/refresher/Refresher";
import Navigation from "@/components/navigation/Navigation";

const inter = Inter({ subsets: ["latin"] });

export const metadata: Metadata = {
  title: "Create Next App",
  description: "Generated by create next app",
};

export default function RootLayout({ children }: Readonly<{ children: React.ReactNode }>) {
  return (
    <html lang="en">
      <body className={inter.className}>
        <Refresher />
        <Navigation />
        <main className="flex flex-col items-center justify-between">{children}</main>
      </body>
    </html>
  );
}
