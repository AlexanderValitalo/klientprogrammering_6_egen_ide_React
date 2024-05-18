import { SolutionsList } from "./page";

//SolutionProps for the Solution component
interface SolutionProps {
  solutionText: SolutionsList;
}

//Solution component that contains information about the solutions that Badgemania offers
export default function Solution({ solutionText }: SolutionProps) {
  return (
    <div className="flex flex-col items-center border bg-slate-200 rounded-2xl m-3 p-2">
      <h2 className="text-3xl font-semibold text-center rounded-lg my-2">{solutionText.header}</h2>
      <ul className="list-disc mx-7 text-xl max-w-80">
        {solutionText.text.map((solText) => (
          <li key={solText}>{solText}</li>
        ))}
      </ul>
    </div>
  );
}
