import { z } from "zod";

export default class AccountSchema {
  public static readonly birthdate = z
    .date({
      invalid_type_error: "Birth date must be a date.",
      required_error: "Birth date is required",
    })
    .max(new Date(), {
      message: "Birth date must be valid.",
    });

  public static readonly confirmPasswordRefiner = ({
    confirmPassword,
    password,
  }: {
    confirmPassword: string;
    password: string;
  }) => confirmPassword === password;

  public static readonly email = z
    .string({
      invalid_type_error: "The email must be a string.",
      required_error: "The email is required.",
    })
    .email({
      message: "The email is invalid.",
    });

  public static readonly firstname = z
    .string({
      invalid_type_error: "The firstname must be a string.",
      required_error: "The firstname is required.",
    })
    .min(1, {
      message: "The firstname is required.",
    })
    .max(100, {
      message: "The firstname cannot be longer than 100 characters.",
    });

  public static readonly id = z.number({
    invalid_type_error: "The account must be a number.",
    required_error: "The account is required.",
  });

  public static readonly lastname = z
    .string({
      invalid_type_error: "The lastname must be a string.",
      required_error: "The lastname is required.",
    })
    .min(1, {
      message: "The lastname is required.",
    })
    .max(100, {
      message: "The lastname cannot be longer than 100 characters.",
    });

  public static readonly password = z
    .string({
      invalid_type_error: "The password must be a string.",
      required_error: "The password is required.",
    })
    .min(1, { message: "The password is required." })
    .min(8, {
      message: "The password must be at least 8 characters.",
    })
    .max(50, {
      message: "The password cannot be over 50 characters.",
    })
    .regex(/\d/, {
      message: "The password must contain at least one number.",
    })
    .regex(/[A-Z]/, {
      message: "The password must contain at least one uppercase letter.",
    })
    .regex(/[a-z]/, {
      message: "The password must contain at least one lowercase letter.",
    })
    .regex(/[^\da-zA-Z]/, {
      message: "The password must contain at least one special character.",
    });
}
