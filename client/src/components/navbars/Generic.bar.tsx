import { Button, type ButtonProps, Paper, type PaperProps } from "@mui/material";
import { styled } from "@mui/system";
import { Fragment, type ReactNode } from "react";

export interface BarButtonNoChildren extends Omit<BarButton, "children"> {}

export interface BarButton {
  active?: boolean;
  children?: BarButtonNoChildren[];
  label: ReactNode | string;
  onClick?: () => void;
}

export interface GenericBarProps {
  elevation?: number;
  items?: BarButton[];
  sx?: PaperProps["sx"];
}

export default function GenericBar({ elevation = 2, items = [], ...props }: GenericBarProps) {
  return (
    <Paper
      elevation={elevation}
      sx={{
        display: "flex",
        flex: 1,
        flexDirection: "column",
        justifyContent: "center",
        maxWidth: 176,
        width: 176,
        ...props.sx,
      }}
    >
      {items.map((item, index) => (
        <Fragment key={index}>
          <StyledButton
            active={item.active}
            color={item.active ? "primary" : "inherit"}
            disabled={!!item.children}
            onClick={item.onClick}
          >
            {item.label}
          </StyledButton>
          {item.children &&
            item.children.length > 0 &&
            item.children.map((childItem, childIndex) => (
              <StyledButton
                active={childItem.active}
                color={childItem.active ? "primary" : "inherit"}
                isChild
                key={childIndex}
                onClick={childItem.onClick}
              >
                {childItem.label}
              </StyledButton>
            ))}
        </Fragment>
      ))}
    </Paper>
  );
}

interface StyledButtonProps extends ButtonProps {
  active?: boolean;
  isChild?: boolean;
}

const StyledButton = styled(({ active: __, isChild: _, ...otherProps }: StyledButtonProps) => (
  <Button {...otherProps} />
))(({ active, isChild, theme }) => ({
  borderRadius: 0,
  color: active ? theme.palette.primary.main : "inherit",
  display: "flex",
  flex: 1,
  height: 64,
  justifyContent: "flex-start",
  maxHeight: 64,
  paddingLeft: theme.spacing(isChild ? 8 : 4),
}));
