import type { FormComponent } from "~/types/form.types.ts";

import { Stack } from "@mui/material";
import { forwardRef } from "react";

import FormUtils from "~/classes/Form.utils.ts";
import LoginFormStructure, { type LoginFormSchema } from "~/classes/schemas/form/Login.form.schema.ts";
import FormSubmitButton from "~/components/buttons/Form.submit.button.tsx";
import ControlledPasswordField from "~/components/fields/Controlled.password.field.tsx";
import ControlledTextField from "~/components/fields/Controlled.text.field.tsx";
import useFormManager from "~/hooks/useFormManager.tsx";

const LoginForm: FormComponent<LoginFormSchema> = forwardRef(function LoginForm(props, ref) {
  const { control, isDirty, submit } = useFormManager({
    defaultValues: FormUtils.getDefaultValues(LoginFormStructure.defaultValues, props.defaultValues),
    onSubmit: props.onSubmit,
    ref,
    schema: LoginFormStructure.schema,
  });

  return (
    <Stack aria-label={"login form"} component={"form"} onSubmit={submit} spacing={2}>
      <ControlledTextField
        aria-label={"email field"}
        autoComplete={"email"}
        control={control}
        label={"Email"}
        name={"email"}
      />
      <ControlledPasswordField
        aria-label={"password field"}
        autoComplete={"password"}
        control={control}
        label={"Password"}
        name={"password"}
      />
      <FormSubmitButton
        aria-label={"submit button"}
        disabled={props.canSubmit === false || !isDirty()}
        hidden={props.hideSubmitButton}
        loading={props.isLoading}
        type={"submit"}
      >
        Submit
      </FormSubmitButton>
    </Stack>
  );
});

export default LoginForm;
