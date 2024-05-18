import { RouteLink } from "@/interfaces/rout-link";

// Not logged in Navigation links
export const UN_AUTH_LINKS: RouteLink[] = [
  { href: "/", text: "Home" },
  { href: "/solutions", text: "Solutions" },
  { href: "/pricing", text: "Pricing" },
  { href: "/about", text: "About" },
  { href: "/contact", text: "Contact" },
  { href: "/login", text: "Login" },
];

// SuperAdmin Navigation links
export const SUPER_ADMIN_LINKS: RouteLink[] = [
  { href: "/", text: "Home" },
  { href: "/solutions", text: "Solutions" },
  { href: "/pricing", text: "Pricing" },
  { href: "/about", text: "About" },
  { href: "/contact", text: "Contact" },
  { href: "/schools", text: "Schools" },
];

// Teacher Navigation links
export const TEACHER_LINKS: RouteLink[] = [
  { href: "/", text: "Home" },
  { href: "/solutions", text: "Solutions" },
  { href: "/pricing", text: "Pricing" },
  { href: "/about", text: "About" },
  { href: "/contact", text: "Contact" },
  { href: "/badgegroups", text: "Badgegroups" },
];

// Student Navigation links
export const STUDENT_LINKS: RouteLink[] = [
  { href: "/", text: "Home" },
  { href: "/solutions", text: "Solutions" },
  { href: "/pricing", text: "Pricing" },
  { href: "/about", text: "About" },
  { href: "/contact", text: "Contact" },
  { href: "/badgegroups", text: "Badgegroups" },
];
