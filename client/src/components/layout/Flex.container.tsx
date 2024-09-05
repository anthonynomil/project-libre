import { Container, ContainerProps } from "@mui/material";
import { styled } from "@mui/system";

import { AlignItems, FlexDirection, JustifyContent } from "~/types/css.types.ts";

interface FlexContainerProperties extends ContainerProps {
  alignItems?: AlignItems;
  backgroundColor?: string;
  borderRadius?: number;
  flexDirection?: FlexDirection;
  justifyContent?: JustifyContent;
  padding?: number;
}

const FlexContainer = (props: FlexContainerProperties) => {
  const { alignItems: _ai, children, flexDirection: _fd, justifyContent: _jc, ...restOfProps } = props;
  return <Container {...restOfProps}>{children}</Container>;
};

export default styled(FlexContainer)`
  height: 100%;
  display: flex;
  flex-direction: ${(props) => props.flexDirection ?? "column"};
  align-items: ${(props) => props.alignItems ?? "flex-start"};
  justify-content: ${(props) => props.justifyContent ?? "flex-start"};
`;
