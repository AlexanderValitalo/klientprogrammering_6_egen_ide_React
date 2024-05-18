import Header from "@/components/header/Header";

//ABOUTS contains information about Badgemania
const ABOUTS: string[] = [
  "Our vision is to make learning fun and engaging for students with the help of gamification.",
  "We also help teachers realse the full potential of their students.",
  "We are a group of people who are passionate about education and technology.",
  "We believe that by combining education and technology we can make a difference for many students.",
  "With Badgemanias badges we hope to inspire students to learn more and to have fun while doing it.",
  "Gamification is a great way to motivate learning and we hope to inspire teachers to use it in their classrooms.",
  "Badgemania is super easy to use and we hope that you will enjoy using it as much as we do.",
];

//About page for Badgemania that contains information about the company
export default function AboutPage() {
  return (
    <>
      <Header headerInfo="About Badgemania:" />

      <div className="flex flex-col font-martian justify-center text-black border-neutral-700 bg-neutral-800/30 rounded-2xl m-2 sm:flex-row sm:flex-wrap">
        {ABOUTS.map((priceText) => (
          <div
            className="flex m-2 px-10 py-2 text-center items-center text-wrap max-w-80 bg-slate-200 rounded-xl"
            key={priceText}
          >
            <p className="align-middle">{priceText}</p>
          </div>
        ))}
      </div>
    </>
  );
}
