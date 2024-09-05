import type { FormComponent } from "~/types/form.types.ts";

import { Stack } from "@mui/material";
import { forwardRef } from "react";

import FormUtils from "~/classes/Form.utils.ts";
import AccountFormStructure, { type AccountFormSchema } from "~/classes/schemas/form/Account.form.schema.ts";
import FormSubmitButton from "~/components/buttons/Form.submit.button.tsx";
import ControlledPasswordField from "~/components/fields/Controlled.password.field.tsx";
import ControlledTextField from "~/components/fields/Controlled.text.field.tsx";
import useFormManager from "~/hooks/useFormManager.tsx";

const AccountForm: FormComponent<AccountFormSchema> = forwardRef(function AccountForm(props, ref) {
  const { control, isDirty, submit } = useFormManager({
    defaultValues: FormUtils.getDefaultValues(AccountFormStructure.defaultValues, props.defaultValues),
    onSubmit: props.onSubmit,
    ref,
    schema: AccountFormStructure.schema,
  });

  return (
    <Stack component={"form"} onSubmit={submit}>
      <ControlledTextField control={control} hidden={true} label={"Email"} name={"email"}  variant={"standard"}/>
      <ControlledPasswordField control={control} label={"Password"} name={"password"} variant={"standard"} />
      <FormSubmitButton
        aria-label={"submit button"}
        disabled={props.canSubmit === false || !isDirty()}
        loading={props.isLoading}
        sx={{
          display: props.hideSubmitButton ? "none" : "initial",
        }}
        type={"submit"}
      >
        Submit
      </FormSubmitButton>
    </Stack>
  );
});

export default AccountForm;
