import { PriceInfoList } from "./page";

//PriceTableProps for the PriceTable component
interface PriceTableProps {
  priceInfoText: PriceInfoList;
}

//PriceTable component that contains information about the different packages that Badgemania offers
export default function PriceTable({ priceInfoText }: PriceTableProps) {
  return (
    <div className="flex flex-col items-center border bg-slate-200 rounded-2xl m-3 p-2">
      <h2 className="text-3xl font-semibold text-center rounded-lg my-2">{priceInfoText.header}</h2>
      <p className="text-2xl font-semibold my-2">{priceInfoText.price}</p>
      <ul className="list-disc mx-7 text-xl max-w-80">
        {priceInfoText.text.map((priceText) => (
          <li key={priceText}>{priceText}</li>
        ))}
      </ul>
      <button className="bg-green-600 rounded-xl text-xl border-black border-2 m-2 p-2 hover:border-neutral-700 hover:bg-neutral-800/30">
        Get if for {priceInfoText.price}
      </button>
    </div>
  );
}
