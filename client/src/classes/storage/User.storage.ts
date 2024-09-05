import type { UserDto } from "~/types/api/api_types.ts";

import DefaultStorage from "~/classes/storage/Default.storage.ts";

class UserStorage extends DefaultStorage<UserDto> {
  constructor() {
    super("user");
  }
}

export default new UserStorage();
