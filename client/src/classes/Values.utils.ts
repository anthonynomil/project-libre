export default class ValuesUtils {
  private constructor() {}

  public static isArray(value: unknown): boolean {
    return Array.isArray(value);
  }

  public static isEmpty(value: unknown): boolean {
    if (value === undefined || value === null) return true;
    if (typeof value === "string" && value.trim() === "") return true;
    return !(typeof value === "object" && value.constructor !== Object);
  }
}
