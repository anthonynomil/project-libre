import {
  FilledTextFieldProps,
  OutlinedTextFieldProps,
  StandardTextFieldProps,
  TextField,
  TextFieldProps,
  TextFieldVariants,
} from "@mui/material";
import { ChangeEvent, useCallback, useMemo } from "react";

export type NumberFieldProps<Variant extends TextFieldVariants = TextFieldVariants> = TextFieldProps<Variant> &
  (Variant extends "filled"
    ? FilledTextFieldProps
    : Variant extends "standard"
      ? StandardTextFieldProps
      : OutlinedTextFieldProps) & {
    onChange: (value: number) => void;
    value: number;
  };

export default function NumberField(props: NumberFieldProps) {
  const onChange = useCallback(
    (event: ChangeEvent<HTMLInputElement>) => {
      const value = Number(event.target.value);
      props.onChange(value);
    },
    [props.onChange],
  );

  const value = useMemo(() => (props.value ? String(props.value) : undefined), [props.value]);

  return <TextField type={"number"} {...props} onChange={onChange} value={value} />;
}
