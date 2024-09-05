const apiUrl: string = import.meta.env.VITE_API_URL;

if (!apiUrl) {
  throw new Error("VITE_API_URL needs to be defined in the .env file.");
}

export default apiUrl;
