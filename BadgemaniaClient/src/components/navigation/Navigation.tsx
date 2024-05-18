"use client";

import NavigationLink from "./NavigationLink";
import { useEffect, useState } from "react";
import { UN_AUTH_LINKS, SUPER_ADMIN_LINKS, TEACHER_LINKS, STUDENT_LINKS } from "@/utils/nav.links";
import { RouteLink } from "@/interfaces/rout-link";
import { useRouter } from "next/navigation";
import { getAccessToken, getRole, logout } from "@/utils/auth";

// Navigation component that contains the navigation links
export default function Navigation() {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [links, setLinks] = useState([] as RouteLink[]);

  const router = useRouter();

  // Check if user is authenticated and set the navigation links
  useEffect(() => {
    const token = getAccessToken();

    if (token) {
      setIsAuthenticated(true);
      const role = getRole();
      switch (role) {
        case "Teacher":
          setLinks(TEACHER_LINKS);
          break;
        case "Student":
          setLinks(STUDENT_LINKS);
          break;
        case "SuperAdmin":
          setLinks(SUPER_ADMIN_LINKS);
          break;
        default:
          setLinks(UN_AUTH_LINKS);
          setIsAuthenticated(false);
          break;
      }
    }
  }, []);

  // Logout user
  const handleLogout = () => {
    logout();
    setIsAuthenticated(false);
    setLinks(UN_AUTH_LINKS);
    router.push("/");
  };

  return (
    <div className="flex flex-col w-full">
      <div className="flex flex-row flex-wrap justify-evenly m-2">
        {links.map((link) => (
          <NavigationLink key={link.href} link={link} />
        ))}
        {isAuthenticated && (
          <button
            onClick={handleLogout}
            className={`group rounded-lg border border-transparent font-russo px-2 py-2 m-1 transition-colors 
        hover:border-neutral-700 hover:bg-neutral-800/30 border-neutral-600 bg-red-500 sm:px-5 sm:py-5`}
          >
            Logout
          </button>
        )}
      </div>
      <hr />
    </div>
  );
}
