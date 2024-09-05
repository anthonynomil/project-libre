import { AddRounded, RemoveRounded } from "@mui/icons-material";
import { Box, Divider, IconButton, Stack, Typography } from "@mui/material";
import { Fragment, forwardRef } from "react";
import { Controller, useFieldArray } from "react-hook-form";

import FormUtils from "~/classes/Form.utils.ts";
import ClientContactFormStructure from "~/classes/schemas/form/Client.contact.form.schema.ts";
import ClientFormStructure, { type ClientFormSchema } from "~/classes/schemas/form/Client.form.schema.ts";
import FormSubmitButton from "~/components/buttons/Form.submit.button.tsx";
import ControlledTextField from "~/components/fields/Controlled.text.field.tsx";
import CountrySelect from "~/components/selects/Country.select.tsx";
import useFormManager from "~/hooks/useFormManager.tsx";
import { FormComponent } from "~/types/form.types.ts";

const ClientForm: FormComponent<ClientFormSchema> = forwardRef(function ClientForm(props, ref) {
  const { control, isDirty, submit } = useFormManager({
    defaultValues: FormUtils.getDefaultValues(ClientFormStructure.defaultValues, props.defaultValues as any),
    onSubmit: props.onSubmit,
    ref,
    schema: ClientFormStructure.schema,
  });

  const { append, fields, remove } = useFieldArray({
    control,
    name: "contacts",
  });

  function removeInput(index: number) {
    return () => remove(index);
  }

  return (
    <Stack component={"form"} direction={"column"} onSubmit={submit} spacing={4}>
      <Box sx={{ display: "flex", flexDirection: "column", gap: 3 }}>
        <Box sx={{ display: "flex", flexDirection: "row", gap: 3 }}>
          <Box sx={{ display: "flex", flex: 1, flexDirection: "column", gap: 3, width: "50%" }}>
            <Typography color={"primary"} variant={"h5"}>
              Main informations
            </Typography>
            <ControlledTextField control={control} label={"Business name"} name={"businessName"} required />
            <Controller
              control={control}
              name={"countryId"}
              render={({ field: { onChange, value } }) => <CountrySelect onChange={onChange} value={value} />}
            />
          </Box>
          <Box sx={{ display: "flex", flex: 1, flexDirection: "column", gap: 3, width: "50%" }}>
            <Typography color={"primary"} variant={"h5"}>
              Bank details
            </Typography>
            <ControlledTextField control={control} label={"BIC"} name={"bankDetails.bic"} />
            <ControlledTextField control={control} label={"IBAN"} name={"bankDetails.iban"} />
          </Box>
        </Box>
        <Box sx={{ alignItems: "center", display: "flex", justifyContent: "space-between" }}>
          <Typography color={"primary"} variant={"h5"}>
            Contacts
          </Typography>
          <IconButton color={"success"} onClick={() => append(ClientContactFormStructure.defaultValues)} sx={{ mr: 2 }}>
            <AddRounded />
          </IconButton>
        </Box>
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
            gap: 3,
            height: 400,
            maxHeight: 400,
            overflow: "scroll",
            pr: 2,
          }}
        >
          {fields.map((joe, index) => (
            <Fragment key={joe.id}>
              <Box key={joe.id} sx={{ display: "flex", flexDirection: "column", gap: 3 }}>
                <Box sx={{ alignItems: "center", display: "flex", justifyContent: "space-between" }}>
                  <Typography color={"primary"} variant={"h6"}>
                    Contact {index + 1}
                  </Typography>
                  <IconButton color={"error"} onClick={removeInput(index)}>
                    <RemoveRounded />
                  </IconButton>
                </Box>
                <Box sx={{ display: "flex", flexDirection: "column", gap: 3 }}>
                  <Box sx={{ display: "flex", flex: 1, gap: 3 }}>
                    <Box sx={{ display: "flex", flex: 1, flexDirection: "column", gap: 3, maxWidth: "50%" }}>
                      <ControlledTextField control={control} label={"Firstname"} name={`contacts.${index}.firstname`} />
                      <ControlledTextField control={control} label={"Lastname"} name={`contacts.${index}.lastname`} />
                    </Box>
                    <Box sx={{ display: "flex", flex: 1, flexDirection: "column", gap: 3, maxWidth: "50%" }}>
                      <Controller
                        control={control}
                        name={`contacts.${index}.countryId`}
                        render={({ field: { onChange, value } }) => (
                          <CountrySelect onChange={onChange} value={value ?? null} />
                        )}
                      />
                    </Box>
                  </Box>
                  <Divider />
                  <Box sx={{ display: "flex", flex: 1, gap: 3 }}>
                    <ControlledTextField
                      control={control}
                      label={"Email"}
                      name={`contacts.${index}.contactInformation.mailAddress`}
                      sx={{ width: "100%" }}
                    />
                    <ControlledTextField
                      control={control}
                      label={"Phone number"}
                      name={`contacts.${index}.contactInformation.phoneNumber`}
                      sx={{ width: "100%" }}
                    />
                  </Box>
                </Box>
              </Box>
              {index !== fields.length - 1 && <Divider />}
            </Fragment>
          ))}
        </Box>
      </Box>
      <FormSubmitButton
        disabled={props.canSubmit === false || !isDirty()}
        hidden={props.hideSubmitButton}
        loading={props.isLoading}
        sx={{ ml: "auto" }}
        type={"submit"}
        variant={"contained"}
      >
        Submit
      </FormSubmitButton>
    </Stack>
  );
});

export default ClientForm;
