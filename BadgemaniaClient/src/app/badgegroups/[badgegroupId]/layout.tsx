import BadgegroupHeader from "./BadgegroupHeader";
import BadgegroupContainer from "./BadgegroupContainer";

// Layout for badgegroup page
export default function BadgegroupLayout({ children }: Readonly<{ children: React.ReactNode }>) {
  return (
    <div className="flex flex-col items-center justify-between">
      <BadgegroupHeader />
      <BadgegroupContainer />
      {children}
    </div>
  );
}
