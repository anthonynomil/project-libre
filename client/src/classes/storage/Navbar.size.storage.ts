import type { NavbarSize } from "~/components/layout/Private.layout.tsx";

import DefaultStorage from "~/classes/storage/Default.storage.ts";

class NavbarSizeStorage extends DefaultStorage<NavbarSize> {
  constructor() {
    super("navbar_size");
  }
}

export default new NavbarSizeStorage();
