import { CircularProgress } from "@mui/material";
import { styled } from "@mui/system";

const ScreenCenteredSpinner = styled(CircularProgress)`
  position: absolute;
  top: 50%;
  left: 50%;
  margin-top: -20px;
  margin-left: -20px;
`;

export default ScreenCenteredSpinner;
