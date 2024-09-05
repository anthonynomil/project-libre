import DefaultStorage from "~/classes/storage/Default.storage.ts";

class TokenStorage extends DefaultStorage<string> {
  constructor() {
    super("token");
  }
}

export default new TokenStorage();
