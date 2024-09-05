import dotenv from "dotenv";
import fs from "node:fs";
import path from "node:path";
import { generateApi } from "swagger-typescript-api";

dotenv.config();

//TODO: CHECK THIS https://openapi-ts.pages.dev/introduction
const apiUrl = process.env.VITE_API_URL;

if (!apiUrl) throw new Error("The env variable VITE_API_URL is required.");

generateApi({
  name: "api_types",
  output: path.resolve(process.cwd(), "./src/types/api"),
  unwrapResponseData: true,
  url: `${apiUrl}/swagger/v1/swagger.json`,
  httpClientType: "axios",
})
  .then(({ files }) => {
    files.forEach(({ content }) => {
      if (content) {
        fs.writeFileSync(path, content);
      }
    });
  })
  .catch((e) => {
    console.error(e);
    throw new Error(e.message);
  });
