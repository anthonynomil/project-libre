import { styled } from "@mui/system";
import { type ForwardedRef, forwardRef } from "react";

import LinkButton, { LinkButtonProps } from "~/components/buttons/Link.button.tsx";

interface NavBarButtonProps extends LinkButtonProps {
  active?: boolean;
}

const NavBarButton = forwardRef(function NavBarButton(
  { active, ...props }: NavBarButtonProps,
  ref: ForwardedRef<HTMLButtonElement>,
) {
  return (
    <StyledLinkButton {...props} color={active ? "primary" : "inherit"} ref={ref}>
      {props.children}
    </StyledLinkButton>
  );
});

const StyledLinkButton = styled(LinkButton)(({ theme }) => ({
  borderRadius: `${theme.spacing(0)}`,
  height: `${theme.spacing(16)}`,
  padding: 0,
  width: "100%",
}));

export default NavBarButton;
