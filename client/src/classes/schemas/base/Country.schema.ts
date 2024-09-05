import { z } from "zod";

export default class CountrySchema {
  public static readonly id = z.number({
    invalid_type_error: "The country must be a number.",
    required_error: "The country is required.",
  });
}
