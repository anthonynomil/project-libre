import { DarkModeOutlined, LightModeRounded } from "@mui/icons-material";
import { ButtonProps, IconButton, Tooltip } from "@mui/material";
import { styled } from "@mui/system";
import { useDispatch } from "react-redux";

import { AppDispatch } from "~/store";
import { toggleDarkMode, useDarkModeSelector } from "~/store/reducers/dark.mode.reducer.ts";

interface ToggleDarkModeButtonProps {
  sx?: ButtonProps["sx"];
}

export default function ToggleDarkModeButton(props: ToggleDarkModeButtonProps) {
  const dispatch = useDispatch<AppDispatch>();
  const isDarkMode = useDarkModeSelector();

  const handleToggleDarkMode = () => {
    dispatch(toggleDarkMode());
  };

  return (
    <Tooltip title={"Toggle dark mode"}>
      <IconButtonStyled {...props} aria-label={"Toggle dark mode"} color={"inherit"} onClick={handleToggleDarkMode}>
        {isDarkMode ? <LightModeRounded /> : <DarkModeOutlined />}
      </IconButtonStyled>
    </Tooltip>
  );
}

const IconButtonStyled = styled(IconButton)`
  width: 48px;
  height: 48px;
`;
