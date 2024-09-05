import { QueryClientProvider } from "@tanstack/react-query";
import { createRoot } from "react-dom/client";
import { Provider } from "react-redux";

import App from "~/App.tsx";
import queryClient from "~/constants/config/query.client.ts";
import store from "~/store";

import "@fontsource/roboto/300.css";
import "@fontsource/roboto/400.css";
import "@fontsource/roboto/500.css";
import "@fontsource/roboto/700.css";

//TODO Remove @mui/x-data-grid-generator

const Root = () => {
  return (
    // <StrictMode>
    <QueryClientProvider client={queryClient}>
      <Provider store={store}>
        <App />
      </Provider>
    </QueryClientProvider>
    // </StrictMode>
  );
};

createRoot(document.querySelector("#root")!).render(<Root />);
