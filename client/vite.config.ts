import * as path from "node:path";

import react from "@vitejs/plugin-react-swc";
import { defineConfig } from "vite";
import svg from "vite-plugin-svgr";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [svg(), react({ tsDecorators: true })],
  resolve: {
    alias: {
      "~": path.resolve(__dirname, "./src"),
    },
  },
});
