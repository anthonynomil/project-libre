import DefaultStorage from "~/classes/storage/Default.storage.ts";

class DarkModeStorage extends DefaultStorage<boolean> {
  constructor() {
    super("dark_mode");
  }
}

export default new DarkModeStorage();
