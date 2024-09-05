import type { ForwardRefExoticComponent, RefAttributes } from "react";
import type { DeepPartial, FieldValues, UseFormReset } from "react-hook-form";

export interface FormInfos {
  isDirty: () => boolean;
  isSubmitted: () => boolean;
  isValid: () => boolean;
}

export interface FormRef<T extends FieldValues> extends FormInfos {
  reset: UseFormReset<T>;
  submit: () => void;
}

interface FormProps<T extends FieldValues> {
  canSubmit?: boolean;
  defaultValues?: DeepPartial<T>;
  hideSubmitButton?: boolean;
  isLoading?: boolean;
  onSubmit: (data: T) => void;
}

export interface FormComponent<T extends FieldValues>
  extends ForwardRefExoticComponent<FormProps<T> & RefAttributes<FormRef<T>>> {}
