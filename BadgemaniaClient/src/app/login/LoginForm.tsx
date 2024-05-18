"use client";

import { useState } from "react";
import { handleFormChange } from "@/utils/forms";
import { login } from "@/utils/api";
import { setAuthorization } from "@/utils/auth";

const errorTime = 5000;

// Login form component
export default function LoginForm() {
  const [formData, setFormData] = useState({ email: "", password: "" });
  const [errorMessage, setErrorMessage] = useState("");

  // Handle login
  const handleLogin = async (event: React.SyntheticEvent) => {
    event.preventDefault();

    try {
      const response = await login(formData.email, formData.password);
      setAuthorization(response);
      location.href = "/";
    } catch (error: any) {
      setErrorMessage(error.message);
      setTimeout(() => {
        setErrorMessage("");
      }, errorTime);
    }
  };

  return (
    <>
      <form className="flex flex-col items-center justify-between" onSubmit={handleLogin}>
        <label htmlFor="email" className="font-russo">
          Email:
        </label>
        <input
          type="email"
          name="email"
          id="email"
          onChange={handleFormChange(formData, setFormData)}
          required
          className="border border-neutral-700 rounded-lg p-2 m-1 text-black"
        />
        <label htmlFor="password" className="font-russo">
          Password:
        </label>
        <input
          type="password"
          name="password"
          id="password"
          onChange={handleFormChange(formData, setFormData)}
          required
          className="border border-neutral-700 rounded-lg p-2 m-1 text-black"
        />
        <button
          className="border border-neutral-700 rounded-lg p-2 m-1 hover:bg-neutral-800/30"
          type="submit"
        >
          Login
        </button>
      </form>
      <p>{errorMessage}</p>
    </>
  );
}
