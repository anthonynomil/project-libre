type Values = Record<string, unknown>;

class FormUtils {
  public static getDefaultValues<T extends Values>(defaultValues: T, propsDefaultValues?: Partial<T>): T {
    return { ...defaultValues, ...propsDefaultValues };
  }
}

export default FormUtils;
