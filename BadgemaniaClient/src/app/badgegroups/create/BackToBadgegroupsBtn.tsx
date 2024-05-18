"use client";

import { useRouter } from "next/navigation";

// Button to go back to badgegroups page
export default function BackToBadgegroupsBtn() {
  const router = useRouter();

  // Go back to badgegroups page
  const handleGoToBadgegroupPage = () => {
    router.push("/badgegroups");
  };

  return (
    <button
      type="button"
      onClick={handleGoToBadgegroupPage}
      className="bg-red-600 h-12 rounded-2xl px-2 mb-3 font-russo hover:bg-neutral-800/30"
    >
      Back
    </button>
  );
}
