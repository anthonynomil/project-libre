import { z } from "zod";

import CompanySchema from "~/classes/schemas/base/Company.schema.ts";
import CountrySchema from "~/classes/schemas/base/Country.schema.ts";
import BankDetailsFormStructure from "~/classes/schemas/form/Bank.details.form.schema.ts";
import ClientContactFormStructure from "~/classes/schemas/form/Client.contact.form.schema.ts";

export type ClientFormSchema = z.infer<typeof ClientFormStructure.schema>;

export default class ClientFormStructure {
  public static readonly defaultValues: ClientFormSchema = {
    bankDetails: BankDetailsFormStructure.defaultValues,
    businessName: "",
    contacts: [ClientContactFormStructure.defaultValues],
    countryId: null,
  };

  public static readonly schema = z.object({
    bankDetails: BankDetailsFormStructure.schema.optional(),
    businessName: CompanySchema.businessName,
    contacts: z.array(ClientContactFormStructure.schema).optional(),
    countryId: CountrySchema.id.nullish(),
  });
}
