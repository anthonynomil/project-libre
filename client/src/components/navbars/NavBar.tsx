import type { NavbarSize } from "~/components/layout/Private.layout.tsx";

import { HomeRounded, PersonRounded, ReceiptRounded, RequestQuoteRounded } from "@mui/icons-material";
import { Paper, Tooltip, Zoom } from "@mui/material";
import { styled } from "@mui/system";
import { useLocation } from "react-router-dom";

import NavBarButton from "~/components/buttons/NavBar.button.tsx";
import ToggleDarkModeButton from "~/components/buttons/ToggleDarkMode.button.tsx";
import ToggleNavBarSizeButton from "~/components/buttons/ToggleNavBarSize.button.tsx";
import Flex from "~/components/layout/Flex.tsx";
import NavText from "~/components/texts/NavBar.text.tsx";
import RoutesUrl from "~/constants/enums/routes.url.ts";

export interface NavbarProps {
  onExpandClick: () => void;
  size: NavbarSize;
}

const navItems = [
  { icon: HomeRounded, label: "Home", to: RoutesUrl.Home },
  { icon: PersonRounded, label: "Clients", to: RoutesUrl.Clients },
  { disabled: true, icon: RequestQuoteRounded, label: "Quotes", to: RoutesUrl.Quotes },
  { disabled: true, icon: ReceiptRounded, label: "Invoices", to: RoutesUrl.Invoices },
];

export default function NavBar({ onExpandClick, size }: NavbarProps) {
  const location = useLocation();

  return (
    <NavBarPaper elevation={4} size={size}>
      <ToggleNavBarSizeButton onClick={onExpandClick} size={size} />
      <Flex alignItems={"center"} flexDirection={"column"} width={"100%"}>
        {navItems.map((item, index) => (
          <Tooltip
            TransitionComponent={Zoom}
            arrow
            key={index}
            placement={"right"}
            title={size === "small" ? item.label : ""}
          >
            <NavBarButton active={location.pathname === item.to} disabled={item.disabled ?? false} to={item.to}>
              <item.icon sx={{ height: 32, mx: 2, width: 32 }} />
              <NavText hidden={size === "small"}>{item.label}</NavText>
            </NavBarButton>
          </Tooltip>
        ))}
      </Flex>
      <ToggleDarkModeButton sx={{ mb: 2 }} />
    </NavBarPaper>
  );
}

const NavBarPaper = styled(Paper)<{ size: NavbarSize }>(({ size, theme }) => ({
  alignItems: "center",
  borderRadius: 0,
  display: "flex",
  flexDirection: "column",
  height: "100%",
  justifyContent: "space-between",
  maxWidth: size === "small" ? theme.spacing(16) : theme.spacing(40),
  position: "relative",
  transition: "max-width 210ms",
  zIndex: 10,
}));
