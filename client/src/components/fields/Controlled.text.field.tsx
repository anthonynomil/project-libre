import {
  FilledTextFieldProps,
  OutlinedTextFieldProps,
  StandardTextFieldProps,
  TextField,
  TextFieldProps,
  TextFieldVariants,
} from "@mui/material";
import { Control, Controller, FieldValues, Path } from "react-hook-form";

export type ControlledTextFieldProps<T extends FieldValues, Variant extends TextFieldVariants = TextFieldVariants> = {
  control: Control<T>;
  name: Path<T>;
} & TextFieldProps<Variant> &
  (Variant extends "filled"
    ? FilledTextFieldProps
    : Variant extends "standard"
      ? StandardTextFieldProps
      : OutlinedTextFieldProps);

export default function ControlledTextField<T extends FieldValues>(props: ControlledTextFieldProps<T>) {
  const { control, name, ...rest } = props;

  return (
    <Controller
      control={control}
      name={name}
      render={({ field, fieldState }) => (
        <TextField
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
