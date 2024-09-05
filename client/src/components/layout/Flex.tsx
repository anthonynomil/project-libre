import { Box, BoxProps } from "@mui/material";

export default function Flex(props: BoxProps) {
  return (
    <Box display={"flex"} {...props}>
      {props.children}
    </Box>
  );
}
