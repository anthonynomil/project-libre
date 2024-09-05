import { Button, ButtonProps } from "@mui/material";
import { type ForwardedRef, MouseEvent, forwardRef } from "react";
import { useNavigate } from "react-router-dom";

export interface LinkButtonProps extends Omit<ButtonProps, "href" | "onClick"> {
  to: string;
}

const LinkButton = forwardRef(function LinkButton(
  { to, ...props }: LinkButtonProps,
  ref: ForwardedRef<HTMLButtonElement>,
) {
  const navigate = useNavigate();

  const navigateTo = (event: MouseEvent<HTMLButtonElement>) => {
    event.preventDefault();
    navigate(to);
  };

  return (
    <Button {...props} href={to} onClick={navigateTo} ref={ref}>
      {props.children}
    </Button>
  );
});

export default LinkButton;
