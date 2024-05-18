"use client";

import { useEffect, useState } from "react";
import { BadgeGroup } from "@/interfaces/badgegroup";
import Header from "@/components/header/Header";
import { getBadgegroup } from "@/utils/api";
import { usePathname } from "next/navigation";
import { getBadgegroupId, getLastPartOfBadgegroupPathname } from "@/utils/from-url";

// Header for badgegroup page
export default function BadgegroupHeader() {
  const [badgegroupInfo, setBadgegroupInfo] = useState({} as BadgeGroup);

  const pathname = usePathname();
  const badgegroupId = getBadgegroupId(pathname);
  const lastPartOfPathname = getLastPartOfBadgegroupPathname(pathname);

  // Fetch badgegroup info
  useEffect(() => {
    async function fetchBadgegroup() {
      try {
        const badgegroup = await getBadgegroup(badgegroupId);
        setBadgegroupInfo(badgegroup);
      } catch (error) {
        console.error(error);
      }
    }
    fetchBadgegroup();
  }, [badgegroupId]);

  return <Header headerInfo={`${lastPartOfPathname} in ${badgegroupInfo.name}`} />;
}
