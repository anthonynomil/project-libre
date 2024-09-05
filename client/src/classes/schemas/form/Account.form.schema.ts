import { z } from "zod";

import AccountSchema from "~/classes/schemas/base/Account.schema.ts";

export type AccountFormSchema = z.infer<typeof AccountFormStructure.schema>;

export default class AccountFormStructure {
  public static readonly defaultValues: AccountFormSchema = {
    email: "",
    password: "",
  };

  public static readonly schema = z.object({
    email: AccountSchema.email,
    password: AccountSchema.password,
  });
}
