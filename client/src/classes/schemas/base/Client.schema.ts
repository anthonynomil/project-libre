import { z } from "zod";

export default class ClientSchema {
  public static readonly address = z
    .string({
      invalid_type_error: "Address must be a string",
      required_error: "Address is required",
    })
    .trim()
    .min(1, "Address is required")
    .max(255, "Address is too long");
  public static readonly city = z
    .string({
      invalid_type_error: "The city must be a string.",
      required_error: "The city is required.",
    })
    .trim()
    .min(1, {
      message: "The city is required.",
    })
    .max(255, {
      message: "The city is too long.",
    });
  public static readonly country = z
    .string({
      invalid_type_error: "Country must be a string",
      required_error: "Country is required",
    })
    .trim()
    .min(1, "Country is required")
    .max(255, "Country is too long");
  public static readonly email = z
    .string({
      invalid_type_error: "Email must be a string",
      required_error: "Email is required",
    })
    .email("Email is invalid");
  public static readonly id = z
    .number({
      invalid_type_error: "ID must be a number",
      required_error: "ID is required",
    })
    .min(1, "ID is required");
  public static readonly name = z
    .string({
      invalid_type_error: "Name must be a string",
      required_error: "Name is required",
    })
    .trim()
    .min(1, "Name is required")
    .max(255, "Name is too long");
  public static readonly phone = z
    .string({
      invalid_type_error: "Phone must be a string",
      required_error: "Phone is required",
    })
    .trim()
    .min(10, "Phone is too short")
    .max(10, "Phone is too long");
}
