import type { FormComponent } from "~/types/form.types.ts";

import { Button, Stack, TextField } from "@mui/material";
import { forwardRef } from "react";
import { Controller } from "react-hook-form";
import { z } from "zod";

import FormUtils from "~/classes/Form.utils.ts";
import BaseSchemas from "~/classes/schemas/base";
import NumberField from "~/components/fields/Number.field.tsx";
import useFormManager from "~/hooks/useFormManager.tsx";

// You need to create this in another folder
const schema = z.object({
  age: z.number(),
  name: z.string().or(BaseSchemas.Helpers.emptyString).optional(),
  stones: z.array(z.string()).or(BaseSchemas.Helpers.emptyArray).optional(),
});

export type ExampleSchema = z.infer<typeof schema>;

export interface FormRef {}

const defaultValues: ExampleSchema = {
  age: 0,
  name: "",
  stones: [],
};
// Until here

const ExampleForm: FormComponent<ExampleSchema> = forwardRef(function ExampleForm(props, ref) {
  const { control, submit } = useFormManager({
    defaultValues: FormUtils.getDefaultValues(defaultValues, props.defaultValues),
    onSubmit: props.onSubmit,
    ref,
    schema,
  });

  return (
    <Stack component={"form"} direction={"column"} onSubmit={submit} spacing={4}>
      <Controller
        control={control}
        name={"age"}
        render={({ field: { onChange, value }, fieldState: { error } }) => (
          <NumberField
            error={!!error}
            helperText={error?.message}
            label={"Age"}
            onChange={onChange}
            type={"number"}
            value={value}
          />
        )}
      />
      <Controller
        control={control}
        name={"name"}
        render={({ field: { onChange, value } }) => <TextField label={"Name"} onChange={onChange} value={value} />}
      />
      <Controller
        control={control}
        name={"stones"}
        render={({ field: { onChange, value } }) => <TextField label={"Stones"} onChange={onChange} value={value} />}
      />
      {!props.hideSubmitButton && (
        <Button type={"submit"} variant={"contained"}>
          Submit
        </Button>
      )}
    </Stack>
  );
});

export default ExampleForm;
