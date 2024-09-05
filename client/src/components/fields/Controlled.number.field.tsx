import {
  FilledTextFieldProps,
  OutlinedTextFieldProps,
  StandardTextFieldProps,
  TextFieldProps,
  TextFieldVariants,
} from "@mui/material";
import { Control, Controller, FieldValues, Path } from "react-hook-form";

import NumberField from "~/components/fields/Number.field.tsx";

export type ControlledNumberFieldProps<
  T extends FieldValues,
  Variant extends TextFieldVariants = TextFieldVariants,
> = TextFieldProps<Variant> &
  (Variant extends "filled"
    ? FilledTextFieldProps
    : Variant extends "standard"
      ? StandardTextFieldProps
      : OutlinedTextFieldProps) & {
    control: Control<T>;
    name: Path<T>;
  };

export default function ControlledNumberField<T extends FieldValues>(props: ControlledNumberFieldProps<T>) {
  const { control, name, ...rest } = props;

  return (
    <Controller
      control={control}
      name={name}
      render={({ field, fieldState }) => (
        <NumberField
          {...rest}
          error={!!fieldState.error}
          helperText={fieldState.error?.message}
          onChange={field.onChange}
          value={field.value}
        />
      )}
    />
  );
}
