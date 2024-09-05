import { z } from "zod";

export default class HelpersSchema {
  public static readonly emptyArray = z.array(z.any()).length(0);
  public static readonly emptyString = z.literal("");

  public static dateNowMinus(years?: number): Date {
    const now = new Date();
    if (!years) return now;
    now.setFullYear(now.getFullYear() - years);
    return now;
  }
}
