"use client";

import BadgegroupSelectManager from "./BadgegroupSelectManager";
import { usePathname } from "next/navigation";
import { useState, useEffect } from "react";
import { getRole } from "@/utils/auth";
import { getBadgegroupId } from "@/utils/from-url";

// Container for badgegroups
export default function BadgegroupContainer() {
  const [teacherRole, setTeacherRole] = useState(false);

  const pathname = usePathname();
  const badgegroupId = getBadgegroupId(pathname);

  // Check if user is a teacher
  useEffect(() => {
    const role = getRole();
    if (role === "Teacher") {
      setTeacherRole(true);
    }
  }, []);

  return <>{teacherRole && <BadgegroupSelectManager badgegroupId={badgegroupId} />}</>;
}
