import type { FormComponent } from "~/types/form.types.ts";

import { Stack } from "@mui/material";
import { forwardRef } from "react";

import FormUtils from "~/classes/Form.utils.ts";
import RegisterFormStructure, { type RegisterFormSchema } from "~/classes/schemas/form/Register.form.schema.ts";
import FormSubmitButton from "~/components/buttons/Form.submit.button.tsx";
import ControlledPasswordField from "~/components/fields/Controlled.password.field.tsx";
import ControlledTextField from "~/components/fields/Controlled.text.field.tsx";
import useFormManager from "~/hooks/useFormManager.tsx";

const RegisterForm: FormComponent<RegisterFormSchema> = forwardRef(function RegisterForm(props, ref) {
  const { control, isDirty, submit } = useFormManager({
    defaultValues: FormUtils.getDefaultValues(RegisterFormStructure.defaultValues, props.defaultValues),
    onSubmit: props.onSubmit,
    ref,
    schema: RegisterFormStructure.schema,
  });

  return (
    <Stack aria-label={"register form"} component={"form"} onSubmit={submit} spacing={4}>
      <ControlledTextField
        aria-label={"lastname field"}
        autoComplete={"lastname"}
        control={control}
        label={"Lastname"}
        name={"lastname"}
      />
      <ControlledTextField
        aria-label={"firstname field"}
        autoComplete={"firstname"}
        control={control}
        label={"Firstname"}
        name={"firstname"}
      />
      <ControlledTextField aria-label={"email field"} control={control} label={"Email"} name={"email"} type={"email"} />
      <ControlledPasswordField
        aria-label={"new password field"}
        autoComplete={"new-password"}
        control={control}
        label={"Password"}
        name={"password"}
      />
      <ControlledPasswordField
        aria-label={"confirm password field"}
        autoComplete={"confirmPassword"}
        control={control}
        label={"Confirm Password"}
        name={"confirmPassword"}
      />
      <FormSubmitButton
        aria-label={"submit button"}
        disabled={props.canSubmit === false || !isDirty()}
        hidden={props.hideSubmitButton}
        loading={props.isLoading}
      />
    </Stack>
  );
});

export default RegisterForm;
