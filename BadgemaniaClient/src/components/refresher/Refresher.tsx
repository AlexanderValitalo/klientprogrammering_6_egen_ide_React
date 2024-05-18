"use client";

import { useEffect, useRef } from "react";
import { useRouter, usePathname } from "next/navigation";
import { refreshTokens } from "@/utils/api";
import { setAuthorization, checkTimeLeft, logout } from "@/utils/auth";

// Refreshes the access token
export default function Refresher() {
  const router = useRouter();
  const pathname = usePathname();
  const isFirstRun = useRef(true);

  // Fetch refresh tokens
  useEffect(() => {
    async function fetchRefreshTokens() {
      try {
        const response = await refreshTokens();

        if (!response.ok) {
          logout();

          router.push("/login");
        } else {
          const data = await response.json();
          setAuthorization(data);
        }
      } catch (error) {
        console.error(error);
      }

      if (isFirstRun.current) {
        isFirstRun.current = false;
        router.push(pathname);
      }
    }

    const shouldRefresh = checkTimeLeft();
    if (shouldRefresh) {
      fetchRefreshTokens();
    }
  }, [pathname, router]);

  return <></>;
}
