import { ChangeEvent } from "react";

type SetFormData = (value: any) => void;

// Handle form change
export function handleFormChange(formData: any, setFormData: SetFormData) {
  return (event: ChangeEvent<HTMLInputElement>) => {
    const fieldName = event.target.name;
    const fieldValue = event.target.value;
    setFormData({
      ...formData,
      [fieldName]: fieldValue,
    });
  };
}
