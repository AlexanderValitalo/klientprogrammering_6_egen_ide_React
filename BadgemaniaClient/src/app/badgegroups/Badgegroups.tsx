"use client";

import { useEffect, useState } from "react";
import { BadgeGroup } from "@/interfaces/badgegroup";
import BadgegroupBtn from "./BadgegroupBtn";
import CreateBadgegroupBtn from "./CreateBadgegroupBtn";
import { getBadgegroups } from "@/utils/api";
import { getRole } from "@/utils/auth";

// Badgegroups component that fetches and displays all badgegroups
export default function Badgegroups() {
  const [badgegroups, setBadgegroups] = useState([] as BadgeGroup[]);
  const [noBadgegroups, setNoBadgegroups] = useState(false);
  const [showCreateBadgegroup, setShowCreateBadgegroup] = useState(false);

  // Fetch badgegroups
  useEffect(() => {
    async function fetchBadgegroups() {
      try {
        const badgegroups = await getBadgegroups();
        if (badgegroups.length > 0) {
          setBadgegroups(badgegroups);
        } else {
          setNoBadgegroups(true);
        }
      } catch (error) {
        console.error(error);
      }
    }
    fetchBadgegroups();
  }, []);

  // Check if user is a teacher
  useEffect(() => {
    const role = getRole();
    if (role === "Teacher") {
      setShowCreateBadgegroup(true);
    }
  }, []);

  return (
    <>
      {showCreateBadgegroup && <CreateBadgegroupBtn />}
      <div className="flex flex-col px-2 font-martian text-black sm:flex-row sm:flex-wrap sm:gap-3 sm:w-1/2">
        {!noBadgegroups &&
          badgegroups.map((badgegroup) => (
            <BadgegroupBtn key={badgegroup.id} badgegroup={badgegroup} />
          ))}
        {noBadgegroups && <p className="text-white">No badgegroups</p>}
      </div>
    </>
  );
}
