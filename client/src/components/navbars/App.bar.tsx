import type { NavbarSize } from "~/components/layout/Private.layout.tsx";

import { Box, IconButton, Paper, Stack } from "@mui/material";
import { styled } from "@mui/system";

import Logo from "~/assets/app.icon.svg?react";
import NotificationButton from "~/components/buttons/Notification.button.tsx";
import ProfileButton from "~/components/buttons/Profile.button.tsx";

export interface AppBarProps {
  size: NavbarSize;
}

export default function AppBar({ size }: AppBarProps) {
  return (
    <StyledBar elevation={4}>
      <LogoContainer size={size}>
        <IconButton>
          <Logo />
        </IconButton>
      </LogoContainer>
      <Content>
        <Stack direction={"row"} spacing={1} sx={{ ml: "auto" }}>
          <NotificationButton />
          <ProfileButton />
        </Stack>
      </Content>
    </StyledBar>
  );
}

const StyledBar = styled(Paper)(({ theme }) => ({
  borderRadius: 0,
  display: "flex",
  height: theme.spacing(16),
  maxHeight: theme.spacing(16),
  maxWidth: "100%",
  minHeight: theme.spacing(16),
  minWidth: "100%",
  zIndex: 11,
}));

const LogoContainer = styled(Box)<{ size: NavbarSize }>(({ size, theme }) => ({
  alignItems: "center",
  display: "flex",
  justifyContent: "center",
  minWidth: size === "small" ? theme.spacing(16) : theme.spacing(36),
  svg: {
    backgroundColor: "transparent",
    fill: "currentColor",
    height: theme.spacing(12),
    width: theme.spacing(12),
  },
  transition: "min-width 210ms",
}));

const Content = styled(Box)(({ theme }) => ({
  alignItems: "center",
  display: "flex",
  maxWidth: "100%",
  minHeight: "100%",
  padding: theme.spacing(4),
  width: "100%",
}));
