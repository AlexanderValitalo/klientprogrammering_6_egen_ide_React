"use client";

import { RouteLink } from "@/interfaces/rout-link";
import Link from "next/link";
import { usePathname } from "next/navigation";
import { getFirstPartOfPathname } from "@/utils/from-url";
import { useEffect, useState } from "react";

// NavigationLinkProps for the NavigationLink component
interface NavigationLinkProps {
  link: RouteLink;
}

// NavigationLink component that contains the navigation link
export default function NavigationLink({ link }: NavigationLinkProps) {
  const [firstPartOfPathname, setFirstPartOfPathname] = useState("");

  const pathname = usePathname();

  // Get the first part of the pathname and set it to the state
  useEffect(() => {
    setFirstPartOfPathname("/" + getFirstPartOfPathname(pathname));
  }, [pathname]);

  if (link.href != "/login") {
    return (
      <Link
        href={link.href}
        className={`group rounded-lg border border-transparent px-2 py-2 m-1 transition-colors
         hover:border-neutral-700 hover:bg-neutral-800/30 ${
           firstPartOfPathname === link.href && "border-neutral-700 bg-neutral-800/30"
         } sm:px-5 sm:py-5`}
      >
        <h2 className="font-russo">{link.text}</h2>
      </Link>
    );
  } else {
    return (
      <Link
        href={link.href}
        className={`group rounded-lg border border-transparent px-2 py-2 m-1 transition-colors
        hover:border-neutral-700 hover:bg-neutral-800/30 ${
          pathname === link.href
            ? "border-neutral-700 bg-neutral-800/30"
            : "border-neutral-600 bg-green-600"
        } sm:px-5 sm:py-5`}
      >
        <h2 className="font-russo">{link.text}</h2>
      </Link>
    );
  }
}
