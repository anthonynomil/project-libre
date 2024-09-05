import { z } from "zod";

export default class CitySchema {
  public static readonly id = z.number({
    invalid_type_error: "The city must be a number.",
    required_error: "The city is required.",
  });

  public static readonly name = z.string({
    invalid_type_error: "The name must be a string.",
    required_error: "The city name is required.",
  });

  public static readonly postalCode = z.string({
    invalid_type_error: "The city must be a string.",
    required_error: "The city is required.",
  });
}
