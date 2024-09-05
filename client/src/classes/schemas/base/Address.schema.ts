import { z } from "zod";

export default class AddressSchema {
  public static readonly id = z
    .number({
      invalid_type_error: "The address must be a number.",
      required_error: "The address is required.",
    })
    .min(0, {
      message: "The address id cannot be under 0",
    });

  public static readonly number = z.number({
    invalid_type_error: "The house number must be a number.",
    required_error: "The house number is required.",
  });

  public static readonly numberComplement = z
    .string({
      invalid_type_error: "The complement house number must be a number.",
      required_error: "The complement house number is required.",
    })
    .min(1, {
      message: "The complement house number is required.",
    });

  public static readonly road = z
    .string({
      invalid_type_error: "The street must be a string.",
      required_error: "The street is required.",
    })
    .min(1, {
      message: "The street is required.",
    });
}
