import { z } from "zod";

import ContactInformationSchema from "~/classes/schemas/base/Contact.information.schema.ts";

export type ContactInformationFormSchema = z.infer<typeof ContactInformationFormStructure.schema>;

export default class ContactInformationFormStructure {
  public static readonly defaultValues: ContactInformationFormSchema = {
    mailAddress: "",
    phoneNumber: "",
  };

  public static readonly schema = z.object({
    mailAddress: ContactInformationSchema.email.nullish(),
    phoneNumber: ContactInformationSchema.phoneNumber.nullish(),
  });
}
