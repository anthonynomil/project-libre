import LocalStorage from "~/classes/LocalStorage.ts";

export default abstract class DefaultStorage<Data> {
  private readonly key: string;

  protected constructor(key: string) {
    this.key = key;
  }

  public exists(): boolean {
    return LocalStorage.exists(this.key);
  }

  public get(): Data | undefined {
    return LocalStorage.get<Data>(this.key);
  }

  public getOrDefault(defaultValue: Data): Data {
    return LocalStorage.getOrDefault(this.key, defaultValue);
  }

  public remove(): void {
    return LocalStorage.remove(this.key);
  }

  public set(data: Data): void {
    LocalStorage.set(this.key, data);
  }
}
