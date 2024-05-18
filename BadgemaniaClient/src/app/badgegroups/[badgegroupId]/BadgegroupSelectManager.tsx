"use client";

import { useRouter, usePathname } from "next/navigation";

// Badgegroup select manager for badgegroup pages
export default function BadgegroupSelectManager({ badgegroupId }: { badgegroupId: string }) {
  const router = useRouter();
  const pathname = usePathname();

  return (
    <div>
      <div className="flex flex-row flex-wrap px-2 font-martian text-black sm:flex-row sm:flex-wrap sm:gap-5">
        <button
          type="button"
          onClick={() => router.push("/badgegroups/" + badgegroupId)}
          className={`my-1 p-3 ${
            pathname === `/badgegroups/${badgegroupId}` ? "bg-green-600" : "bg-slate-200"
          } rounded-2xl font-russo hover:bg-neutral-800/30 text-xs size-auto  sm:text-base`}
        >
          Badgegroup Details
        </button>
        <button
          type="button"
          onClick={() => router.push("/badgegroups/" + badgegroupId + "/students")}
          className={`my-1 p-3 ${
            pathname === `/badgegroups/${badgegroupId}/students` ? "bg-green-600" : "bg-slate-200"
          } rounded-2xl font-russo hover:bg-neutral-800/30 text-xs size-auto  sm:text-base`}
        >
          Handle Students
        </button>
        <button
          type="button"
          onClick={() => router.push("/badgegroups/" + badgegroupId + "/badgetypes")}
          className={`my-1 p-3 ${
            pathname === `/badgegroups/${badgegroupId}/badgetypes` ? "bg-green-600" : "bg-slate-200"
          } rounded-2xl font-russo hover:bg-neutral-800/30 text-xs size-auto  sm:text-base`}
        >
          Handle Badgetypes
        </button>
        <button
          type="button"
          onClick={() => router.push("/badgegroups/" + badgegroupId + "/badges")}
          className={`my-1 p-3 ${
            pathname === `/badgegroups/${badgegroupId}/badges` ? "bg-green-600" : "bg-slate-200"
          } rounded-2xl font-russo hover:bg-neutral-800/30 text-xs size-auto  sm:text-base`}
        >
          Handle Badges
        </button>
      </div>
      <hr />
    </div>
  );
}
