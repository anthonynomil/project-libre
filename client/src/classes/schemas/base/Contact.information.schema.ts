import { z } from "zod";

export default class ContactInformationSchema {
  public static readonly email = z
    .string({
      invalid_type_error: "The email must be a string.",
      required_error: "The email is required.",
    })
    .trim()
    .min(1, {
      message: "The email is required.",
    })
    .email({
      message: "The email must be valid.",
    });

  public static readonly phoneNumber = z
    .string({
      invalid_type_error: "The phone number must be a string.",
      required_error: "The phone number is required.",
    })
    .trim()
    .min(1, {
      message: "The phone number is required.",
    });
}
