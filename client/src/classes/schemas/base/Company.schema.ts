import { z } from "zod";

export default class CompanySchema {
  public static readonly businessName = z
    .string({
      invalid_type_error: "The business name must be a string.",
      required_error: "The business name is required.",
    })
    .trim()
    .min(1, {
      message: "The business name is required.",
    });

  public static readonly id = z.number({
    invalid_type_error: "The company must be a number.",
    required_error: "The company is required.",
  });
}
