// extract the badgegroup id from the url
export function getBadgegroupId(pathname: string) {
  const parts = pathname.split("/");
  return parts[2];
}

// extract the last part of the url
export function getLastPartOfBadgegroupPathname(pathname: string) {
  const parts = pathname.split("/");

  switch (parts[parts.length - 1]) {
    case "students":
      return "Students";

    case "badgetypes":
      return "Badgetypes";

    case "badges":
      return "Badges";

    default:
      return "Badgegroup";
  }
}

// extract the first part of the url
export function getFirstPartOfPathname(pathname: string) {
  const parts = pathname.split("/");
  return parts[1];
}
