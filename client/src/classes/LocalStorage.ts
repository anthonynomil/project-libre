class LocalStorage {
  public static clear(): void {
    localStorage.clear();
  }

  public static exists(key: string): boolean {
    return localStorage.getItem(key) !== null;
  }

  public static get<T>(key: string, defaultValue?: T): T | undefined {
    if (this.exists(key)) {
      return JSON.parse(localStorage.getItem(key)!) as T;
    }
    if (defaultValue !== undefined) {
      return defaultValue;
    }
    return undefined;
  }

  public static getOrDefault<T>(key: string, defaultValue: T): T {
    if (this.exists(key)) {
      return JSON.parse(localStorage.getItem(key)!) as T;
    }
    return defaultValue;
  }

  public static remove(key: string): void {
    localStorage.removeItem(key);
  }

  public static set<T>(key: string, value: T): void {
    localStorage.setItem(key, JSON.stringify(value));
  }
}

export default LocalStorage;
