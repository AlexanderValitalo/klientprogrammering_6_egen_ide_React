import StudentsInBadgegroup from "./StudentsInBadgegroup";

// Badgegroup students page
export default function StudentsPage({ params }: { params: { badgegroupId: string } }) {
  return (
    <>
      <StudentsInBadgegroup badgegroupId={params.badgegroupId} />
    </>
  );
}
