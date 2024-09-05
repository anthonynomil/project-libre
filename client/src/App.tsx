import NiceModal from "@ebay/nice-modal-react";
import { CssBaseline, ThemeProvider, createTheme } from "@mui/material";
import { cyan, deepPurple } from "@mui/material/colors";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";
import { SnackbarProvider } from "notistack";
import { RouterProvider } from "react-router-dom";

import router from "~/router";
import { useDarkModeSelector } from "~/store/reducers/dark.mode.reducer.ts";

import "~/App.css";

const App = () => {
  const darkMode = useDarkModeSelector();

  const theme = createTheme({
    palette: {
      background: {
        default: darkMode ? "#1a1a1a" : "#f5f5f5",
      },
      mode: darkMode ? "dark" : "light",
      primary: {
        main: deepPurple[400],
      },
      secondary: {
        main: cyan[600],
      },
      text: {
        primary: darkMode ? "#f5f5f5" : "#4b4b4b",
      },
    },
    spacing: 4,
    transitions: {
      create: () => "100ms linear",
    },
  });

  return (
    <SnackbarProvider autoHideDuration={3000} maxSnack={3} preventDuplicate>
      <ThemeProvider theme={theme}>
        <CssBaseline />
        <NiceModal.Provider>
          <RouterProvider router={router} />
          <ReactQueryDevtools initialIsOpen={false} />
        </NiceModal.Provider>
      </ThemeProvider>
    </SnackbarProvider>
  );
};

export default App;
