"use client";

import { useState } from "react";
import { useRouter } from "next/navigation";
import { handleFormChange } from "@/utils/forms";
import { createBadgegroup } from "@/utils/api";

const errorTime = 5000;

// Form to create a badgegroup
export default function CreateBadgegroupForm() {
  const [formData, setFormData] = useState({ name: "" });
  const [errorMessage, setErrorMessage] = useState("");

  const router = useRouter();

  // Create badgegroup and redirect to badgegroups page
  const handleCreateBadgegroup = async (event: React.SyntheticEvent) => {
    event.preventDefault();

    try {
      await createBadgegroup(formData.name);

      router.push("/badgegroups");
    } catch (error: any) {
      setErrorMessage(error.message);
      setTimeout(() => {
        setErrorMessage("");
      }, errorTime);
    }
  };

  return (
    <>
      <form
        className="flex flex-col mb-3 items-center justify-between sm:flex-row"
        onSubmit={handleCreateBadgegroup}
      >
        <label htmlFor="name" className="font-russo">
          Badgegroup name:
        </label>
        <input
          type="text"
          name="name"
          id="name"
          value={formData.name}
          onChange={handleFormChange(formData, setFormData)}
          required
          className="border-neutral-700 rounded-lg p-2 m-1 text-black"
        />
        <button
          className="bg-green-600 rounded-lg p-2 m-1 font-russo hover:bg-neutral-800/30"
          type="submit"
        >
          Create Badgegroup
        </button>
      </form>
      <p>{errorMessage}</p>
    </>
  );
}
