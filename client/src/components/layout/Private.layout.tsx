import { Box } from "@mui/material";
import { styled } from "@mui/system";
import { ReactNode, useState } from "react";
import { Outlet } from "react-router-dom";

import NavbarSizeStorage from "~/classes/storage/Navbar.size.storage.ts";
import Flex from "~/components/layout/Flex.tsx";
import AppBar from "~/components/navbars/App.bar.tsx";
import NavBar from "~/components/navbars/NavBar.tsx";

export type NavbarSize = "big" | "small";

interface PrivateLayoutProps {
  children?: ReactNode;
}

export default function PrivateLayout(props: PrivateLayoutProps) {
  const [navbarSize, setNavbarSize] = useState<NavbarSize>(NavbarSizeStorage.getOrDefault("small"));

  function changeNavbarSize(prev: NavbarSize): NavbarSize {
    const newNavbarSize = prev === "big" ? "small" : "big";
    NavbarSizeStorage.set(newNavbarSize);
    return newNavbarSize;
  }

  function toggleNavbarSize() {
    setNavbarSize(changeNavbarSize);
  }

  return (
    <Flex flexDirection={"column"} height={"100vh"} width={"100vw"}>
      <AppBar size={navbarSize} />
      <StyledFlex>
        <NavBar onExpandClick={toggleNavbarSize} size={navbarSize} />
        <Flex key={"Gros Bouffon"} sx={{ maxHeight: "100%", overflow: "scroll", width: "100%" }}>
          <LayoutBody>{props.children ?? <Outlet />}</LayoutBody>
        </Flex>
      </StyledFlex>
    </Flex>
  );
}

const StyledFlex = styled(Flex)(({ theme }) => ({
  height: `calc(100vh - ${theme.spacing(16)})`,
  width: "100%",
}));

const LayoutBody = styled(Box)(() => ({
  display: "flex",
  flexDirection: "column",
  height: "100%",
  overflow: "scroll",
  padding: 0,
  width: "100%",
}));
