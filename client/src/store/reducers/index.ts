import darkModeReducer from "~/store/reducers/dark.mode.reducer.ts";
import userReducer from "~/store/reducers/user.reducer.ts";

const reducers = {
  darkMode: darkModeReducer,
  user: userReducer,
};

export default reducers;
