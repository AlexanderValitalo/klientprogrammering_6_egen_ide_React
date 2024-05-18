import Header from "@/components/header/Header";
import BackToBadgegroupsBtn from "./BackToBadgegroupsBtn";
import CreateBadgegroupForm from "./CreateBadgegroupForm";

// Page to create a new badgegroup
export default function CreateBadgegroupPage() {
  return (
    <>
      <Header headerInfo="Create New Badgegroup:" />
      <CreateBadgegroupForm />
      <BackToBadgegroupsBtn />
    </>
  );
}
