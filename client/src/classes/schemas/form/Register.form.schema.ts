import { z } from "zod";

import AccountSchema from "~/classes/schemas/base/Account.schema.ts";

export type RegisterFormSchema = z.infer<typeof RegisterFormStructure.schema>;

export default class RegisterFormStructure {
  public static readonly defaultValues: RegisterFormSchema = {
    confirmPassword: "",
    email: "",
    firstname: "",
    lastname: "",
    password: "",
  };

  public static readonly schema = z
    .object({
      confirmPassword: AccountSchema.password,
      email: AccountSchema.email,
      firstname: AccountSchema.firstname,
      lastname: AccountSchema.lastname,
      password: AccountSchema.password,
    })
    .refine(AccountSchema.confirmPasswordRefiner, {
      message: "Passwords do not match",
      path: ["confirmPassword"],
    });
}
