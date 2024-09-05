import { z } from "zod";

export default class BankDetailsSchema {
  public static readonly bic = z
    .string({
      invalid_type_error: "The bank identifier code must be a string.",
      required_error: "The bank identifier is required.",
    })
    .min(1, {
      message: "The bank identifier is required.",
    });

  public static readonly iban = z
    .string({
      invalid_type_error: "The IBAN must be a string.",
      required_error: "The IBAN is required.",
    })
    .min(1, {
      message: "The IBAN is required.",
    });
}
