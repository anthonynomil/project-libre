import { createSlice } from "@reduxjs/toolkit";
import { useSelector } from "react-redux";

import DarkModeStorage from "~/classes/storage/Dark.mode.storage.ts";
import { RootState } from "~/store";

interface DarkModeState {
  value: boolean;
}

const initialState: DarkModeState = {
  value: DarkModeStorage.getOrDefault(false),
};

export const darkModeSlice = createSlice({
  initialState,
  name: "darkMode",
  reducers: {
    toggleDarkMode: (state) => {
      state.value = !state.value;
      DarkModeStorage.set(state.value);
    },
  },
});

export const { toggleDarkMode } = darkModeSlice.actions;
const darkModeSelect = (state: RootState) => state.darkMode.value;
export const useDarkModeSelector = () => useSelector(darkModeSelect);

export default darkModeSlice.reducer;
