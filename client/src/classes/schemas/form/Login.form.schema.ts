import { z } from "zod";

import AccountSchema from "~/classes/schemas/base/Account.schema.ts";

export type LoginFormSchema = z.infer<typeof LoginFormStructure.schema>;

export default class LoginFormStructure {
  public static readonly defaultValues: LoginFormSchema = {
    email: "",
    password: "",
  };

  public static readonly schema = z.object({
    email: AccountSchema.email,
    password: AccountSchema.password,
  });
}
