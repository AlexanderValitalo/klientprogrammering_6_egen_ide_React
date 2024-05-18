import Image from "next/image";

//Header component for Badgemania
export default function Header({ headerInfo }: { headerInfo: string }) {
  return (
    <div className="flex flex-col items-center sm:flex-row">
      <Image
        className="drop-shadow-[0_0_0.3rem_#ffffff70] invert"
        src="/logo_transparent.png"
        alt="Badgemania Logo"
        width={200}
        height={37}
      />
      <h1 className="text-3xl font-bold text-center m-3 font-martian p-4 sm:text-5xl">
        {headerInfo}
      </h1>
    </div>
  );
}
