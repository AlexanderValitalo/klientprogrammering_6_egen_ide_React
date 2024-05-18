import Header from "@/components/header/Header";
import PriceTable from "./PriceTable";

//PriceInfoList interface of price information
export interface PriceInfoList {
  header: string;
  price: string;
  text: string[];
}

//PRICEINFO contains information about the different packages that Badgemania offers
const PRICEINFO: PriceInfoList[] = [
  {
    header: "Small package",
    price: "1$/month",
    text: ["1 school admin", "1 teacher", "20 students per badgegroup", "10 badges per badgegroup"],
  },
  {
    header: "Medium package",
    price: "5$/month",
    text: [
      "1 school admin",
      "5 teachers",
      "30 students per badgegroup",
      "20 badges per badgegroup",
    ],
  },
  {
    header: "Large package",
    price: "10$/month",
    text: [
      "1 school admin",
      "20 teachers",
      "40 students per badgegroup",
      "50 badges per badgegroup",
    ],
  },
  {
    header: "Super package",
    price: "15$/month",
    text: [
      "1 school admin",
      "200 teachers",
      "40 students per badgegroup",
      "unlimited badges per badgegroup",
    ],
  },
];

//Pricing page for Badgemania that contains information about the different packages that Badgemania offers
export default function PricingPage() {
  return (
    <>
      <Header headerInfo="Badgemania prices:" />

      <div className="flex flex-col font-martian text-black border-neutral-700 bg-neutral-800/30 rounded-2xl m-2 lg:flex-row">
        {PRICEINFO.map((priceInfo) => (
          <PriceTable key={priceInfo.header} priceInfoText={priceInfo} />
        ))}
      </div>
    </>
  );
}
