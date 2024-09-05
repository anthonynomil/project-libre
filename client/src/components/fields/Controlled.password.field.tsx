import type { FieldValues } from "react-hook-form";

import { VisibilityOffRounded, VisibilityRounded } from "@mui/icons-material";
import { IconButton } from "@mui/material";
import { useState } from "react";

import ControlledTextField, { type ControlledTextFieldProps } from "~/components/fields/Controlled.text.field.tsx";

export default function ControlledPasswordField<T extends FieldValues>(props: ControlledTextFieldProps<T>) {
  const [showPassword, setShowPassword] = useState<boolean>(false);

  function toggleShowPassword() {
    setShowPassword((prev) => !prev);
  }

  return (
    <ControlledTextField
      {...props}
      InputProps={{
        endAdornment: (
          <IconButton aria-label={"toggle password visibility"} onClick={toggleShowPassword}>
            {showPassword ? <VisibilityOffRounded /> : <VisibilityRounded />}
          </IconButton>
        ),
      }}
      type={showPassword ? "text" : "password"}
    />
  );
}
