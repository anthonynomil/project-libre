import { z } from "zod";

import ContactSchema from "~/classes/schemas/base/Contact.schema.ts";
import CountrySchema from "~/classes/schemas/base/Country.schema.ts";
import ContactInformationFormStructure from "~/classes/schemas/form/Contact.information.form.schema.ts";

export type ClientContactFormSchema = z.infer<typeof ClientContactFormStructure.schema>;

export default class ClientContactFormStructure {
  public static readonly defaultValues: ClientContactFormSchema = {
    contactInformation: ContactInformationFormStructure.defaultValues,
    countryId: null,
    firstname: "",
    lastname: "",
  };

  public static readonly schema = z.object({
    contactInformation: ContactInformationFormStructure.schema.optional(),
    countryId: CountrySchema.id.nullish(),
    firstname: ContactSchema.firstname,
    lastname: ContactSchema.lastname,
  });
}
