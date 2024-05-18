"use client";

import { useRouter } from "next/navigation";
import { BadgeGroup } from "@/interfaces/badgegroup";

interface BadgegroupCardProps {
  badgegroup: BadgeGroup;
}

// Button for different badgegroups
export default function BadgegroupBtn({ badgegroup }: BadgegroupCardProps) {
  const router = useRouter();

  return (
    <>
      <button
        type="button"
        onClick={() => router.push(`/badgegroups/${badgegroup.id}`)}
        className="my-3 p-3 bg-slate-200 rounded-2xl font-russo hover:bg-neutral-800/30"
      >
        {badgegroup.name}
      </button>
    </>
  );
}
