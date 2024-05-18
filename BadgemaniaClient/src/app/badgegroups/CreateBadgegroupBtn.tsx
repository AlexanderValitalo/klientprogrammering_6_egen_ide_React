"use client";

import { useRouter } from "next/navigation";

// Button component to redirect to create badgegroup page
export default function CreateBadgegroupBtn() {
  const router = useRouter();

  // Go to create badgegroup page
  const handleGoToCreateBadgegroupPage = () => {
    router.push("/badgegroups/create");
  };

  return (
    <button
      type="button"
      onClick={handleGoToCreateBadgegroupPage}
      className="bg-green-600 h-12 rounded-2xl px-2 mb-3 font-russo hover:bg-neutral-800/30"
    >
      Create Badgegroup
    </button>
  );
}
