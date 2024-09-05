export default class ObjectCheckers {
  public static id<Data extends { id: number }>(id: number) {
    return (object: Data) => object.id === id;
  }
}
