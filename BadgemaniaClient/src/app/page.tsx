import Image from "next/image";

//Home page for Badgemania
export default function Home() {
  return (
    <>
      <Image
        className="drop-shadow-[0_0_0.3rem_#ffffff70] invert"
        src="/logo_transparent.png"
        alt="Badgemania Logo"
        width={400}
        height={37}
      />
      <h1 className="text-4xl font-bold text-center m-3 font-martian p-4 sm:text-5xl">
        Welcome to Badgemania!
      </h1>
      <h2 className="text-3xl font-semibold text-center m-3 font-martian max-w-2xl">
        The application that makes students motivated with digital badges and gamification!
      </h2>
    </>
  );
}
