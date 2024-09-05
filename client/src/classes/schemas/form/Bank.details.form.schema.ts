import { z } from "zod";

import BankDetailsSchema from "~/classes/schemas/base/Bank.details.schema.ts";

export type BankDetailsFormSchema = z.infer<typeof BankDetailsFormStructure.schema>;

export default class BankDetailsFormStructure {
  public static readonly defaultValues: BankDetailsFormSchema = {
    bic: "",
    iban: "",
  };

  public static readonly schema = z.object({
    bic: BankDetailsSchema.bic.nullable(),
    iban: BankDetailsSchema.iban.nullable(),
  });
}
