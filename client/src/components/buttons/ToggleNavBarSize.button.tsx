import type { NavbarSize } from "~/components/layout/Private.layout.tsx";

import { KeyboardArrowLeftRounded, KeyboardArrowRightRounded } from "@mui/icons-material";
import { Button } from "@mui/material";

interface ToggleNavBarSizeButtonProps {
  onClick: () => void;
  size: NavbarSize;
}

export default function ToggleNavBarSizeButton({ onClick, size }: ToggleNavBarSizeButtonProps) {
  return (
    <Button color={"inherit"} onClick={onClick} sx={{ py: 2, width: "100%" }} variant={"text"}>
      {size === "small" ? (
        <KeyboardArrowRightRounded sx={{ height: 32, width: 32 }} />
      ) : (
        <KeyboardArrowLeftRounded sx={{ height: 32, width: 32 }} />
      )}
    </Button>
  );
}
