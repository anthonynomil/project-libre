import { z } from "zod";

export default class ContactSchema {
  public static birthdate = z.string({
    invalid_type_error: "The birthdate must be a date.",
    required_error: "The birthdate is required.",
  });

  public static readonly firstname = z
    .string({
      invalid_type_error: "The firstname must be a string.",
      required_error: "The firstname is required.",
    })
    .min(1, {
      message: "The firstname is required.",
    });

  public static readonly lastname = z
    .string({
      invalid_type_error: "The lastname must be a string.",
      required_error: "The lastname is required.",
    })
    .min(1, {
      message: "The lastname is required.",
    });
}
