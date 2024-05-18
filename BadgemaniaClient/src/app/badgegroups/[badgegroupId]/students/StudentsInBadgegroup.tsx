"use client";

import { useEffect, useState } from "react";
import { Student } from "@/interfaces/student";
import { getStudentsInBadgegroup } from "@/utils/api";

// Component that fetches and displays students in a badgegroup
export default function StudentsInBadgegroup({ badgegroupId }: { badgegroupId: string }) {
  const [students, setStudents] = useState([] as Student[]);
  const [noStudents, setNoStudents] = useState(false);

  // Fetch students in badgegroup
  useEffect(() => {
    async function fetchStudents() {
      try {
        const students = await getStudentsInBadgegroup(badgegroupId);
        console.log(students);
        if (students.length > 0) {
          setStudents(students);
        } else {
          setNoStudents(true);
        }
      } catch (error) {
        console.error(error);
      }
    }

    fetchStudents();
  }, [badgegroupId]);

  return (
    <div className="flex flex-col px-2">
      {students.map((student) => (
        <div
          key={student.studentId}
          className="my-3 p-3 bg-slate-200 text-black rounded-2xl font-russo"
        >
          {student.studentEmail}
        </div>
      ))}
      {noStudents && <p className="text-slate-200 font-martian">No students in this badgegroup</p>}
    </div>
  );
}
