import Header from "@/components/header/Header";

//Contact page for Badgemania that contains information about how to contact the company
export default function ContactPage() {
  return (
    <>
      <Header headerInfo="Contact us!" />

      <div className="font-martian justify-center text-black border-neutral-700 bg-neutral-800/30 rounded-2xl m-2">
        <div className="flex flex-col m-2 px-10 py-2 text-center items-center text-wrap bg-slate-200 rounded-xl">
          <p className="mt-2">If you have questions, please send us an e-mail to:</p>
          <p className="align-middle">
            <a
              className="underline text-blue-700 hover:text-blue-400"
              href="mailto:badgemania@example.com"
            >
              badgemania@example.com
            </a>
          </p>
          <p className="mt-2">
            We always want to have feedback so we can make Badgemania even better.
          </p>
        </div>
      </div>
    </>
  );
}
