import Header from "@/components/header/Header";
import Badgegroups from "./Badgegroups";

// Page to display all user's badgegroups
export default function BadgegroupsPage() {
  return (
    <>
      <Header headerInfo="My Badgegroups:" />
      <Badgegroups />
    </>
  );
}
