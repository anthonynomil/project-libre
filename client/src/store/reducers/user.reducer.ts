import { type PayloadAction, createSlice } from "@reduxjs/toolkit";
import { useSelector } from "react-redux";

import userStorage from "~/classes/storage/User.storage.ts";
import { RootState } from "~/store";
import { type UserDto } from "~/types/api/api_types.ts";

interface UserState {
  value: UserDto | undefined;
}

const initialState: UserState = {
  value: userStorage.get(),
};

export const userSlice = createSlice({
  initialState,
  name: "user",
  reducers: {
    clear: function (state) {
      state.value = undefined;
      userStorage.remove();
    },
    set: function (state, { payload }: PayloadAction<UserDto>) {
      state.value = payload;
      userStorage.set(payload);
    },
  },
});

export const userActions = userSlice.actions;
const userSelect = (state: RootState) => state.user.value!;
export const useUserSelector = () => useSelector(userSelect);
export default userSlice.reducer;
