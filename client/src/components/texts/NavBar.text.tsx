import { Typography, TypographyProps } from "@mui/material";
import { styled } from "@mui/system";

interface UnStyledNavTextProps extends TypographyProps {
  hidden?: boolean;
}

function UnStyledNavText({ hidden: _, ...props }: UnStyledNavTextProps) {
  return (
    <Typography {...props} variant={"button"}>
      {props.children}
    </Typography>
  );
}

const NavText = styled(UnStyledNavText)(({ hidden, theme }) => {
  return {
    display: "inline-block",
    overflow: "hidden",
    textAlign: "left",
    transition: "width 210ms linear",
    whiteSpace: "nowrap",
    width: hidden ? "0" : theme.spacing(24),
  };
});

export default NavText;
