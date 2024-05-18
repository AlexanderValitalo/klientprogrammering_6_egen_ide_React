import Solution from "./Solution";
import Header from "@/components/header/Header";

//SolutionsList interface of solutions information
export interface SolutionsList {
  header: string;
  text: string[];
}

//SOLUTIONS contains information about the solutions that Badgemania offers
const SOLUTIONS: SolutionsList[] = [
  {
    header: "Student",
    text: [
      "The student does tasks, created by the teacher",
      "The student gets digital badges for the completed tasks",
      "The student feels more motivated to do more tasks",
    ],
  },
  {
    header: "Teacher",
    text: [
      "The teacher can administrate badgegroups",
      "The teacher can administrate students to the badgegroups",
      "The teacher can make badges for students to collect by doing the specific task",
      "The teacher can administrate badges to students",
    ],
  },
  {
    header: "School Admin",
    text: [
      "The school admin can administrate students in badgemania",
      "The school admin can administrate teachers in badgemania",
    ],
  },
];

//Solutions page for Badgemania that contains information about the solutions that Badgemania offers
export default function SolutionsPage() {
  return (
    <>
      <Header headerInfo="Badgemania solutions for:" />

      <div className="flex flex-col font-martian text-black border-neutral-700 bg-neutral-800/30 rounded-2xl sm:flex-row">
        {SOLUTIONS.map((solution) => (
          <Solution key={solution.header} solutionText={solution} />
        ))}
      </div>
    </>
  );
}
